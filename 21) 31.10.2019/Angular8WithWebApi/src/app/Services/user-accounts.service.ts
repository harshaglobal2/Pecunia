import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Admin } from '../Models/Admin';
import { Observable } from "rxjs";

@Injectable({
  providedIn: "root"
})
export class UserAccountsService
{
  isLoggedIn: boolean = false;

  constructor(private httpClient : HttpClient)
  {
  }

  authenticate(email: string, password: string): Observable<Admin[]>
  {
    return this.httpClient.get<Admin[]>(`/api/admins?email=${email}&password=${password}`);
  }
}


