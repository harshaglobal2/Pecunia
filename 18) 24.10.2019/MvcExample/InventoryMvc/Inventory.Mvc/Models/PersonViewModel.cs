using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Inventory.Mvc.Models
{
    public class PersonViewModel
    {
        public System.Guid PersonID { get; set; }

        [Required(ErrorMessage = "Person Name can't be blank")]
        [RegularExpression("^[A-Za-z ]*$", ErrorMessage = "Person Name should contain alphabets only")]
        public string PersonName { get; set; }

        [Required(ErrorMessage = "Email can't be blank")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Email is invalid")]
        public string Email { get; set; }

        [Range(18, 70)]
        public Nullable<int> Age { get; set; }

        public Nullable<System.DateTime> DateOfJoining { get; set; }

        public string Gender { get; set; }

        public bool IsRegistered { get; set; }

        public string State { get; set; }
    }
}

