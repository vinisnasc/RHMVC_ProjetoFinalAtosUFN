namespace RH.Domain.Entities
{
    public class Municipio : BaseEntity
    {
        public string NomeMunicipio { get; set; }
        public Guid UfId { get; set; }
        public Uf Uf { get; set; }
        public IEnumerable<Endereco> Enderecos { get; set; }
    }
}