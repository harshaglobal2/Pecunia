using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Capgemini.Inventory.Entities;
using Capgemini.Inventory.Helpers;

namespace Capgemini.Inventory.PresentationLayer
{
    public static class CommonData
    {
        public static IUser CurrentUser { get; set; }
        public static UserType CurrentUserType { get; set; }
    }
}



