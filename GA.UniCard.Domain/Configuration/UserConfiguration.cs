using GA.UniCard.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GA.UniCard.Domain.Configuration
{
    /// <summary>
    /// Configuration for the User entity using Entity Framework Core.
    /// </summary>
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        /// <summary>
        /// Configures the User entity.
        /// </summary>
        /// <param name="builder">The entity type builder used to configure the entity.</param>
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Seed data for Users
            builder.HasData(
                new User() { Id = 1, Email = "Aapkhazava22@gmail.com", Password = "Guga123", UserName = "Guga123#",PersonId="1" },
                new User() { Id = 2, Email = "Guga342@gmail.com", Password = "Gaga1234", UserName = "Guga13guga##", PersonId = "2" },
                new User() { Id = 3, Email = "Aapkhazava22@gmail.com", Password = "Giga12346$", UserName = "Guga123#",PersonId= "3" },
                new User() { Id = 4, Email = "NikaArtmeladze@gmail.com", Password = "Guga%34", UserName = "Guga123#",PersonId="4"},
                new User() { Id = 5, Email = "Giorgi123@gmail.com", Password = "Giorgi324", UserName = "Guga123#",PersonId = "5" },
                new User() { Id = 6, Email = "UniPayAdmin@gmail.com", Password = "Admin", UserName = "Admin#", PersonId = "6" },
                new User() { Id = 7, Email = "Aapkhazava2200@gmail.com", Password = "User4562", UserName = "User#", PersonId = "7" }
            );
        }
    }
}
