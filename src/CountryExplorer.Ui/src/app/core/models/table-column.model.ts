import { SelectOption } from "./select-option.model";

export interface TableColumn {
	order?: number;
	field: string;
	header?: string;
	icon?: string;
	type?: 'text' | 'number' | 'date' | 'array';
	transformValue?: (data: any) => any;
	transformNumber?: (data: any, format?: string) => any;
	transformDate?: (date: any, format?: string, item?: any) => string | undefined | null;
	transformArray?: (data?: any[]) => any;
	transformIcon?: (data: any) => any;
	sortable?: boolean;
	filter?: { type: string, options?: () => SelectOption[] | undefined };
	styleClass?: string;
}