import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Order } from '../Models/order';

@Injectable()
export class OrdersService
{
  constructor(private httpClient: HttpClient)
  {
  }

  AddOrder(order: Order): Observable<boolean>
  {
    order.creationDateTime = new Date().toLocaleDateString();
    order.lastModifiedDateTime = new Date().toLocaleDateString();
    order.orderID = this.uuidv4();
    return this.httpClient.post<boolean>(`/api/orders`, order);
  }

  UpdateOrder(order: Order): Observable<boolean>
  {
    order.lastModifiedDateTime = new Date().toLocaleDateString();
    return this.httpClient.put<boolean>(`/api/orders`, order);
  }

  DeleteOrder(orderID: string, id: number): Observable<boolean>
  {
    return this.httpClient.delete<boolean>(`/api/orders/${id}`);
  }

  GetAllOrders(): Observable<Order[]>
  {
    return this.httpClient.get<Order[]>(`/api/orders`);
  }

  GetOrderByOrderID(OrderID: number): Observable<Order>
  {
    return this.httpClient.get<Order>(`/api/orders?orderID=${OrderID}`);
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



