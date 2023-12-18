export class CollectionUtils {
	static onlyUnique<T extends { value: any }>(value: T, index: number, array: T[]): boolean {
		return array.findIndex(e => e.value === value.value) === index;
	}
}