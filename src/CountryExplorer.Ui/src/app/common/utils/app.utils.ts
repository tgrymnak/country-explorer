export class AppUtils {

	static scrollTo(element: string) {
		const section = document.getElementById(element);
		if (section) {
			section.scrollIntoView({ block: 'start', behavior: 'smooth' });
		}
	}
}