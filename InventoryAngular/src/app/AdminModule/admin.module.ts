import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { AdminHomeComponent } from './admin-home/admin-home.component';
import { SuppliersComponent } from './suppliers/suppliers.component';
import { AdminRoutingModule } from './admin-routing.module';
import { NewOrderComponent } from './new-order/new-order.component';

@NgModule({
  declarations: [
    AdminHomeComponent,
    SuppliersComponent,
    NewOrderComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    AdminRoutingModule
  ],
  exports: [
    AdminRoutingModule,
    AdminHomeComponent,
    SuppliersComponent,
    NewOrderComponent
  ]
})
export class AdminModule { }

