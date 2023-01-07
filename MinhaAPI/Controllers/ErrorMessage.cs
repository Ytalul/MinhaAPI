namespace MinhaAPI.Controllers
{
    public class ErrorMessage
    {
        public ErrorMessage(int id, string mensagem)
        {
            this.Id = id;
            this.Mensagem = mensagem;
        }    
        public int Id { get; set; }
        public string? Mensagem { get; set; }
    }
}
