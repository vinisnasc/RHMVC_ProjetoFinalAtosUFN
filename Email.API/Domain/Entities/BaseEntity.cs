using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Email.API.Domain.Entities
{
    public class BaseEntity
    {
        [BsonId]
        public Guid Id { get; set; }
    }
}
