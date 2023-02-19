import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginModel } from '../../core/models/users/login-model';
import { SecurityService } from '../../core/services/security-service';
import { UsersService } from '../users-service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  loginForm: FormGroup;
  loginUser: LoginModel;
  submitted: boolean = false;

  constructor(private _formBuilder: FormBuilder,
    private _router: Router,
    private _usersService: UsersService,
    private _securityService: SecurityService) {
    this.loginForm = this._formBuilder.group({
      email: ['', Validators.required],
      password: ['', Validators.required]
    });

    this.loginForm.valueChanges.subscribe((value) => {
      this.loginUser = { ...this.loginUser, ...value };
    });
  }
  get password() {
    return this.loginForm.get('password');
  }
  get email() {
    return this.loginForm.get('email');
  }
  logIn() {
    this.submitted = true;
    if (this.loginForm.valid) {
      this._usersService.login(this.loginUser).subscribe(result => {
        if (result != null && result.id != null) {
          this._securityService.saveToLocalStorage(result);
          this._router.navigate(['/invoice/invoice-list']);
        }
      });
    }
  }
  register() {
    this._router.navigate(['/users/register']);
  }
}
