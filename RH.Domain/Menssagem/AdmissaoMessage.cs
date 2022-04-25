using MessageBus;

namespace RH.Domain.Menssagem
{
    public class AdmissaoMessage : BaseMessage
    {
        public int Registro { get; set; }
        public string Nome { get; set; }
        public string Funcao { get; set; }
        public string Departamento { get; set; }
        public string Email { get; set; }
        public string AssuntoEmail { get; set; }
    }
}