import { CommonModule, Location } from '@angular/common';
import { Component } from '@angular/core';
import { Router, RouterModule } from '@angular/router';
import { TranslateModule } from '@ngx-translate/core';
import { ButtonModule } from 'primeng/button';

@Component({
	selector: 'app-not-found',
	standalone: true,
	imports: [
		CommonModule,
		TranslateModule,
		RouterModule,
		ButtonModule
	],
	templateUrl: './not-found.component.html',
	styleUrl: './not-found.component.scss'
})
export class NotFoundComponent {
	constructor(private location: Location,
		private router: Router) { }

	goBack() {
		this.location.back();
	}

	goHome() {
		this.router.navigateByUrl('/');
	}
}
