using MinhaAPI.Models;

namespace MinhaAPI.Repositories.Interfaces
{
    public interface ITarefaRepositorio
    {
        Task<List<TarefaModel>> ListarTodas();
        Task<TarefaModel> ProcurarPorId(int id);
        Task<TarefaModel> AdicionarTarefa(TarefaModel tarefa);
        Task<TarefaModel> AtualizarTarefa(int id, TarefaModel tarefa);
        Task<bool> ApagarTarefa(int id);
    }
}
