using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pecunia.Entities
{
    public class Admin
    {
        private int adminID = 101;
        public int AdminID
        {
            get { return adminID; }
            set { adminID = value; }
        }

        private string adminPassword = " ";
        public string AdminPassword
        {
            get { return adminPassword; }
            set { adminPassword = value; }
        }

    }
}
