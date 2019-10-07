import { Component } from "@angular/core";
import { FormGroup, FormControl } from '@angular/forms';

@Component({
  selector: "login",
  templateUrl: "./login.component.html",
  styleUrls: ["./login.component.scss" ]
  })
export class LoginComponent
{
  loginForm: FormGroup;

  constructor()
  {
    this.loginForm = new FormGroup({
      email: new FormControl(null),
      password: new FormControl(null)
    });
  }

  onLoginClick()
  {
    if (this.loginForm.value.email == "admin@gmail.com" && this.loginForm.value.password == "admin123")
    {
      console.log("Successful login");
    }
    else
    {
      console.log("Invalid login");
    }
  }
}
