export class Supplier
{
  supplierID: string;
  supplierName: string;
  supplierMobile: string;
  email: string;
  password: string;
  creationDateTime: string;
  lastModifiedDateTime: string;

  constructor(SupplierID: string, SupplierName: string, SupplierMobile: string, Email: string, Password: string, CreationDateTime: string, LastModifiedDateTime: string)
  {
    this.supplierID = SupplierID;
    this.supplierName = SupplierName;
    this.supplierMobile = SupplierMobile;
    this.email = Email;
    this.password = Password;
    this.creationDateTime = CreationDateTime;
    this.lastModifiedDateTime = LastModifiedDateTime;
  }
}


