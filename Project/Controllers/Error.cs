namespace Project.Controllers
{
    internal class Error
    {
        public Error(string erro, string mensagem)
        {
            Erro = erro;
            Mensagem = mensagem;
        }
        public string Erro { get; set; }
        public string Mensagem { get; set; }
    }
}