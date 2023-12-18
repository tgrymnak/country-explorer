import { CommonModule } from '@angular/common';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { TranslateModule } from '@ngx-translate/core';
import { ButtonModule } from 'primeng/button';
import { InputTextModule } from 'primeng/inputtext';
import { Subject, takeUntil } from 'rxjs';
import { Country, SelectOption, TableColumn } from 'src/app/core/models';
import { CountryService, NotificationService } from 'src/app/core/services';
import { ListViewWidgetComponent } from '../../widgets';
import { CollectionUtils } from 'src/app/common/utils';

@Component({
	selector: 'app-countries',
	standalone: true,
	imports: [
		CommonModule,
		TranslateModule,
		ButtonModule,
		InputTextModule,
		ListViewWidgetComponent
	],
	templateUrl: './countries.component.html',
	styleUrl: './countries.component.scss'
})
export class CountriesComponent implements OnInit, OnDestroy {

	countries: Country[] = [];

	currencyOptions?: SelectOption[];
	languageOptions?: SelectOption[];
	regionOptions?: SelectOption[];

	columns: TableColumn[] = [];
	globalFilterFields?: string[];

	$destroyed = new Subject<void>();

	constructor(private countryService: CountryService,
		private notificationService: NotificationService) { }

	ngOnInit(): void {
		this.columns = [
			{
				order: 0,
				field: 'name',
				header: 'Name',
				sortable: true,
				filter: { type: 'text' }
			},
			{
				order: 1,
				field: 'capital',
				header: 'Capital',
				sortable: true,
				filter: { type: 'text' }
			},
			{
				order: 2,
				field: 'currency',
				header: 'Currency',
				sortable: true,
				filter: { type: 'in', options: () => this.currencyOptions }
			},
			{
				order: 3,
				field: 'language',
				header: 'Language',
				sortable: true,
				filter: { type: 'in', options: () => this.languageOptions }
			},
			{
				order: 4,
				field: 'region',
				header: 'Region',
				sortable: true,
				filter: { type: 'in', options: () => this.regionOptions }
			},
		];
		this.globalFilterFields = ['name', 'capital', 'currency', 'language', 'region'];


		this.countryService.getCountries()
			.pipe(takeUntil(this.$destroyed))
			.subscribe({
				next: data => {
					this.countries = data;

					this.currencyOptions = data.flatMap(e => e.currency?.split(',').map(e => <SelectOption>{ value: e, label: e }) || [])
						.filter(CollectionUtils.onlyUnique);
					this.languageOptions = data.flatMap(e => e.language?.split(',').map(e => <SelectOption>{ value: e, label: e }) || [])
						.filter(CollectionUtils.onlyUnique);
					this.regionOptions = data.map(e => <SelectOption>{ value: e.region, label: e.region })
						.filter(CollectionUtils.onlyUnique);
				},
				error: error => this.notificationService.showError(error)
			});
	}

	ngOnDestroy(): void {
		this.$destroyed?.next();
		this.$destroyed?.complete();
	}
}
