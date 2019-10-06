export class Admin
{
  id: number;
  adminID: string;
  adminName: string;
  email: string;
  password: string;

  constructor(ID: number, AdminID: string, AdminName: string, Email: string, Password: string)
  {
    this.id = ID;
    this.adminID = AdminID;
    this.adminName = AdminName;
    this.email = Email;
    this.password = Password;
  }
}


