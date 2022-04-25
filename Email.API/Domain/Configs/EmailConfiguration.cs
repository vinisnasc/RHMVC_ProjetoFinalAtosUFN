namespace Email.Domain.Configs
{
    public class EmailConfiguration
    {
        public string Remetente { get; set; }
        public string SmtpServer { get; set; }
        public int Porta { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public string DiretorioLocal { get; set; }
    }
}
