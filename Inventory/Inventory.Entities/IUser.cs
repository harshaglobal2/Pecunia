using System;
using System.Collections.Generic;

namespace Capgemini.Inventory.Entities
{
    public interface IUser
    {
        string Email { get; set; }
        string Password { get; set; }
    }
}



