using System.ComponentModel.DataAnnotations.Schema;

namespace Email.API.Domain.Entities
{
    public class EmailLog : BaseEntity
    {
        public string Email { get; set; }
        public string AssuntoEmail { get; set; }

        [Column("Data_de_envio")]
        public DateTime DataEnvio { get; set; }
    }
}
