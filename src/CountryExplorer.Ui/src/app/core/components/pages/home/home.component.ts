import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { TranslateModule } from '@ngx-translate/core';
import { ButtonModule } from 'primeng/button';
import { AppUtils } from 'src/app/common/utils';

@Component({
	selector: 'app-home',
	standalone: true,
	imports: [
		CommonModule,
		TranslateModule,
		RouterModule,
		ButtonModule
	],
	templateUrl: './home.component.html',
	styleUrl: './home.component.scss'
})
export class HomeComponent {

	scrollTo = AppUtils.scrollTo;

}
