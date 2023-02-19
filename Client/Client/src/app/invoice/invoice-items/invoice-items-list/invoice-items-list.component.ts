import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { InvoiceItemsListModel } from '../../../core/models/invoice/invoice-items-list-model';
import { InvoiceService } from '../../invoice.service';

@Component({
  selector: 'app-invoice-items-list',
  templateUrl: './invoice-items-list.component.html',
  styleUrls: ['./invoice-items-list.component.css']
})
export class InvoiceItemsListComponent implements OnInit {
  @Input() invoiceId: number;
  public invoiceItemsList: InvoiceItemsListModel[];
  constructor(private _invoiceService: InvoiceService,
    private _router: Router) {
    this.invoiceItemsList = [];
  }
  ngOnInit(): void {
    this.getInvoiceItemsByInvoiceId();
  }
  getInvoiceItemsByInvoiceId() {
    this._invoiceService.getInvoiceItemsByInvoiceId(this.invoiceId).subscribe(result => {
      this.invoiceItemsList = result;
    });
  }
  deleteInvoiceItem(id: number) {
    this._invoiceService.deleteInvoiceItem(id).subscribe(result => {
      location.reload();
    });

  }
}
