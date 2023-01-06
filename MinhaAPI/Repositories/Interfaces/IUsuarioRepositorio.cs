using MinhaAPI.Models;

namespace MinhaAPI.Repositories.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<List<UsuarioModel>> ListarTodos();
        Task<UsuarioModel> ProcurarPorId(int id);
        Task<UsuarioModel> AdicionarUsuario(UsuarioModel usuario);
        Task<UsuarioModel> AtualizarUsuario(int id, UsuarioModel usuario);
        Task<bool> ApagarUsuario(int id);
    }
}
