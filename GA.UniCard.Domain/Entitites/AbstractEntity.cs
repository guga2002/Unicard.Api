using System.ComponentModel.DataAnnotations;

namespace GA.UniCard.Domain.Entitites
{
    public abstract class AbstractEntity
    {
        [Key]
        public virtual long Id { get; set; }
    }
}
