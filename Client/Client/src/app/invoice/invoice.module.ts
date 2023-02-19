import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InvoiceRoutingModule } from './invoice-routing.module';
import { InvoiceListComponent } from './invoice-list/invoice-list.component';
import { InvoiceDetailsComponent } from './invoice-details/invoice-details.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { InvoiceItemsListComponent } from './invoice-items/invoice-items-list/invoice-items-list.component';
import { InvoiceItemsDetailsComponent } from './invoice-items/invoice-items-details/invoice-items-details.component';




@NgModule({
  declarations: [
    InvoiceListComponent,
    InvoiceDetailsComponent,
    InvoiceItemsListComponent,
    InvoiceItemsDetailsComponent
  ],
  imports: [
    CommonModule,
    InvoiceRoutingModule,
    FormsModule,
    RouterModule,
    ReactiveFormsModule
  ],
  providers: [],

})
export class InvoiceModule { }
