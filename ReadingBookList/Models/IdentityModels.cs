using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace ReadingBookList.Models
{

    /// <summary>
    /// ApplicaitonUser is a class for user identity
    /// </summary>
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        /// <summary>
        /// The Books property represents user's collection of Book.
        /// </summary>
        /// <value>The Books property gets/sets the value of the List<Book></value>
        //navigation property
        public virtual List<Book> Books { get; set; }

        /// <summary>
        /// The GenerateUserIdentityAsync property represents the creation of user's identity
        /// </summary>
        /// <param name="manager"></param>
        /// <returns>typeof(Task<ClaimsIdentity>)</ClaimsIdentity>)</returns>
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    /// <summary>
    /// ApplicationDBContext class that uses the entity types for ASP.NET Identity User, Roles, Claims, Logins. 
    /// also responsible for the database queries
    /// Use this overload to add your own entity types
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        /// <summary>
        /// Constructs a new ApplicationDBContext instance
        /// </summary>
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        /// <summary>
        /// Create statice method used to create an ApplicationDBContext
        /// </summary>
        /// <returns>typeof(ApplicationDBContext)</Books></returns>
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        /// <summary>
        /// The Books property represents the collection of books.
        /// </summary>
        /// <value>The Books property gets/sets the value of the string DbSet<ReadingBookList.Models.Book></value>
        public System.Data.Entity.DbSet<ReadingBookList.Models.Book> Books { get; set; }
   
    }
}