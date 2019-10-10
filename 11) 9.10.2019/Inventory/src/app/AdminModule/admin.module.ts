import { NgModule } from "@angular/core";
import { SuppliersComponent } from './suppliers/suppliers.component';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { AdminRoutingModule } from './admin-routing.module';
import { AdminHomeComponent } from './admin-home/admin-home.component';

@NgModule({
  declarations: [
    AdminHomeComponent,
    SuppliersComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    HttpClientModule,
    AdminRoutingModule
  ],
  exports: [
    SuppliersComponent
  ]
})
export class AdminModule
{
}


