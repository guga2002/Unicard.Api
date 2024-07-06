using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace GA.UniCard.Domain.Entities
{
    /// <summary>
    /// Identity User Table
    /// </summary>
    [Table("Persons")]
    public class Person:IdentityUser
    {
        /// <summary>
        /// One User Assign to one Person
        /// </summary>
        public virtual User Users { get; set; }
    }
}
