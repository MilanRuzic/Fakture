import { query } from '@angular/animations';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, finalize, Observable } from 'rxjs';
import { CONFIG } from '../core/config';
import { LoginModel } from '../core/models/users/login-model';
import { ExceptionService } from '../core/services/exception-service';
import { SpinnerService } from '../core/spinner/spinner.service';

@Injectable({
  providedIn: 'root'
})
export class UsersService {

  constructor(private _http: HttpClient,
    private _exceptionService: ExceptionService,
    private _spinnerService: SpinnerService) { }

  login(data: LoginModel): Observable<any> {
    this._spinnerService.show();
    return this._http.post<any>(CONFIG.user.login, data)
      .pipe(
        catchError((e: any) => this._exceptionService.catchBadResponse(e)),
        finalize(() => this._spinnerService.hide()),
      );
  }

  register(data: LoginModel): Observable<any> {
    this._spinnerService.show();
    return this._http.post<any>(CONFIG.user.register, data)
      .pipe(
        catchError((e: any) => this._exceptionService.catchBadResponse(e)),
        finalize(() => this._spinnerService.hide()),

      );
  }

}
