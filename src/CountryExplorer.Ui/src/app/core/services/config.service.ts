import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { lastValueFrom } from "rxjs";
import { Config } from "../models";

@Injectable({
	providedIn: 'root'
})
export class ConfigService {

	values?: Config;

	constructor(private http: HttpClient) { }

	async loadConfig() {
		const config = await lastValueFrom(this.http.get<Config>('./assets/config.json'));
		this.values = config;
	}
}