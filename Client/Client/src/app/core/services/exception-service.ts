import { Injectable } from '@angular/core';
/*import { Response } from '@angular/common/http';*/
import { Observable, of } from 'rxjs';
import { Router } from '@angular/router';



@Injectable()
export class ExceptionService {
  constructor(private router: Router) { }

  catchBadResponse: (errorResponse: any) => Observable<any> = (errorResponse: any) => {
    let msg = "";

    console.log("error code:", errorResponse);

    if (errorResponse.status == 400) {
      let msgInfo = "";

      if (errorResponse.error != null && errorResponse.error != undefined) {
        let validationErrorDictionary = errorResponse.error.errors;
        for (var fieldName in validationErrorDictionary) {
          if (validationErrorDictionary.hasOwnProperty(fieldName)) {
            msgInfo = errorResponse.error.errors[fieldName];
            break;
          }
        }
      }


    }
    else if (errorResponse.status == 401) {
      this.router.navigate(['/users/login'])
      msg = "Vaša sesija je istekla. Prijavite se ponovo na sistem.";
    }
    else if (errorResponse.status == 500) {
      if (errorResponse.error.detail == 'incorect_email_or_password')
        msg = 'Pogresan email ili lozinka';
      else if (errorResponse.error.detail == 'email_exists')
        msg = 'Email postoji'
      else
        msg = "Dogodila se greška. Obratite se administratoru sistema.";
    }
    else if (errorResponse.status == 0) {
      msg = "Servis nije dostupan. Obratite se administratoru sistema.";
    }
    else {
      msg = "Dogodila se greška. Obratite se administratoru sistema.";
    }
    if (msg != "") {
      alert("Error: " + msg);
    }

    return of(false);
  };
}

