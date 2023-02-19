import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { SecurityService } from './security-service';
import { ExceptionService } from './exception-service';

@Injectable({
  providedIn: 'root'
})
export class AuthHttpInterceptorService implements HttpInterceptor {

  constructor(private _securityService: SecurityService,
    private _exceptionService: ExceptionService) { }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    if (req.url.includes("login")) {
      return next.handle(req)
        .pipe(
          catchError(this._exceptionService.catchBadResponse)
        );
    }

    const authReq = req.clone({ headers: req.headers.append("Authorization", (this._securityService.token == null ? "" : "Bearer " + this._securityService.token)) });

    return next.handle(authReq)
      .pipe(
        catchError(this._exceptionService.catchBadResponse)
      );
  }
}
