export class StringUtils {

	static isNotNull(value: any): boolean {
		return value !== undefined && value !== null;
	}

	static isNotEmpty(value: any): boolean {
		return StringUtils.isNotNull(value) && value.length > 0;
	}

	static utf8ToBase64(value: string) {
		return window.btoa(encodeURIComponent(value));
	}

	static base64ToUtf8(value: string) {
		return decodeURIComponent(window.atob(value));
	}
}