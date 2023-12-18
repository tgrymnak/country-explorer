import { Injectable } from "@angular/core";
import { LocalizationService } from "./localization.service";
import { MessageService } from "primeng/api";

@Injectable({
	providedIn: 'root',
})
export class NotificationService {

	constructor(private messageService: MessageService,
		private localizationService: LocalizationService) { }

	showError(error: string | undefined) {
		this.messageService.add({
			severity: 'error',
			summary: this.localizationService.translate('Server Error'),
			detail: error
		});
	}

}