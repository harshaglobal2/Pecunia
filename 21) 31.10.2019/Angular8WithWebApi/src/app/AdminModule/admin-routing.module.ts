import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SuppliersComponent } from './suppliers/suppliers.component';
import { AdminHomeComponent } from './admin-home/admin-home.component';
import { PersonsComponent } from './persons/persons.component';

const routes: Routes = [
  { path: "home", component: AdminHomeComponent },
  { path: "suppliers", component: SuppliersComponent },
  { path: "persons", component: PersonsComponent },
  { path: "**", redirectTo: '/suppliers', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }


