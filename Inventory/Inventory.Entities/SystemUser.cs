using System;
using System.Collections.Generic;
using System.Linq;
using Capgemini.Inventory.Helpers.ValidationAttributes;

namespace Capgemini.Inventory.Entities
{
    /// <summary>
    /// Interface for SystemUser Entity
    /// </summary>
    public interface ISystemUser
    {
        Guid SystemUserID { get; set; }
        string SystemUserName { get; set; }
        string Email { get; set; }
        string Password { get; set; }
        DateTime CreationDateTime { get; set; }
        DateTime LastModifiedDateTime { get; set; }
    }

    /// <summary>
    /// Represents SystemUser
    /// </summary>
    public class SystemUser : ISystemUser, IUser
    {
        /* Auto-Implemented Properties */
        [Required("SystemUser ID can't be blank.")]
        public Guid SystemUserID { get; set; }

        [Required("SystemUser Name can't be blank.")]
        [RegExp(@"^(\w{2,40})$", "SystemUser Name should contain only 2 to 40 characters.")]
        public string SystemUserName { get; set; }

        [Required("Email can't be blank.")]
        [RegExp(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", "Email is invalid.")]
        public string Email { get; set; }

        [Required("Password can't be blank.")]
        [RegExp(@"((?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,15})", "Password should be 6 to 15 characters with at least one digit, one uppercase letter, one lower case letter.")]
        public string Password { get; set; }

        public DateTime CreationDateTime { get; set; }
        public DateTime LastModifiedDateTime { get; set; }

        /* Constructor */
        public SystemUser()
        {
            SystemUserID = default(Guid);
            SystemUserName = null;
            Email = null;
            Password = null;
            CreationDateTime = default(DateTime);
            LastModifiedDateTime = default(DateTime);
        }
    }
}



