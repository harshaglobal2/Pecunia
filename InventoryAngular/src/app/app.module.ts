import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from "@angular/forms";

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { environment } from '../environments/environment.prod';
import { HttpClientInMemoryWebApiModule } from 'angular-in-memory-web-api';
import { AboutComponent } from './Components/about/about.component';
import { LoginComponent } from './Components/login/login.component';
import { AdminModule } from './AdminModule/admin.module';
import { InventoryDataService } from './InMemoryWebAPIServices/inventory-data.service';
import { OrdersService } from './Services/orders.service';

@NgModule({
  declarations: [
    AppComponent,
    AboutComponent,
    LoginComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientInMemoryWebApiModule.forRoot(InventoryDataService, { delay: 1000 }),
    AdminModule
  ],
  providers: [OrdersService],
  bootstrap: [AppComponent]
})
export class AppModule { }

