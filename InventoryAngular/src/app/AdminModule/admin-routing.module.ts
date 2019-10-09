import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminHomeComponent } from './admin-home/admin-home.component';
import { SuppliersComponent } from './suppliers/suppliers.component';
import { NewOrderComponent } from './new-order/new-order.component';

const routes: Routes = [
  { path: "home", component: AdminHomeComponent },
  { path: "suppliers", component: SuppliersComponent },
  { path: "neworder", component: NewOrderComponent },
  { path: "**", redirectTo: '/home', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }


