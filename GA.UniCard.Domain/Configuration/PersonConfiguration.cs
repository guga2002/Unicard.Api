using GA.UniCard.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GA.UniCard.Domain.Configuration
{
    /// <summary>
    /// Configuration class for the Person entity in Entity Framework Core.
    /// </summary>
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        /// <summary>
        /// Configures the Person entity.
        /// </summary>
        /// <param name="builder">The builder used to configure the entity type.</param>
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasData(
                new Person() { Id = "1", Email = "GigaGiga@gmail.com", UserName = "Guga$445" },
                new Person() { Id = "2", Email = "GugaG3434uga@gmail.com", UserName = "Guga13guga#43" },
                new Person() { Id = "3", Email = "3443@gmail.com", UserName = "#3445" },
                new Person() { Id = "4", Email = "Guga4334Guga@gmail.com", UserName = "Gia3454" },
                new Person() { Id = "5", Email = "344334@gmail.com", UserName = "Gaga45454" },
                new Person() { Id = "6", Email = "GugaGu343ga@gmail.com", UserName = "Tekla$#43" },
                new Person() { Id = "7", Email = "Gug3434aGuga@gmail.com", UserName = "Tek3445" }
            );
        }
    }
}
