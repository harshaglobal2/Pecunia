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
    return this.httpClient.post<boolean>(`/api/suppliers`, supplier);
  }

  UpdateSupplier(supplier: Supplier): Observable<boolean>
  {
    return this.httpClient.put<boolean>(`/api/suppliers`, supplier);
  }

  DeleteSupplier(supplierID: number): Observable<boolean>
  {
    return this.httpClient.delete<boolean>(`/api/suppliers/${supplierID}`);
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
}



