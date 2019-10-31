import { Component } from "@angular/core";
import { Person } from '../../Models/person';
import { PersonsService } from '../../Services/persons.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import * as $ from "jquery";

@Component({
  selector: "persons",
  templateUrl: "./persons.component.html",
  styleUrls: [ "./persons.component.scss" ]
})
export class PersonsComponent
{
  persons: Person[] = [];
  editPersonForm: FormGroup;
  editPersonButtonDisabled: boolean = false;

  constructor(private personsService: PersonsService)
  {
    this.editPersonForm = new FormGroup({
      PersonID: new FormControl(null),
      PersonName: new FormControl(null, [Validators.required, Validators.minLength(2), Validators.maxLength(40)]),
      Email: new FormControl(null, [Validators.required, Validators.email]),
      Password: new FormControl(null)
    });
  }

  ngOnInit()
  {
    this.personsService.GetAllPersons().subscribe((response: Person[]) =>
    {
      this.persons = response;
      console.log(this.persons);
    }, (error) =>
    {
      console.log(error);
      });
  }

  onEditClick(i: number)
  {
    this.editPersonForm.patchValue({
      PersonName: this.persons[i].PersonName,
      Email: this.persons[i].Email,
      Password: this.persons[i].Password,
      PersonID: this.persons[i].PersonID
    });
  }

  onUpdatePersonClick()
  {
    this.editPersonForm["submitted"] = true;
    this.editPersonButtonDisabled = true;

    if (this.editPersonForm.valid)
    {
      var person: Person = this.editPersonForm.value;
      this.personsService.UpdatePerson(person).subscribe((response) =>
      {
        console.log(response);
        $("#btnUpdatePersonCancel").trigger("click");
        this.editPersonButtonDisabled = false;
      }, (error) => { console.log(error); });

    }
    else
    {
      console.log("Invalid");
    }
  }
}
