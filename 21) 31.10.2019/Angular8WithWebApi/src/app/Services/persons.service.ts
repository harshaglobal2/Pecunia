import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Person } from '../Models/Person';

@Injectable({
  providedIn: 'root'
})
export class PersonsService
{
  constructor(private httpClient: HttpClient)
  {
  }

  AddPerson(person: Person): Observable<boolean>
  {
    return this.httpClient.post<boolean>(`/api/persons`, person);
  }

  UpdatePerson(person: Person): Observable<boolean>
  {
    return this.httpClient.put<boolean>(`/api/persons`, person);
  }

  DeletePerson(personID: string): Observable<boolean>
  {
    return this.httpClient.delete<boolean>(`/api/persons/${personID}`);
  }

  GetAllPersons(): Observable<Person[]>
  {
    return this.httpClient.get<Person[]>(`/api/persons`);
  }

  GetPersonByPersonID(PersonID: number): Observable<Person>
  {
    return this.httpClient.get<Person>(`/api/persons?personID=${PersonID}`);
  }
  
  GetPersonByEmailAndPassword(Email: string, Password: string): Observable<Person>
  {
    return this.httpClient.get<Person>(`/api/persons?email=${Email}&password=${Password}`);
  }
}



