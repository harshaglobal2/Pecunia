import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { UserAccountService } from '../../Services/user-account.service';
import { User } from '../../Models/user';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit
{
  loginForm: FormGroup;

  constructor(private userAccountService: UserAccountService, private router: Router)
  {
    this.loginForm = new FormGroup(
      {
        email: new FormControl(null),
        password: new FormControl(null)
      });
  }

  ngOnInit()
  {
  }

  onLoginClick()
  {
    this.userAccountService.authenticate(this.loginForm.value.email, this.loginForm.value.password).subscribe((response) =>
    {
      if (response != null && response.length > 0)
      {
        this.userAccountService.currentUser = new User(this.loginForm.value.email, response[0].adminName);
        this.userAccountService.currentUserType = "Admin";
        this.userAccountService.isLoggedIn = true;
        this.router.navigate( [ "/admin", "home" ] );
      }
    }, (error) =>
    {
      console.log(error);
    });
  }
}



