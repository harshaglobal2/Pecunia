import { Component, OnInit } from '@angular/core';
import { Supplier } from '../../Models/supplier';
import { SuppliersService } from '../../Services/suppliers.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import * as $ from "jquery";
import { InventoryComponentBase } from '../../inventory-component';

@Component({
  selector: 'app-suppliers',
  templateUrl: './suppliers.component.html',
  styleUrls: ['./suppliers.component.scss']
})
export class SuppliersComponent extends InventoryComponentBase implements OnInit
{
  suppliers: Supplier[] = [];
  showSuppliersSpinner: boolean = false;
  viewSupplierCheckBoxes: any;

  sortBy: string = "supplierName";
  sortDirection: string = "ASC";

  newSupplierForm: FormGroup;
  newSupplierDisabled: boolean = false;
  newSupplierFormErrorMessages: any;

  editSupplierForm: FormGroup;
  editSupplierDisabled: boolean = false;
  editSupplierFormErrorMessages: any;

  deleteSupplierForm: FormGroup;
  deleteSupplierDisabled: boolean = false;

  constructor(private suppliersService: SuppliersService)
  {
    super();
    this.newSupplierForm = new FormGroup({
      supplierName: new FormControl(null, [Validators.required, Validators.minLength(2), Validators.maxLength(40)]),
      supplierMobile: new FormControl(null, [Validators.required, Validators.pattern(/^[6789]\d{9}$/)]),
      email: new FormControl(null, [Validators.required, Validators.email]),
      password: new FormControl(null, [Validators.required, Validators.pattern(/((?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,15})/)])
    });

    this.newSupplierFormErrorMessages = {
      supplierName: { required: "Supplier Name can't be blank", minlength: "Supplier Name should contain at least 2 characters", maxlength: "Supplier Name can't be longer than 40 characters" },
      supplierMobile: { required: "Mobile number can't be blank", pattern: "10 digit Mobile number is required" },
      email: { required: "Email can't be blank", pattern: "Email is invalid" },
      password: { required: "Password can't be blank", pattern: "Password should contain should be between 6 to 15 characters long, with at least one uppercase letter, one lowercase letter and one digit" }
    };



    this.editSupplierForm = new FormGroup({
      id: new FormControl(null),
      supplierID: new FormControl(null),
      supplierName: new FormControl(null, [Validators.required, Validators.minLength(2), Validators.maxLength(40)]),
      supplierMobile: new FormControl(null, [Validators.required, Validators.pattern(/^[6789]\d{9}$/)]),
      email: new FormControl(null, [Validators.required, Validators.email]),
      password: new FormControl(null),
      creationDateTime: new FormControl(null)
    });

    this.editSupplierFormErrorMessages = {
      supplierName: { required: "Supplier Name can't be blank", minlength: "Supplier Name should contain at least 2 characters", maxlength: "Supplier Name can't be longer than 40 characters" },
      supplierMobile: { required: "Mobile number can't be blank", pattern: "10 digit Mobile number is required" },
      email: { required: "Email can't be blank", pattern: "Email is invalid" }
    };

    this.viewSupplierCheckBoxes = {
      supplierName: true,
      mobile: true,
      email: true,
      createdOn: true,
      lastModifiedOn: true
    };

    this.deleteSupplierForm = new FormGroup({
      id: new FormControl(null),
      supplierID: new FormControl(null),
      supplierName: new FormControl(null)
    });
  }

  ngOnInit()
  {
    this.showSuppliersSpinner = true;
    this.suppliersService.GetAllSuppliers().subscribe((response) =>
    {
      this.suppliers = response;
      this.showSuppliersSpinner = false;
    }, (error) =>
      {
        console.log(error);
      })
  }

  onCreateSupplierClick()
  {
    this.newSupplierForm.reset();
    this.newSupplierForm["submitted"] = false;
  }

  onAddSupplierClick(event)
  {
    this.newSupplierForm["submitted"] = true;
    if (this.newSupplierForm.valid)
    {
      this.newSupplierDisabled = true;
      var supplier: Supplier = this.newSupplierForm.value;

      this.suppliersService.AddSupplier(supplier).subscribe((addResponse) =>
      {
        this.newSupplierForm.reset();
        $("#btnAddSupplierCancel").trigger("click");
        this.newSupplierDisabled = false;
        this.showSuppliersSpinner = true;

        this.suppliersService.GetAllSuppliers().subscribe((getResponse) =>
        {
          this.showSuppliersSpinner = false;
          this.suppliers = getResponse;
        }, (error) =>
          {
            console.log(error);
          });
      },
        (error) =>
        {
          console.log(error);
          this.newSupplierDisabled = false;
        });
    }
    else
    {
      super.getFormGroupErrors(this.newSupplierForm);
    }
  }



  getFormControlCssClass(formControl: FormControl, formGroup: FormGroup): any
  {
    return {
      'is-invalid': formControl.invalid && (formControl.dirty || formControl.touched || formGroup["submitted"]),
      'is-valid': formControl.valid && (formControl.dirty || formControl.touched || formGroup["submitted"])
    };
  }

  getFormControlErrorMessage(formControlName: string, validationProperty: string): string
  {
    return this.newSupplierFormErrorMessages[formControlName][validationProperty];
  }

  getCanShowFormControlErrorMessage(formControlName: string, validationProperty: string, formGroup: FormGroup): boolean
  {
    return formGroup.get(formControlName).invalid && (formGroup.get(formControlName).dirty || formGroup.get(formControlName).touched || formGroup['submitted']) && formGroup.get(formControlName).errors[validationProperty];
  }



  onEditSupplierClick(index)
  {
    this.editSupplierForm.reset();
    this.editSupplierForm["submitted"] = false;
    this.editSupplierForm.patchValue({
      id: this.suppliers[index].id,
      supplierID: this.suppliers[index].supplierID,
      supplierName: this.suppliers[index].supplierName,
      supplierMobile: this.suppliers[index].supplierMobile,
      email: this.suppliers[index].email,
      password: this.suppliers[index].password,
      creationDateTime: this.suppliers[index].creationDateTime
    });
  }

  onUpdateSupplierClick(event)
  {
    this.editSupplierForm["submitted"] = true;
    if (this.editSupplierForm.valid)
    {
      this.editSupplierDisabled = true;
      var supplier: Supplier = this.editSupplierForm.value;

      this.suppliersService.UpdateSupplier(supplier).subscribe((updateResponse) =>
      {
        this.editSupplierForm.reset();
        $("#btnUpdateSupplierCancel").trigger("click");
        this.editSupplierDisabled = false;
        this.showSuppliersSpinner = true;

        this.suppliersService.GetAllSuppliers().subscribe((getResponse) =>
        {
          this.showSuppliersSpinner = false;
          this.suppliers = getResponse;
        }, (error) =>
          {
            console.log(error);
          });
      },
        (error) =>
        {
          console.log(error);
          this.editSupplierDisabled = false;
        });
    }
    else
    {
      super.getFormGroupErrors(this.editSupplierForm);
    }
  }



  onDeleteSupplierClick(index)
  {
    this.deleteSupplierForm.reset();
    this.deleteSupplierForm["submitted"] = false;
    this.deleteSupplierForm.patchValue({
      id: this.suppliers[index].id,
      supplierID: this.suppliers[index].supplierID,
      supplierName: this.suppliers[index].supplierName
    });
  }

  onDeleteSupplierConfirmClick(event)
  {
    this.deleteSupplierForm["submitted"] = true;
    if (this.deleteSupplierForm.valid)
    {
      this.deleteSupplierDisabled = true;
      var supplier: Supplier = this.deleteSupplierForm.value;

      this.suppliersService.DeleteSupplier(supplier.supplierID, supplier.id).subscribe((deleteResponse) =>
      {
        this.deleteSupplierForm.reset();
        $("#btnDeleteSupplierCancel").trigger("click");
        this.deleteSupplierDisabled = false;
        this.showSuppliersSpinner = true;

        this.suppliersService.GetAllSuppliers().subscribe((getResponse) =>
        {
          this.showSuppliersSpinner = false;
          this.suppliers = getResponse;
        }, (error) =>
          {
            console.log(error);
          });
      },
        (error) =>
        {
          console.log(error);
          this.deleteSupplierDisabled = false;
        });
    }
    else
    {
      super.getFormGroupErrors(this.deleteSupplierForm);
    }
  }



  onViewSelectAllClick()
  {
    for (let propertyName of Object.keys(this.viewSupplierCheckBoxes))
    {
      this.viewSupplierCheckBoxes[propertyName] = true;
    }
  }

  onViewDeselectAllClick()
  {
    for (let propertyName of Object.keys(this.viewSupplierCheckBoxes))
    {
      this.viewSupplierCheckBoxes[propertyName] = false;
    }
  }
  
  onBtnSortClick()
  {
    console.log(this.sortBy);
    this.suppliers.sort((a, b) =>
    {
      let comparison = 0;
      let value1 = ((typeof a[this.sortBy]) == 'string') ? a[this.sortBy].toUpperCase() : a[this.sortBy];
      let value2 = ((typeof b[this.sortBy]) == 'string') ? b[this.sortBy].toUpperCase() : b[this.sortBy];

      if (value1 < value2)
      {
        comparison = -1;
      }
      else if (value1 > value2)
      {
        comparison = 1;
      }
      if (this.sortDirection == "DESC")
        comparison = comparison * -1;

      console.log(value1, value2, comparison);
      return comparison;
    });

  }
}



