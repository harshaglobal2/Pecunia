export class Person
{
  PersonID: string;
  PersonName: string;
  Email: string;
  Password: string;
  Age: string;
  DateOfJoining: string;
  Gender: string;
  IsRegistered: boolean;
  State: string;

  constructor(PersonID: string,
    PersonName: string,
    Email: string,
    Password: string,
    Age: string,
    DateOfJoining: string,
    Gender: string,
    IsRegistered: boolean,
    State: string)
  {
    this.PersonID = PersonID;
    this.PersonName = PersonName;
    this.Email = Email;
    this.Password = Password;
    this.Age = Age;
    this.DateOfJoining = DateOfJoining;
    this.Gender = Gender;
    this.IsRegistered = IsRegistered;
    this.State = State;
  }
}


