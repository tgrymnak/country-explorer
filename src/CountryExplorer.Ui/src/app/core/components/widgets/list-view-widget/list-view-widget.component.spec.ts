import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListViewWidgetComponent } from './list-view-widget.component';

describe('ListViewWidgetComponent', () => {
  let component: ListViewWidgetComponent;
  let fixture: ComponentFixture<ListViewWidgetComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ListViewWidgetComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ListViewWidgetComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
