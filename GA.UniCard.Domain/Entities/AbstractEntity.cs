using System.ComponentModel.DataAnnotations;

namespace GA.UniCard.Domain.Entities
{
    /// <summary>
    /// Abstract base class for entities with a primary key Id.
    /// </summary>
    public abstract class AbstractEntity
    {
        /// <summary>
        /// Gets or sets the primary key Id of the entity.
        /// </summary>
        [Key]
        public virtual long Id { get; set; }
    }
}
