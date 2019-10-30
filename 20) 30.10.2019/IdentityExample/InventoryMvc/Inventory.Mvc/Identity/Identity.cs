using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Inventory.Mvc.Identity
{
    /// <summary>
    /// Represents model class for User in Asp.Net Identity
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        public string Role { get; set; }
    }

    /// <summary>
    /// Represents model class for User Role in Asp.Net Identity
    /// </summary>
    public class ApplicationRole : IdentityRole
    {
    }

    /// <summary>
    /// Represents DbContext for Entity Framework in Asp.Net Identity
    /// </summary>
    public partial class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="connectionString"></param>
        public ApplicationDbContext(string connectionString) : base(connectionString)
        {
        }

        public DbSet<ApplicationRole> ApplicationRoles { get; set; }

        /// <summary>
        /// Overriding onModelCreating method, that executes when DbSet objects are created internally
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

    /// <summary>
    /// Represents a DAL for CRUD operations on Identity Users
    /// </summary>
    public class ApplicationUserStore : UserStore<ApplicationUser>
    {
        public ApplicationUserStore(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
    }

    /// <summary>
    /// Represents a DAL for CRUD operations on Identity roles
    /// </summary>
    public class ApplicationRoleStore : RoleStore<ApplicationRole>
    {
        public ApplicationRoleStore() : base()
        {
        }
    }

    /// <summary>
    /// Represents BL for CRUD operations on Identity Users
    /// </summary>
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> userStore) : base(userStore)
        {
        }

        public static ApplicationUserManager Create(
        IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        {
            var manager = new ApplicationUserManager(
                new UserStore<ApplicationUser>(context.Get<ApplicationDbContext>()));

            return manager;
        }
    }

    /// <summary>
    /// Represents BL for CRUD operations on Identity Roles
    /// </summary>
    public class ApplicationRoleManager : RoleManager<ApplicationRole>
    {
        public ApplicationRoleManager(ApplicationRoleStore applicationRoleStore) : base(applicationRoleStore)
        {
        }
    }

    /// <summary>
    /// Represents BL for CRUD operations on Identity SignIn and Signout
    /// </summary>
    public class ApplicationSignInManager : SignInManager<ApplicationUser, string>
    {
        public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager) : base(userManager, authenticationManager)
        {
        }
    }
}



