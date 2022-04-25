using System.ComponentModel.DataAnnotations;

namespace Estoque.Domain.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; set; } = new Guid();
    }
}
