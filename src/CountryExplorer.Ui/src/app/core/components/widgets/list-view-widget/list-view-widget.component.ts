import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { TranslateModule } from '@ngx-translate/core';
import { ConfirmationService } from 'primeng/api';
import { ButtonModule } from 'primeng/button';
import { Table, TableModule } from 'primeng/table';
import { CheckboxModule } from 'primeng/checkbox';
import { OverlayPanelModule } from 'primeng/overlaypanel';
import { TableColumn } from 'src/app/core/models';
import { SortByPipe } from 'src/app/common';
import { DropdownModule } from 'primeng/dropdown';

@Component({
	selector: 'app-list-view-widget',
	standalone: true,
	imports: [
		CommonModule,
		RouterModule,
		FormsModule,
		TranslateModule,
		ButtonModule,
		TableModule,
		OverlayPanelModule,
		CheckboxModule,
		DropdownModule,
		SortByPipe
	],
	templateUrl: './list-view-widget.component.html',
	styleUrl: './list-view-widget.component.scss'
})
export class ListViewWidgetComponent implements OnInit {

	@Input()
	items: any[] = [];

	@Input()
	dataKey?: string;

	@Input()
	columns: TableColumn[] = [];

	@Input()
	globalFilterFields?: string[];

	@Input()
	set filter(value: string) {
		this.table?.filterGlobal(value, 'contains');
	}

	@ViewChild('table', { read: Table })
	protected table?: Table;

	protected selectedItems: any[] = [];
	protected pageSize: number = 10;
	protected availablePageSizes = [this.pageSize, this.pageSize * 2, this.pageSize * 5];
	protected selectedColumns: TableColumn[] = [];

	constructor(private confirmationService: ConfirmationService) { }

	ngOnInit(): void {
		this.selectedColumns = this.columns;
	}

	clearAllFilters() {
		this.table?.clear();
	}

	deselectAll() {
		this.selectedItems = [];
	}

	exportToCsv(table: Table) {
		table.exportCSV({ selectionOnly: true });
		this.deselectAll();
	}
}