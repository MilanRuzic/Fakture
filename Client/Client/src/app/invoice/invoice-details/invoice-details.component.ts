import { formatDate } from '@angular/common';
import { Component, OnInit, SimpleChanges } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { InvoiceDetailsModel } from '../../core/models/invoice/invoice-details-model';
import { InvoiceService } from '../invoice.service';

@Component({
  selector: 'app-invoice-details',
  templateUrl: './invoice-details.component.html',
  styleUrls: ['./invoice-details.component.css']
})
export class InvoiceDetailsComponent implements OnInit {
  public invoiceDetailsModel: InvoiceDetailsModel;
  public showDatePicker: boolean = false;
  public showNumberFields: boolean = false;
  public invoiceForm: FormGroup;
  public submitted: boolean = false;
  constructor(private _invoiceService: InvoiceService,
    private _route: ActivatedRoute,
    private _router: Router,
    private formBuilder: FormBuilder,  ) {
    this.invoiceDetailsModel = new InvoiceDetailsModel();

    this.invoiceForm = this.formBuilder.group({
      invoiceNumber: [this.invoiceDetailsModel.invoiceNumber, Validators.required],
      partner: [this.invoiceDetailsModel.partner, Validators.required],
      date: [this.invoiceDetailsModel.date, Validators.required],
    });
    this.invoiceForm.valueChanges.subscribe((value) => {
      this.invoiceDetailsModel = { ...this.invoiceDetailsModel, ...value };
    });
  }
  ngOnInit(): void {
   
    this._route.params.subscribe(params => {
      let id = +params['id'];
      if (!isNaN(id) && id > 0) {
        this.getInvoiceById(id);

      }
      else {
        this.initModel();
        this.date.setValue(formatDate(this.invoiceDetailsModel.date, 'yyyy-MM-dd', 'en'));
      }
    });
  }
  get invoiceNumber() {
    return this.invoiceForm.get('invoiceNumber');
  }
  get partner() {
    return this.invoiceForm.get('partner');
  }
  get date() {
    return this.invoiceForm.get('date');
  }
  
  initModel() {
    this.invoiceDetailsModel.invoiceId = 0;
    this.invoiceDetailsModel.invoiceNumber = null;
    this.invoiceDetailsModel.partner = null;
    this.invoiceDetailsModel.date = new Date();
    this.invoiceDetailsModel.amountVat = 0;
    this.invoiceDetailsModel.amountWithoutVat = 0;
    this.invoiceDetailsModel.amountWithoutVatrebate = 0;
    this.invoiceDetailsModel.rebate = 0;
    this.invoiceDetailsModel.rebatePercent = 0;
    this.invoiceDetailsModel.total = 0;
    this.showDatePicker = true;
  }
  onDateChange(date: Date) {
    this.invoiceDetailsModel.date = date;
  }
  getInvoiceById(id:number) {
    this._invoiceService.getInvoiceById(id).subscribe(result => {
      this.invoiceDetailsModel = result;
      this.invoiceForm.patchValue({
        invoiceNumber: this.invoiceDetailsModel.invoiceNumber,
        partner: this.invoiceDetailsModel.partner,
        date: formatDate(this.invoiceDetailsModel.date, 'yyyy-MM-dd', 'en')
      })
      console.log(this.invoiceForm)
      this.showDatePicker = true;
      this.showNumberFields = true;
    });
  }
  saveInvoice() {
    this.submitted = true;
    if (this.invoiceForm.valid) {
      this._invoiceService.saveInvoice(this.invoiceDetailsModel).subscribe(result => {
        if (this.invoiceDetailsModel != null && this.invoiceDetailsModel.invoiceId > 0)
          this._router.navigate(['/invoice/invoice-list']);
        else
          this._router.navigate(['/invoice/edit-invoice/' + result]);
      });
    }
  }
}
