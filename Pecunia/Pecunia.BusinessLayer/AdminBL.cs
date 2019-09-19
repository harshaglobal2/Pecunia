using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pecunia.Entities;
using Pecunia.Exceptions;
using Pecunia.DataAccessLayer;

namespace Pecunia.BusinessLayer
{
    public class AdminBL
    {
        public bool ValidateAdmin(Admin admin)
        {
            StringBuilder sb = new StringBuilder();
            bool validAdmin = true;
            if (admin.AdminID <= 0)
            {
                validAdmin = false;
                sb.Append(Environment.NewLine + "Invalid Admin ID");

            }
            if (admin.AdminPassword == string.Empty)
            {
                validAdmin = false;
                sb.Append(Environment.NewLine + "Admin Password Required");

            }

            if (validAdmin == false)
                throw new PecuniaException(sb.ToString());
            return validAdmin;
        }

        public static bool AdminLogInBL(Admin admin)
        {
            bool adminLoggedIn = false;
            try
            {
                AdminDAL adminDAL = new AdminDAL();
                adminLoggedIn = adminDAL.AdminLogInDAL(admin);
            }
            catch (Exception ex)
            {

                throw new PecuniaException(ex.Message);
            }

            return adminLoggedIn;
        }
    }
}
