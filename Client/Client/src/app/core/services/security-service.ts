import { HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { LoginModel } from '../models/users/login-model';
@Injectable({
  providedIn: 'root'
})
export class SecurityService {

  constructor() {
    this.currentUserSubject = new BehaviorSubject<LoginModel>(JSON.parse(localStorage.getItem('currentUser')));
    this.currentUser = this.currentUserSubject.asObservable();
  }

  private currentUserSubject: BehaviorSubject<LoginModel>;
  public currentUser: Observable<LoginModel>;

  public get token(): string {
    let currentUser: LoginModel = JSON.parse(localStorage.getItem('currentUser'));
    let token = currentUser && currentUser.token;
    return token;
  }

  public get currentUserValue(): LoginModel {
    return this.currentUserSubject.value;
  }

  saveToLocalStorage(loggedUserModel: LoginModel) {
    localStorage.setItem('currentUser', JSON.stringify(loggedUserModel));
    this.currentUserSubject.next(loggedUserModel);
  }

  logout() {
    localStorage.removeItem('currentUser');
    this.currentUserSubject.next(null);
  }

  isLoggedIn(): boolean {
    if (this.currentUserValue != null && this.currentUserValue.id > 0) {
      return true;
    }
    else {
      return false;
    }
      
  }
}
