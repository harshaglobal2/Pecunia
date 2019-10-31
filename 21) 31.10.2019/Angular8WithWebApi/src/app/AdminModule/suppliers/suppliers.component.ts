import { Component } from "@angular/core";
import { Supplier } from 'src/app/Models/supplier';
import { SuppliersService } from '../../Services/suppliers.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import * as $ from "jquery";

@Component({
  selector: "suppliers",
  templateUrl: "./suppliers.component.html",
  styleUrls: [ "./suppliers.component.scss" ]
})
export class SuppliersComponent
{
  suppliers: Supplier[] = [];
  editSupplierForm: FormGroup;
  editSupplierButtonDisabled: boolean = false;

  constructor(private suppliersService: SuppliersService)
  {
    this.editSupplierForm = new FormGroup({
      id: new FormControl(null),
      supplierID: new FormControl(null),
      supplierName: new FormControl(null, [ Validators.required, Validators.minLength(2), Validators.maxLength(40) ]),
      supplierMobile: new FormControl(null),
      email: new FormControl(null)
    });
  }

  ngOnInit()
  {
    this.suppliersService.GetAllSuppliers().subscribe((response: Supplier[]) =>
    {
      this.suppliers = response;
      //console.log(this.suppliers);


    }, (error) =>
    {
      console.log(error);
      });
  }

  onEditClick(i: number)
  {
    this.editSupplierForm.patchValue({
      supplierName: this.suppliers[i].supplierName,
      id: this.suppliers[i].id,
      email: this.suppliers[i].email,
      supplierMobile: this.suppliers[i].supplierMobile,
      supplierID: this.suppliers[i].supplierID
    });
  }

  onUpdateSupplierClick()
  {
    this.editSupplierForm["submitted"] = true;
    this.editSupplierButtonDisabled = true;

    if (this.editSupplierForm.valid)
    {
      var supplier: Supplier = this.editSupplierForm.value;
      this.suppliersService.UpdateSupplier(supplier).subscribe((response) =>
      {
        console.log(response);
        $("#btnUpdateSupplierCancel").trigger("click");
        this.editSupplierButtonDisabled = false;
      }, (error) => { console.log(error); });

    }
    else
    {
      console.log("Invalid");
    }
  }
}
