import { Injectable } from '@angular/core';
import { InMemoryDbService } from 'angular-in-memory-web-api';
import { Supplier } from '../Models/supplier';
import { Admin } from '../Models/admin';
import { RawMaterial } from '../Models/raw-material';

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
      new Supplier(1, "401476EE-0A3B-482E-BD5B-B94A32355959", "Scott", "9876543210", "scott@capgemini.com", "Scott123#", "10/3/2019", "10/4/2019"),
      new Supplier(2, "C628855C-FE7A-4D94-A1BB-167157D3F4EA", "Smith", "9988776655", "smith@capgemini.com", "Smith123#", "9/6/2019", "5/7/2019"),
      new Supplier(3, "6D68849C-8FA8-4049-A111-B431C76C6548", "Arun", "7781994834", "arun@capgemini.com", "Arun123#", "1/5/2017", "15/11/2018"),
      new Supplier(4, "53E8748F-61D6-494B-BF72-E18B27511EFA", "Jones", "6989493491", "jones@capgemini.com", "Jones123#", "2/7/2019", "12/1/2019")
    ];

    let rawmaterials = [
      new RawMaterial(1, "5D3034E3-ED22-4C24-9D2B-EEE4B187058E", "APP", "Apple", 20, "3/7/2012", "8/9/2019"),
      new RawMaterial(2, "ED3DCF6D-1A93-4F94-B91C-18546B04DB34", "SUG", "Sugar", 180, "8/1/2002", "8/9/2003"),
      new RawMaterial(3, "59D6BD5D-9B05-435F-80DF-74647301B835", "CIT", "Citric Acid", 17, "12/10/2009", "8/9/2017"),
      new RawMaterial(4, "E58BCC33-A90D-43B5-B365-D51CEA3B2A82", "BAN", "Banana", 12, "21/9/2010", "8/9/2018")
    ];

    let orders = [];

    let orderdetails = [];

    return { admins, suppliers, rawmaterials, orders, orderdetails };
  }
}


