import { CommonModule } from '@angular/common';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { TranslateModule } from '@ngx-translate/core';
import { ButtonModule } from 'primeng/button';
import { RippleModule } from 'primeng/ripple';
import { StyleClassModule } from 'primeng/styleclass';
import { SidebarModule } from 'primeng/sidebar';
import { Subject, takeUntil } from 'rxjs';
import { UserSettingsService } from 'src/app/core/services';

@Component({
	selector: 'app-navbar',
	standalone: true,
	imports: [
		CommonModule,
		FormsModule,
		RouterModule,
		StyleClassModule,
		ButtonModule,
		RippleModule,
		TranslateModule,
		SidebarModule
	],
	templateUrl: './navbar.component.html',
	styleUrl: './navbar.component.scss'
})
export class NavbarComponent implements OnInit, OnDestroy {

	darkTheme: boolean = false;
	sidebarVisible: boolean = false;
	$destroyed = new Subject<void>();

	constructor(private userSettings: UserSettingsService) { }

	ngOnInit(): void {
		this.userSettings.getDefaultTheme()
			.pipe(takeUntil(this.$destroyed))
			.subscribe(theme => {
				this.darkTheme = theme === 'theme-dark';
				let themeLink = document.getElementById('app-theme') as HTMLLinkElement;
				if (themeLink) {
					themeLink.href = theme + '.css';
				}
			});
	}

	ngOnDestroy(): void {
		this.$destroyed?.next();
		this.$destroyed?.complete();
	}

	toggleSidebar() {
		this.sidebarVisible = !this.sidebarVisible;
	}

	switchTheme() {
		this.darkTheme = !this.darkTheme;
		const theme = this.darkTheme ? 'theme-dark' : 'theme-light';
		this.userSettings.setDefaultTheme(theme);
	}
}