import { Injectable } from '@angular/core';
import { InMemoryDbService } from 'angular-in-memory-web-api';
import { Supplier } from '../Models/supplier';
import { Admin } from '../Models/admin';

@Injectable({
  providedIn: 'root'
})
export class InventoryDataService implements InMemoryDbService
{
  constructor() { }

  createDb()
  {
    let admins = [
      new Admin('101', 'Admin', 'admin@capgemini.com', 'manager')
    ];

    let suppliers = [
      new Supplier("401476EE-0A3B-482E-BD5B-B94A32355959", "Scott", "9876543210", "scott@capgemini.com", "Scott123#", "10/3/2019 3:40 PM", "10/4/2019 4:10 PM"),
      new Supplier("C628855C-FE7A-4D94-A1BB-167157D3F4EA", "Smith", "9988776655", "smith@capgemini.com", "Smith123#", "9/6/2019 3:40 PM", "5/7/2019 11:20 AM")
    ];

    return { admins, suppliers };
  }
}


