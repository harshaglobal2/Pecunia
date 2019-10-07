export class Order
{
  id: number;
  orderID: string;
  orderDate: string;
  supperlID: string;
  totalQuantity: number;
  totalAmount: number;
  creationDateTime: string;
  lastModifiedDateTime: string;

  constructor(ID: number, OrderID: string, OrderDate: string, SupperID: string, TotalQuantity: number, TotalAmount: number, CreationDateTime: string, LastModifiedDateTime: string)
  {
    this.id = ID;
    this.orderID = OrderID;
    this.orderDate = OrderDate;
    this.supperlID = SupperID;
    this.totalQuantity = TotalQuantity;
    this.totalAmount = TotalAmount;
    this.creationDateTime = CreationDateTime;
    this.lastModifiedDateTime = LastModifiedDateTime;
  }
}


