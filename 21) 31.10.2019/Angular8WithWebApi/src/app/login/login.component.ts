import { Component } from "@angular/core";
import { FormGroup, FormControl } from '@angular/forms';
import { UserAccountsService } from '../Services/user-accounts.service';
import { Admin } from '../Models/Admin';
import { Router } from '@angular/router';

@Component({
  selector: "login",
  templateUrl: "./login.component.html",
  styleUrls: ["./login.component.scss" ]
  })
export class LoginComponent
{
  loginForm: FormGroup;
  showError: boolean = false;

  constructor(private userAccountsService: UserAccountsService, private router: Router)
  {
    this.loginForm = new FormGroup({
      email: new FormControl(null),
      password: new FormControl(null)
    });
  }

  onLoginClick()
  {
    var observableAdmin = this.userAccountsService.authenticate(this.loginForm.controls.email.value, this.loginForm.controls.password.value);

    observableAdmin.subscribe((response) =>
    {
      if (response != null)
      {
        this.router.navigate(['/admin', 'home']);
        this.userAccountsService.isLoggedIn = true;
      }
      else
      {
        this.showError = true;
      }
    }, (error) =>
    {
      console.log(error);
    });
  }
}

