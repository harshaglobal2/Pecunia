export class Admin
{
  adminID: string;
  adminName: string;
  email: string;
  password: string;

  constructor(AdminID: string, AdminName: string, Email: string, Password: string)
  {
    this.adminID = AdminID;
    this.adminName = AdminName;
    this.email = Email;
    this.password = Password;
  }
}


