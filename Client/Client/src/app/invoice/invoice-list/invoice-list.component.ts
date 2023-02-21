import { Component, OnInit } from '@angular/core';
import { InvoiceListModel } from '../../core/models/invoice/invoice-list-model';
import { InvoiceSearchModel } from '../../core/models/invoice/invoice-search-model';
import { InvoiceService } from '../invoice.service';

@Component({
  selector: 'app-invoice-list',
  templateUrl: './invoice-list.component.html',
  styleUrls: ['./invoice-list.component.css']
})
export class InvoiceListComponent implements OnInit {
  public invoices: InvoiceListModel[] | undefined;
  public invoicesSearch: InvoiceSearchModel;
  constructor(private _invoiceService: InvoiceService) {
    this.invoicesSearch = new InvoiceSearchModel();
    this.invoices = [];
  }
  ngOnInit(): void {
    this.initSearchModel();
      this.searchInvoices();
  }
  initSearchModel() {
    this.invoicesSearch.invoiceNumber = '';
    this.invoicesSearch.partner = '';
  }
  searchInvoices() {
    this._invoiceService.searchInvoices(this.invoicesSearch).subscribe(result => {
      this.invoices = result;
      console.log(this.invoices);
    });
  }
  clearSearch() {
    this.initSearchModel();
    console.log(this.invoicesSearch);

    this.searchInvoices();
  }
  deleteInvoice(id: number) {
    this._invoiceService.deleteInvoice(id).subscribe(result => {
      location.reload();
    });
  }
}
