import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { UserAccountService } from './Services/user-account.service';
import { User } from './Models/user';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent
{
  constructor(public userAccountService: UserAccountService, private router: Router)
  {
  }

  onLogOutClick()
  {
    this.userAccountService.currentUser = new User(null, null);
    this.userAccountService.isLoggedIn = false;
    this.userAccountService.currentUserType = null;
    this.router.navigate( [ "/login" ] );
  }
}



