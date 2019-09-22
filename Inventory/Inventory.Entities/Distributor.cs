using System;
using System.Collections.Generic;
using System.Linq;
using Capgemini.Inventory.Helpers.ValidationAttributes;

namespace Capgemini.Inventory.Entities
{
    /// <summary>
    /// Interface for Distributor Entity
    /// </summary>
    public interface IDistributor
    {
        Guid DistributorID { get; set; }
        string DistributorName { get; set; }
        string DistributorMobile { get; set; }
        string Email { get; set; }
        string Password { get; set; }
        DateTime CreationDateTime { get; set; }
        DateTime LastModifiedDateTime { get; set; }
    }

    /// <summary>
    /// Represents Distributor
    /// </summary>
    public class Distributor : IDistributor, IUser
    {
        /* Auto-Implemented Properties */
        [Required("Distributor ID can't be blank.")]
        public Guid DistributorID { get; set; }

        [Required("Distributor Name can't be blank.")]
        [RegExp(@"^(\w{2,40})$", "Distributor Name should contain only 2 to 40 characters.")]
        public string DistributorName { get; set; }

        [RegExp(@"^[6789]\d{9}$", "Mobile number should contain 10 digits")]
        public string DistributorMobile { get; set; }

        [Required("Email can't be blank.")]
        [RegExp(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", "Email is invalid.")]
        public string Email { get; set; }

        [Required("Password can't be blank.")]
        [RegExp(@"((?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,15})", "Password should be 6 to 15 characters with at least one digit, one uppercase letter, one lower case letter.")]
        public string Password { get; set; }

        public DateTime CreationDateTime { get; set; }
        public DateTime LastModifiedDateTime { get; set; }

        /* Constructor */
        public Distributor()
        {
            DistributorID = default(Guid);
            DistributorName = null;
            DistributorMobile = null;
            Email = null;
            Password = null;
            CreationDateTime = default(DateTime);
            LastModifiedDateTime = default(DateTime);
        }
    }
}



