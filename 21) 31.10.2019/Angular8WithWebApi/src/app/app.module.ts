import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { HttpClientModule } from '@angular/common/http';
import { HttpClientInMemoryWebApiModule } from 'angular-in-memory-web-api';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { AboutComponent } from './about/about.component';
import { InventoryDataService } from './FakeBackends/inventory-data.service';
import { AdminModule } from './AdminModule/admin.module';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    AboutComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule,
    AdminModule,
    //HttpClientInMemoryWebApiModule.forRoot(InventoryDataService, { delay: 1000 })
  ],
  bootstrap: [AppComponent]
})
export class AppModule
{
}
