import { Pipe, PipeTransform } from "@angular/core";

@Pipe({
	name: "sortBy",
	standalone: true
})
export class SortByPipe implements PipeTransform {
	transform(value: any[] | undefined, order = '', column: string = ''): any[] | undefined {

		// no array
		if (!value || order === '' || !order) {
			return value;
		}

		// array with only one item
		if (value.length <= 1) {
			return value;
		}

		// sort 1d array
		if (!column || column === '') {
			if (order === 'asc') {
				return value.sort()
			}
			else {
				return value.sort().reverse();
			}
		}

		return value.sort((a, b) => {
			if (order === "asc") {
				return a[column] - b[column];
			} else if (order === "desc") {
				return b[column] - a[column];
			}

			return 0;
		});
	}
}