using System.ComponentModel;

namespace MinhaAPI.Models
{
    public enum StatusTarefa
    {
        [Description("A fazer")]
        AFazer = 1,
        [Description("Em andamento")]
        EmAndamento = 2,
        [Description("Concluida")]
        Concluida = 3
    }
    public class TarefaModel
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Descrição { get; set; }
        public StatusTarefa Status { get; set; }
        public int? UsuarioId {get; set;}
        public virtual UsuarioModel? Usuario {get; set;}
    }
}
