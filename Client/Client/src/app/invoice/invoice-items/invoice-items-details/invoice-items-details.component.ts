import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { combineLatest, Observable, of } from 'rxjs';
import { map, startWith } from 'rxjs/operators';
import { InvoiceItemsListModel } from '../../../core/models/invoice/invoice-items-list-model';
import { InvoiceService } from '../../invoice.service';

@Component({
  selector: 'app-invoice-items-details',
  templateUrl: './invoice-items-details.component.html',
  styleUrls: ['./invoice-items-details.component.css']
})
export class InvoiceItemsDetailsComponent implements OnInit {
  public invoiceItemDetails: InvoiceItemsListModel;

  invoiceForm: FormGroup;
  submitted: boolean = false;


  constructor(private formBuilder: FormBuilder,
    private _route: ActivatedRoute,
    private _router: Router,
    private _invoiceService: InvoiceService) {
    this.invoiceItemDetails = new InvoiceItemsListModel();
    this.invoiceForm = this.formBuilder.group({
      name: [this.invoiceItemDetails.name, Validators.required],
      price: [this.invoiceItemDetails.price, Validators.required],
      quantity: [this.invoiceItemDetails.quantity, Validators.required],
      rebatePercent: [this.invoiceItemDetails.rebatePercent, Validators.required],
    });
    this.invoiceForm.valueChanges.subscribe((value) => {
      this.invoiceItemDetails.amountWithoutVat = this.invoiceForm.get('price').value * this.invoiceForm.get('quantity').value;
      this.invoiceItemDetails.rebate = parseFloat((this.invoiceItemDetails.amountWithoutVat * this.invoiceForm.get('rebatePercent').value).toFixed(2));
      this.invoiceItemDetails.amountWithoutVatrebate = parseFloat((this.invoiceItemDetails.amountWithoutVat + this.invoiceItemDetails.rebate).toFixed(2));
      this.invoiceItemDetails.amountVat = parseFloat((this.invoiceItemDetails.amountWithoutVatrebate * 0.17).toFixed(2));
      this.invoiceItemDetails.total = parseFloat((this.invoiceItemDetails.amountWithoutVatrebate + this.invoiceItemDetails.amountVat).toFixed(2));
      this.invoiceItemDetails = { ...this.invoiceItemDetails, ...value };
    });
  }

  get name() {
    return this.invoiceForm.get('name');
  }
  get price() {
    return this.invoiceForm.get('price');
  }
  get quantity() {
    return this.invoiceForm.get('quantity');
  }
  get rebatePercent() {
    return this.invoiceForm.get('rebatePercent');
  }

  ngOnInit() {
    this._route.params.subscribe(params => {
      this.invoiceItemDetails.invoiceId = +params['id'];
      let id = +params['itemId'];
      if (!isNaN(id) && id > 0) {
        this.getInvoiceItemById(id);
      }
      else {
        this.initModel();
      }
    });
  }

  initModel() {
    this.invoiceItemDetails.name = null;
    this.invoiceItemDetails.quantity = null;
    this.invoiceItemDetails.price = null;
    this.invoiceItemDetails.amountVat = 0;
    this.invoiceItemDetails.amountWithoutVat = 0;
    this.invoiceItemDetails.amountWithoutVatrebate = 0;
    this.invoiceItemDetails.rebate = 0;
    this.invoiceItemDetails.rebatePercent = null;
    this.invoiceItemDetails.total = 0;
  }

  getInvoiceItemById(id: number) {
    this._invoiceService.getInvoiceItemById(id).subscribe(result => {
      this.invoiceItemDetails = result;
      this.invoiceForm.setValue({
        name: this.invoiceItemDetails.name,
        price: this.invoiceItemDetails.price,
        quantity: this.invoiceItemDetails.quantity,
        rebatePercent: this.invoiceItemDetails.price,
      });
    });
  }
  saveInoviceItem() {
    this.submitted = true;
    if (this.invoiceForm.valid) {
      this._invoiceService.saveInvoiceItem(this.invoiceItemDetails).subscribe(result => {
        this._router.navigate(['/invoice/edit-invoice/' + this.invoiceItemDetails.invoiceId]);
      });
    }
  }
}
