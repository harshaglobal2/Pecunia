import { Component, OnInit } from '@angular/core';
import { Supplier } from '../../Models/supplier';
import { SuppliersService } from '../../Services/suppliers.service';
import { FormGroup, FormControl } from '@angular/forms';
import * as $ from "jquery";

@Component({
  selector: 'app-suppliers',
  templateUrl: './suppliers.component.html',
  styleUrls: ['./suppliers.component.scss']
})
export class SuppliersComponent implements OnInit
{
  suppliers: Supplier[] = [];
  newSupplierForm: FormGroup;

  constructor(private suppliersService: SuppliersService)
  {
    this.newSupplierForm = new FormGroup({
      supplierName: new FormControl(null),
      supplierMobile: new FormControl(null),
      email: new FormControl(null),
      password: new FormControl(null),
    });
  }

  ngOnInit()
  {
    this.suppliersService.GetAllSuppliers().subscribe((response) =>
    {
      this.suppliers = response;
    }, (error) =>
    {
      console.log(error);
    })
  }

  onAddSupplier(event)
  {
    var supplier: Supplier = this.newSupplierForm.value;
    this.suppliersService.AddSupplier(supplier);
    this.suppliers.push(supplier);
    this.newSupplierForm.reset();
    $("#newSupplierModal").modal("hide");
    //console.log($);
  }
}


