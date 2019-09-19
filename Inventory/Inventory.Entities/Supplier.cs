using System;
using System.Collections.Generic;
using System.Linq;
using Capgemini.Inventory.Helpers.ValidationAttributes;

namespace Capgemini.Inventory.Entities
{
    /// <summary>
    /// Interface for Supplier Entity
    /// </summary>
    public interface ISupplier
    {
        Guid SupplierID { get; set; }
        string SupplierName { get; set; }
        string SupplierMobile { get; set; }
        string SupplierEmail { get; set; }
        string SupplierPassword { get; set; }
        DateTime CreationDateTime { get; set; }
        DateTime LastModifiedDateTime { get; set; }
    }

    /// <summary>
    /// Represents Supplier
    /// </summary>
    public class Supplier : ISupplier
    {
        /* Auto-Implemented Properties */
        [Required("Supplier ID can't be blank.")]
        public Guid SupplierID { get; set; }

        [Required("Supplier Name can't be blank.")]
        public string SupplierName { get; set; }

        [RegExp(@"^[6789]\d{9}$", "Mobile number should contain 10 digits")]
        public string SupplierMobile { get; set; }

        [Required("Email can't be blank.")]
        [RegExp(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", "Email is invalid.")]
        public string SupplierEmail { get; set; }

        [Required("Password can't be blank.")]
        [RegExp(@"((?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,15})", "Password should be 6 to 15 characters with at least one digit, one uppercase letter, one lower case letter.")]
        public string SupplierPassword { get; set; }

        public DateTime CreationDateTime { get; set; }
        public DateTime LastModifiedDateTime { get; set; }

        /* Constructor */
        public Supplier()
        {
            SupplierID = default(Guid);
            SupplierName = null;
            SupplierMobile = null;
            SupplierEmail = null;
            SupplierPassword = null;
            CreationDateTime = default(DateTime);
            LastModifiedDateTime = default(DateTime);
        }
    }
}



