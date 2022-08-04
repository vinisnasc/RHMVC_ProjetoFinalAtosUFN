namespace RH.Domain.Entities
{
    public class Departamento : BaseEntity
    {
        public string NomeDepartamento { get; set; }
        public string SubDepartamento { get; set; }
        public IEnumerable<Funcionario> Funcionarios { get; set; }

        public override string ToString()
        {
            return $"{NomeDepartamento} / {SubDepartamento}";
        }
    }
}