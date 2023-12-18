import { Injectable } from "@angular/core";
import { BehaviorSubject, Observable, map, share } from "rxjs";
import { AppConstants, StringUtils } from "src/app/common";

@Injectable({
	providedIn: 'root',
})
export class UserSettingsService {

	private defaultThemeKey = 'defaultTheme';

	private defaultThemeSubject = new BehaviorSubject<string | null>(null);

	public getDefaultTheme()
		: Observable<string | null> {
		this.defaultThemeSubject.next(this.getItem(this.defaultThemeKey));

		return this.defaultThemeSubject
			.pipe(share(), map(data => {
				return data || AppConstants.DEFAULT_THEME;
			}));
	}

	public setDefaultTheme(value: string | null)
		: void {
		this.setItem(this.defaultThemeKey, value);
		this.defaultThemeSubject.next(value);
	}

	private getItem(key: string)
		: any {
		const item = sessionStorage.getItem(key);
		return item && JSON.parse(StringUtils.base64ToUtf8(item));
	}

	private setItem(key: string, value: any)
		: void {
		if (value !== undefined && value !== null) {
			const item = StringUtils.utf8ToBase64(JSON.stringify(value));
			sessionStorage.setItem(key, item);
		} else {
			sessionStorage.removeItem(key);
		}
	}
}