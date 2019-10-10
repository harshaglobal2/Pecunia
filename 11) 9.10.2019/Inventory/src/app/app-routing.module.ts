import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from "./login/login.component";
import { AboutComponent } from "./about/about.component";

const routes: Routes = [
  { path: "login", component: LoginComponent },
  { path: "about", component: AboutComponent },
  { path: "admin", loadChildren: () => import("./AdminModule/admin.module").then(m => m.AdminModule) },
  { path: "", redirectTo: "/login", pathMatch: "full" },
  { path: "**", redirectTo: "/login" },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
