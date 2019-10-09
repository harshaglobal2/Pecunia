import { Component, OnInit } from '@angular/core';
import { Supplier } from '../../Models/supplier';
import { SuppliersService } from '../../Services/suppliers.service';
import { FormGroup, FormControl, Validators, FormArray } from '@angular/forms';
import * as $ from "jquery";
import { InventoryComponentBase } from '../../inventory-component';
import { OrderDetail } from 'src/app/Models/order-detail';
import { RawMaterial } from 'src/app/Models/raw-material';
import { Order } from 'src/app/Models/order';
import { RawMaterialsService } from 'src/app/Services/raw-materials.service';
import { OrderDetailsService } from 'src/app/Services/order-details.service';
import { OrdersService } from 'src/app/Services/orders.service';

@Component({
  selector: 'app-suppliers',
  templateUrl: './new-order.component.html',
  styleUrls: ['./new-order.component.scss']
})
export class NewOrderComponent extends InventoryComponentBase implements OnInit
{
  suppliers: Supplier[] = [];
  rawMaterials: RawMaterial[] = [];
  order: Order;

  showOrderSpinner: boolean = false;
  
  newOrderForm: FormGroup;
  newOrderDisabled: boolean = false;
  newOrderFormErrorMessages: any;
  
  constructor(private suppliersService: SuppliersService, private rawMaterialsService: RawMaterialsService, private ordersService: OrdersService, private orderDetailsService: OrderDetailsService)
  {
    super();
    this.newOrderForm = new FormGroup({
      orderDate: new FormControl(new Date().toLocaleDateString()),
      supperlID: new FormControl(null),
      totalQuantity: new FormControl(0),
      totalAmount: new FormControl(0),
      orderDetails: new FormArray([
        new FormGroup({
          orderID: new FormControl(null),
          rawMaterialCode: new FormControl(null, [ Validators.required ]),
          rawMaterialName: new FormControl(null),
          rawMaterialID: new FormControl("", [Validators.required]),
          unitPrice: new FormControl(null),
          quantity: new FormControl(1, [Validators.required, Validators.pattern(/^[0-9]*$/) ]),
          totalAmount: new FormControl(null)
        })
      ])
    });
  }

  ngOnInit()
  {
    this.showOrderSpinner = true;
    this.suppliersService.GetAllSuppliers().subscribe((response) =>
    {
      this.suppliers = response;
      this.showOrderSpinner = false;
    }, (error) =>
      {
        console.log(error);
      });

    this.rawMaterialsService.GetAllRawMaterials().subscribe((response) =>
    {
      this.rawMaterials = response;
    }, (error) =>
      {
        console.log(error);
      });
  }


  onAddSupplierClick(event)
  {
    this.newOrderForm["submitted"] = true;
    if (this.newOrderForm.valid)
    {
      this.newOrderDisabled = true;
      var order: Order = this.newOrderForm.value;

      this.ordersService.AddOrder(order).subscribe((addResponse) =>
      {
        this.newOrderForm.reset();
        $("#btnAddOrderCancel").trigger("click");
        this.newOrderDisabled = false;
        this.showOrderSpinner = true;
        this.newOrderForm.reset();
      }, (error) =>
      {
        console.log(error);
        });
    }
    else
    {
      super.getFormGroupErrors(this.newOrderForm);
    }
  }
}



