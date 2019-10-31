import { Component } from '@angular/core';
import { UserAccountsService } from './Services/user-accounts.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent
{
  constructor(public userAccountsService: UserAccountsService, private router: Router)
  {
  }

  onLogoutClick()
  {
    this.userAccountsService.isLoggedIn = false;
    this.router.navigate( [ '/login' ] );
  }
}
