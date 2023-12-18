import { Component, OnDestroy, OnInit } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ScrollTopModule } from 'primeng/scrolltop';
import { ToastModule } from 'primeng/toast';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { ConfirmationService, MessageService, PrimeNGConfig } from 'primeng/api';
import { TranslateModule } from '@ngx-translate/core';
import { LocalizationService, NotificationService, UserSettingsService } from './core/services';
import { Subject, takeUntil } from 'rxjs';

@Component({
	selector: 'app-root',
	templateUrl: './app.component.html',
	styleUrls: ['./app.component.scss'],
	standalone: true,
	imports: [
		RouterModule,
		ScrollTopModule,
		ToastModule,
		ConfirmDialogModule,
		TranslateModule
	],
	providers: [
		MessageService,
		ConfirmationService,
		NotificationService,
	]
})
export class AppComponent implements OnInit, OnDestroy {

	$destroyed = new Subject<void>();

	constructor(private primengConfig: PrimeNGConfig,
		private localizationService: LocalizationService,
		private userSettings: UserSettingsService) {
		this.primengConfig.ripple = true;
		this.localizationService.addLangs(['uk-UA', 'en-US']);
	}

	ngOnInit(): void {
		this.userSettings.getDefaultTheme()
			.pipe(takeUntil(this.$destroyed))
			.subscribe(theme => {
				let themeLink = document.getElementById('app-theme') as HTMLLinkElement;
				if (theme && themeLink) {
					themeLink.href = theme + '.css';
				}
			});
	}

	ngOnDestroy(): void {
		this.$destroyed?.next();
		this.$destroyed?.complete();
	}
}
