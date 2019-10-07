export class OrderDetal
{
  id: number;
  orderDetaiID: string;
  orderID: string;
  rawMaterialID: string;
  quantity: number;
  unitPrice: number;
  totalAmount: number;
  creationDateTime: string;
  lastModifiedDateTime: string;

  constructor(ID: number, OrderDetailID: string, OrderID: string, RawMaterialID: string, Quantity: number, UnitPrice: number, TotalAmount: number, CreationDateTime: string, LastModifiedDateTime: string)
  {
    this.id = ID;
    this.orderDetaiID = OrderDetailID;
    this.orderID = OrderID;
    this.rawMaterialID = RawMaterialID;
    this.quantity = Quantity;
    this.unitPrice = UnitPrice;
    this.totalAmount = TotalAmount;
    this.creationDateTime = CreationDateTime;
    this.lastModifiedDateTime = LastModifiedDateTime;
  }
}


