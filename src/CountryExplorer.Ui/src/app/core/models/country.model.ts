import { Currency } from "./currency.model";
import { Language } from "./language.model";

export interface Country {
	name: string;
	capital?: string;
	capitals?: string[];
	currency?: string;
	currencies?: Currency[];
	language?: string;
	languages?: Language[];
	region: string;
	subregion: string;
	population: number;
	area: number;
	flag: string;
	map: string;
}