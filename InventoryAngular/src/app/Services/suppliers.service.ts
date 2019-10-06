import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Supplier } from '../Models/supplier';

@Injectable({
  providedIn: 'root'
})
export class SuppliersService
{
  constructor(private httpClient: HttpClient)
  {
  }

  AddSupplier(supplier: Supplier): Observable<boolean>
  {
    supplier.creationDateTime = new Date().toLocaleDateString();
    supplier.lastModifiedDateTime = new Date().toLocaleDateString();
    supplier.supplierID = this.uuidv4();
    return this.httpClient.post<boolean>(`/api/suppliers`, supplier);
  }

  UpdateSupplier(supplier: Supplier): Observable<boolean>
  {
    supplier.lastModifiedDateTime = new Date().toLocaleDateString();
    return this.httpClient.put<boolean>(`/api/suppliers`, supplier);
  }

  DeleteSupplier(supplierID: string, id: number): Observable<boolean>
  {
    return this.httpClient.delete<boolean>(`/api/suppliers/${id}`);
  }

  GetAllSuppliers(): Observable<Supplier[]>
  {
    return this.httpClient.get<Supplier[]>(`/api/suppliers`);
  }

  GetSupplierBySupplierID(SupplierID: number): Observable<Supplier>
  {
    return this.httpClient.get<Supplier>(`/api/suppliers?supplierID=${SupplierID}`);
  }

  GetSuppliersBySupplierName(SupplierName: string): Observable<Supplier[]>
  {
    return this.httpClient.get<Supplier[]>(`/api/suppliers?supplierName=${SupplierName}`);
  }

  GetSupplierByEmail(Email: string): Observable<Supplier>
  {
    return this.httpClient.get<Supplier>(`/api/suppliers?email=${Email}`);
  }

  GetSupplierByEmailAndPassword(Email: string, Password: string): Observable<Supplier>
  {
    return this.httpClient.get<Supplier>(`/api/suppliers?email=${Email}&password=${Password}`);
  }

  uuidv4()
  {
    return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c)
    {
      var r = Math.random() * 16 | 0, v = c == 'x' ? r : (r & 0x3 | 0x8);
      return v.toString(16);
    });
  }
}



