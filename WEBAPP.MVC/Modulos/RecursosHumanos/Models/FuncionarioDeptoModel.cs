namespace WEBAPP.MVC.Modulos.RecursosHumanos.Models
{
    public class FuncionarioDeptoModel
    {
        public int Registro { get; set; }
        public string Nome { get; set; }
        public string Funcao { get; set; }
        public DepartamentoModel Departamento { get; set; }
        public Guid FuncaoId { get; set; }
        public Guid DepartamentoId { get; set; }
    }
}