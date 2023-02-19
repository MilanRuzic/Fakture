import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginModel } from '../../core/models/users/login-model';
import { UsersService } from '../users-service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {

  registerForm: FormGroup;
  submitted: boolean;
  registerUser: LoginModel;
  hide: boolean = true;
  hideCheckedPassword: boolean = true;
  constructor(private _usersService: UsersService,
    private _formBuilder: FormBuilder,
    private _rotuer: Router) {
    this.registerUser = new LoginModel();
    this.registerForm = this._formBuilder.group({
      name: ['', Validators.required],
      lastName: ['', Validators.required],
      phoneNumber: ['', Validators.pattern(/^0\d{2}\/\d{3}-\d{3}$/)],
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(8), Validators.pattern(/^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()_+\-=[\]{};':"\\|,.<>/?]).+$/)]],
      checkPassword: ['', Validators.required]
    },
      {
        validator: this.matchingPasswords("password", "checkPassword")
      });

    this.registerForm.valueChanges.subscribe((value) => {
      this.registerUser = { ...this.registerUser, ...value };
    });
  }
  get password() {
    return this.registerForm.get('password');
  }
  get checkPassword() {
    return this.registerForm.get('checkPassword');
  }
  get email() {
    return this.registerForm.get('email');
  }
  get name() {
    return this.registerForm.get('name');
  }
  get lastName() {
    return this.registerForm.get('lastName');
  }
  get phoneNumber() {
    return this.registerForm.get('phoneNumber');
  }
  matchingPasswords(passwordKey: string, confirmPasswordKey: string) {
    return (group: FormGroup) => {
      const password = group.controls[passwordKey];
      const confirmPassword = group.controls[confirmPasswordKey];
     
        if (password.value !== confirmPassword.value) {
          return confirmPassword.setErrors({ matchingPasswords: true });
        }

    };
  }
  showHidePassword() {
    this.hide = !this.hide;
  }
  showHideCheckPassword() {
    this.hideCheckedPassword = !this.hideCheckedPassword;
  }
  register() {
    this.submitted = true;
    if (this.registerForm.valid) {
      this._usersService.register(this.registerUser).subscribe(result => {
        console.log(result)
        if (result != null && result > 0)
          this._rotuer.navigate(['/users/login']);
      });
    }
  }

}
