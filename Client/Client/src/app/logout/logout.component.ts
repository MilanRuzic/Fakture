import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { SecurityService } from '../core/services/security-service';

@Component({
  selector: 'app-logout',
  templateUrl: './logout.component.html',
  styleUrls: ['./logout.component.css']
})
export class LogoutComponent implements OnInit {
  public isLoggedIn: boolean;
  constructor(private _securityService: SecurityService,
    private _router: Router) {
    this._securityService.currentUser.subscribe(loggedInUser => {
      if (loggedInUser != null) {
        this.isLoggedIn = true;
      }
      else {
        this.isLoggedIn = false;
      }
    });
  }
    ngOnInit(): void {
    }
  logout() {
    console.log("logout")
    this._securityService.logout();
    this._router.navigate(['/users/login']);
  }
}
