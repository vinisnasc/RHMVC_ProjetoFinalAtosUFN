namespace RH.Domain.Entities
{
    public class Uf : BaseEntity
    {
        public string Sigla { get; set; }
        public string Nome { get; set; }
        public IEnumerable<Municipio> Municipios { get; set; }
    }
}