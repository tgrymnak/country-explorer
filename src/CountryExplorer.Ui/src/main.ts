
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import { HTTP_INTERCEPTORS, HttpClient, HttpClientModule } from '@angular/common/http';
import { bootstrapApplication } from '@angular/platform-browser';
import { APP_INITIALIZER, importProvidersFrom } from '@angular/core';
import { AppRoutingModule } from './app/app-routing.module';
import { TranslateLoader, TranslateModule } from '@ngx-translate/core';
import { AppComponent } from './app/app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ConfigService } from './app/core/services';
import { ErrorInterceptor } from './app/common/interceptors';

export function httpTranslateLoader(http: HttpClient) {
	return new TranslateHttpLoader(http);
}

export const configFactory = (configService: ConfigService) => {
	return () => configService.loadConfig();
}

bootstrapApplication(AppComponent, {
	providers: [
		{ provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
		{ provide: APP_INITIALIZER, useFactory: configFactory, deps: [ConfigService], multi: true },

		importProvidersFrom(
			BrowserAnimationsModule,
			HttpClientModule,
			AppRoutingModule,
			TranslateModule.forRoot({
				loader: {
					provide: TranslateLoader,
					useFactory: httpTranslateLoader,
					deps: [HttpClient]
				}
			})),
	]
}).catch(err => console.error(err));
