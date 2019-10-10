export class Supplier
{
  id: number;
  supplierID: string;
  supplierName: string;
  supplierMobile: string;
  email: string;
  password: string;
  creationDateTime: string;
  lastModifiedDateTime: string;

  constructor(ID: number, SupplierID: string, SupplierName: string, SupplierMobile: string, Email: string, Password: string, CreationDateTime: string, LastModifiedDateTime: string)
  {
    this.id = ID;
    this.supplierID = SupplierID;
    this.supplierName = SupplierName;
    this.supplierMobile = SupplierMobile;
    this.email = Email;
    this.password = Password;
    this.creationDateTime = CreationDateTime;
    this.lastModifiedDateTime = LastModifiedDateTime;
  }
}


