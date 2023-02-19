import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InvoiceItemsListComponent } from './invoice-items-list.component';

describe('InvoiceItemsListComponent', () => {
  let component: InvoiceItemsListComponent;
  let fixture: ComponentFixture<InvoiceItemsListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ InvoiceItemsListComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(InvoiceItemsListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
