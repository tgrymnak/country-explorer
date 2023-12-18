import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, share, map } from "rxjs";
import { ConfigService } from "./config.service";
import { Country } from "../models";

@Injectable({
	providedIn: 'root',
})
export class CountryService {

	constructor(private http: HttpClient,
		private config: ConfigService) { }

	public getCountries()
		: Observable<Country[]> {
		return this.http.get(`${this.config.values?.apiUrl}/country/list`)
			.pipe(share(), map((data: Object) => { return <Country[]>data; }));
	}

	public getCountry(name: string)
		: Observable<Country> {
		return this.http.get(`${this.config.values?.apiUrl}/country/${name}`)
			.pipe(share(), map((data: Object) => { return <Country>data; }));
	}
}