using RH.Domain.Validations;

namespace RH.Domain.Entities
{
    public class Departamento : BaseEntity
    {
        public string NomeDepartamento { get; set; }
        public string SubDepartamento { get; set; }
        public IEnumerable<Funcionario> Funcionarios { get; set; }

        public Departamento() { }

        public Departamento(string nome, string subDepartamento)
        {
            NomeDepartamento = nome;
            SubDepartamento = subDepartamento;

            Validar();
        }

        public override string ToString()
        {
            return $"{NomeDepartamento} / {SubDepartamento}";
        }

        public void Validar()
        {
            AssertionConcern.ValidarSeVazio(NomeDepartamento, "O campo NomeDepartamento da categoria nao deve ser vazio");
            AssertionConcern.ValidarCaracteres(NomeDepartamento, 3, 100, "O campo NomeDepartamento deve ter entre 3 e 100 caracteres");
        }
    }
}