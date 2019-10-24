using System;
using System.Collections.Generic;

namespace Inventory.Mvc.Models
{
    public class PersonViewModel
    {
        public System.Guid PersonID { get; set; }
        public string PersonName { get; set; }
        public string Email { get; set; }
        public Nullable<int> Age { get; set; }
        public Nullable<System.DateTime> DateOfJoining { get; set; }
        public string Gender { get; set; }
        public bool IsRegistered { get; set; }
        public string State { get; set; }
    }
}

