import { Injectable } from '@angular/core';
import { InMemoryDbService } from 'angular-in-memory-web-api';
import { Admin } from '../Models/Admin';
import { Supplier } from '../Models/supplier';

@Injectable({
  providedIn: 'root'
})
export class InventoryDataService implements InMemoryDbService
{
  constructor() { }

  createDb()
  {
    let admins = [
      new Admin(1, '101', 'Admin', 'admin@capgemini.com', 'manager')
    ];

    let suppliers = [
      new Supplier(1, "072C055A-93B7-4DC8-B920-C52F5B8E05C2", "Scott", "9876543210", "scott@capgemini.com", "Scott123#", "10/3/2019", "10/4/2019"),
      new Supplier(2, "C628855C-FE7A-4D94-A1BB-167157D3F4EA", "Smith", "9988776655", "smith@capgemini.com", "Smith123#", "9/6/2019", "5/7/2019"),
      new Supplier(3, "6D68849C-8FA8-4049-A111-B431C76C6548", "Arun", "7781994834", "arun@capgemini.com", "Arun123#", "1/5/2017", "15/11/2018"),
      new Supplier(4, "53E8748F-61D6-494B-BF72-E18B27511EFA", "Jones", "6989493491", "jones@capgemini.com", "Jones123#", "2/7/2019", "12/1/2019")
    ];
    
    return { admins, suppliers };
  }
}


