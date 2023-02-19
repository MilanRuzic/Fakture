import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from '../core/guard/auth-guard';
import { InvoiceDetailsComponent } from './invoice-details/invoice-details.component';
import { InvoiceItemsDetailsComponent } from './invoice-items/invoice-items-details/invoice-items-details.component';
import { InvoiceListComponent } from './invoice-list/invoice-list.component';

const routes: Routes = [
  { path: '', component: InvoiceListComponent, canActivate: [AuthGuard] },
  { path: 'invoice-list', component: InvoiceListComponent, canActivate: [AuthGuard] },
  { path: 'add-invoice', component: InvoiceDetailsComponent },
  { path: 'edit-invoice/:id', component: InvoiceDetailsComponent, canActivate: [AuthGuard] },
  { path: 'edit-invoice/:id/add-invoice-item', component: InvoiceItemsDetailsComponent, canActivate: [AuthGuard] },
  { path: 'edit-invoice/:id/edit-invoice-item/:itemId', component: InvoiceItemsDetailsComponent, canActivate: [AuthGuard] },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class InvoiceRoutingModule { }
