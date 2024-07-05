using System.ComponentModel.DataAnnotations.Schema;

namespace GA.UniCard.Domain.Entitites
{
    [Table("Users")]
    public class User:AbstractEntity
    {
        [Column("User_Name")]
        public required string UserName { get; set; }

        public required string Password { get; set; }

        public required string Email { get; set; }

        public virtual IEnumerable<Order> Orders { get; set; }
        public User()
        {
            Orders = new List<Order>();
        }
    }
}
