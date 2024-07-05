using GA.UniCard.Domain.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GA.UniCard.Domain.Configuration
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new User() { Id=1,Email = "Aapkhazava22@gmail.com", Password = "Guga123", UserName = "Guga123#" },
                new User() { Id=2,Email = "Guga342@gmail.com", Password = "Gaga1234", UserName = "Guga13guga##" },
                new User() { Id=3,Email = "Aapkhazava22@gmail.com", Password = "Giga12346$", UserName = "Guga123#" },
                new User() { Id=4,Email = "NikaArtmeladze@gmail.com", Password = "Guga%34", UserName = "Guga123#" },
                new User() { Id=5,Email = "Giorgi123@gmail.com", Password = "Giorgi324", UserName = "Guga123#" },
                new User() { Id=6,Email = "UniPayAdmin@gmail.com", Password = "Admin", UserName = "Admin#" },
                new User() { Id=7,Email = "Aapkhazava2200@gmail.com", Password = "User4562", UserName = "User#" }
                );
        }
    }
}
