import { CommonModule } from '@angular/common';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { MatNativeDateModule } from '@angular/material/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ExceptionService } from './core/services/exception-service';
import { InvoiceService } from './invoice/invoice.service';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { SpinnerModule } from './core/spinner/spinner.module';
import { LogoutComponent } from './logout/logout.component';
import { SecurityService } from './core/services/security-service';
import { AuthHttpInterceptorService } from './core/services/auth-http-interceptor.service';

@NgModule({
  declarations: [
    AppComponent,
    LogoutComponent
  ],
  imports: [
    CommonModule,
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    MatNativeDateModule,
    BrowserAnimationsModule,
    NoopAnimationsModule,
    SpinnerModule,],
  providers: [InvoiceService,
    ExceptionService,
    SecurityService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthHttpInterceptorService,
      multi: true
    }  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
