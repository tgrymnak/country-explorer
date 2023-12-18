import { Injectable } from "@angular/core";
import { TranslateService } from "@ngx-translate/core";
import { Observable } from "rxjs";

@Injectable({
	providedIn: 'root',
})
export class LocalizationService {

	private localizationKey = 'localization';

	constructor(private translateService: TranslateService) { }

	public get currentLang(): string {
		const lang = localStorage.getItem(this.localizationKey);
		return lang || this.translateService.getDefaultLang();
	}

	public set currentLang(lang: string) {
		localStorage.setItem(this.localizationKey, lang);
	}

	public getLangs(): string[] {
		return this.translateService.getLangs();
	}

	public addLangs(langs: string[]): void {
		this.translateService.addLangs(langs);
		this.translateService.setDefaultLang('en-US');
		this.use(this.currentLang);
	}

	public use(lang: string): Observable<any> {
		return this.translateService.use(lang);
	}

	public translate(key: string | string[]): any {
		return this.translateService.instant(key);
	}
}