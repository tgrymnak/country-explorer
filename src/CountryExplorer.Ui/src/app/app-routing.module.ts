import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DefaultLayoutComponent } from './core/components/layouts';
import {
	CountriesComponent,
	CountryComponent,
	HomeComponent,
	NotFoundComponent
} from './core/components/pages';

const routes: Routes = [
	// default layout routes
	{
		path: '',
		component: DefaultLayoutComponent,
		children: [
			{ path: '', component: HomeComponent, pathMatch: 'full' },
			{ path: 'countries', component: CountriesComponent },
			{ path: 'countries/:name', component: CountryComponent },
		]
	},

	// no layout routes
	{ path: '404', component: NotFoundComponent },
	{ path: '**', redirectTo: '/404' }
];

@NgModule({
	imports: [RouterModule.forRoot(routes, { scrollPositionRestoration: 'enabled' })],
	exports: [RouterModule]
})
export class AppRoutingModule { }
