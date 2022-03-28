using System.ComponentModel.DataAnnotations;

namespace Estoque.Domain.Entities
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
    }
}
