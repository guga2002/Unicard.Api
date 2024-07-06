using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace GA.UniCard.Domain.Entities
{
    /// <summary>
    /// Represents a user entity.
    /// </summary>
    [Table("Users")]
    public class User : AbstractEntity
    {
        /// <summary>
        /// Gets or sets the username of the user.
        /// </summary>
        [Column("User_Name")]
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the password of the user.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the email address of the user.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Foreign Key for Assign Identity User
        /// </summary>
        [ForeignKey("Person")]
        public string PersonId { get; set; }

        /// <summary>
        /// Navigation property to IdentityUser
        /// </summary>
        public Person Person { get; set; }

        /// <summary>
        /// Navigation property to the orders placed by this user.
        /// </summary>
        public virtual IEnumerable<Order> Orders { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        public User()
        {
            Orders = new List<Order>();
        }
    }
}
