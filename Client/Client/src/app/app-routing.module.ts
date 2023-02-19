import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './core/guard/auth-guard';
import { InvoiceItemsListComponent } from './invoice/invoice-items/invoice-items-list/invoice-items-list.component';

const routes: Routes = [
  { path: '', loadChildren: () => import('./invoice/invoice.module').then(m => m.InvoiceModule) },
  { path: 'invoice', loadChildren: () => import('./invoice/invoice.module').then(m => m.InvoiceModule) },
  { path: 'users', loadChildren: () => import('./users/users.module').then(m => m.UsersModule) },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
