using System;
using System.Collections.Generic;
using System.Linq;
using Capgemini.Inventory.Helpers.ValidationAttributes;

namespace Capgemini.Inventory.Entities
{
    /// <summary>
    /// Interface for Admin Entity
    /// </summary>
    public interface IAdmin
    {
        Guid AdminID { get; set; }
        string AdminName { get; set; }
        string Email { get; set; }
        string Password { get; set; }
        DateTime CreationDateTime { get; set; }
        DateTime LastModifiedDateTime { get; set; }
    }

    /// <summary>
    /// Represents Admin
    /// </summary>
    public class Admin : IAdmin, IUser
    {
        /* Auto-Implemented Properties */
        [Required("Admin ID can't be blank.")]
        public Guid AdminID { get; set; }

        [Required("Admin Name can't be blank.")]
        [RegExp(@"^(\w{2,40})$", "Admin Name should contain only 2 to 40 characters.")]
        public string AdminName { get; set; }

        [Required("Email can't be blank.")]
        [RegExp(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", "Email is invalid.")]
        public string Email { get; set; }

        [Required("Password can't be blank.")]
        [RegExp(@"((?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,15})", "Password should be 6 to 15 characters with at least one digit, one uppercase letter, one lower case letter.")]
        public string Password { get; set; }

        public DateTime CreationDateTime { get; set; }
        public DateTime LastModifiedDateTime { get; set; }

        /* Constructor */
        public Admin()
        {
            AdminID = default(Guid);
            AdminName = null;
            Email = null;
            Password = null;
            CreationDateTime = default(DateTime);
            LastModifiedDateTime = default(DateTime);
        }
    }
}



