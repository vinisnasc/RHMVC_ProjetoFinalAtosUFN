namespace WEBAPP.MVC.Models
{
    public class FuncionarioFuncaoModel
    {
        public int Registro { get; set; }
        public string Nome { get; set; }
        public string Departamento { get; set; }
        public FuncaoModel Funcao { get; set; }
        public Guid FuncaoId { get; set; }
        public Guid DepartamentoId { get; set; }
    }
}
