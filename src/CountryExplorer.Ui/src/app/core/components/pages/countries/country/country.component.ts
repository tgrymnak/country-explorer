import { CommonModule } from '@angular/common';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { TranslateModule } from '@ngx-translate/core';
import { Subject, takeUntil } from 'rxjs';
import { Country } from 'src/app/core/models';
import { CountryService, NotificationService } from 'src/app/core/services';
import { ChipModule } from 'primeng/chip';
import { ImageModule } from 'primeng/image';

@Component({
	selector: 'app-country',
	standalone: true,
	imports: [
		CommonModule,
		TranslateModule,
		RouterModule,
		ChipModule,
		ImageModule
	],
	templateUrl: './country.component.html',
	styleUrl: './country.component.scss'
})
export class CountryComponent implements OnInit, OnDestroy {

	country?: Country;

	$destroyed = new Subject<void>();

	constructor(private route: ActivatedRoute,
		private countryService: CountryService,
		private notificationService: NotificationService) { }

	ngOnInit(): void {
		this.route.params.subscribe(params => {
			const country = params['name'];
			if (country) {
				this.countryService.getCountry(country)
					.pipe(takeUntil(this.$destroyed))
					.subscribe({
						next: data => {
							this.country = data;
						},
						error: error => this.notificationService.showError(error)
					});
			}
		});
	}

	ngOnDestroy(): void {
		this.$destroyed?.next();
		this.$destroyed?.complete();
	}
}