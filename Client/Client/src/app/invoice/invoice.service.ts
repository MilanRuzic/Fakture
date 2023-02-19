import { query } from '@angular/animations';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, finalize, Observable } from 'rxjs';
import { CONFIG } from '../core/config';
import { InvoiceDetailsModel } from '../core/models/invoice/invoice-details-model';
import { InvoiceItemsListModel } from '../core/models/invoice/invoice-items-list-model';
import { InvoiceSearchModel } from '../core/models/invoice/invoice-search-model';
import { ExceptionService } from '../core/services/exception-service';
import { SpinnerService } from '../core/spinner/spinner.service';

@Injectable({
  providedIn: 'root'
})
export class InvoiceService {

  constructor(private _http: HttpClient,
    private _exceptionService: ExceptionService,
    private _spinnerService: SpinnerService) { }


  searchInvoices(query: InvoiceSearchModel): Observable<any> {
    this._spinnerService.show();
    return this._http.post<any>(CONFIG.invoices.searchInvoices, query)
      .pipe(
        catchError((e: any) => this._exceptionService.catchBadResponse(e)),
        finalize(() => this._spinnerService.hide()),
      );
  }


  getInvoiceById(id: number): Observable<any> {
    this._spinnerService.show();
    return this._http.get<any>(CONFIG.invoices.getInvoiceById + id)
      .pipe(
        catchError((e: any) => this._exceptionService.catchBadResponse(e)),
        finalize(() => this._spinnerService.hide())
      );
  }
  saveInvoice(data: InvoiceDetailsModel): Observable<any> {
    this._spinnerService.show();
    return this._http.post<any>(CONFIG.invoices.saveInvoice, data)
      .pipe(
        catchError((e: any) => this._exceptionService.catchBadResponse(e)),
        finalize(() => this._spinnerService.hide())
      );
  }
  getInvoiceItemsByInvoiceId(id: number): Observable<any> {
    this._spinnerService.show();
    return this._http.get<any>(CONFIG.invoices.getInvoiceItemsByInvoiceId + id)
      .pipe(
        catchError((e: any) => this._exceptionService.catchBadResponse(e)),
        finalize(() => this._spinnerService.hide())
      );
  }
  getInvoiceItemById(id: number): Observable<any> {
    this._spinnerService.show();
    return this._http.get<any>(CONFIG.invoices.getInvoiceItemById + id)
      .pipe(
        catchError((e: any) => this._exceptionService.catchBadResponse(e)),
        finalize(() => this._spinnerService.hide())
      );
  }
  saveInvoiceItem(data: InvoiceItemsListModel): Observable<any> {
    this._spinnerService.show();
    return this._http.post<any>(CONFIG.invoices.saveInvoiceItem, data)
      .pipe(
        catchError((e: any) => this._exceptionService.catchBadResponse(e)),
        finalize(() => this._spinnerService.hide())
      );
  }
  deleteInvoiceItem(id: number): Observable<any> {
    this._spinnerService.show();
    return this._http.delete<any>(CONFIG.invoices.deleteInvoiceItem + id)
      .pipe(
        catchError((e: any) => this._exceptionService.catchBadResponse(e)),
        finalize(() => this._spinnerService.hide())
      );
  }
  deleteInvoice(id: number): Observable<any> {
    this._spinnerService.show();
    return this._http.delete<any>(CONFIG.invoices.deleteInvoice + id)
      .pipe(
        catchError((e: any) => this._exceptionService.catchBadResponse(e)),
        finalize(() => this._spinnerService.hide())
      );
  }
}
