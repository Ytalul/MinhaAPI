using Microsoft.EntityFrameworkCore;
using MinhaAPI.Data;
using MinhaAPI.Models;
using MinhaAPI.Repositories.Interfaces;

namespace MinhaAPI.Repositories
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly BancoContext _contexto; 
        public UsuarioRepositorio(BancoContext contexto)
        {
            _contexto = contexto;
        }
        public async Task<List<UsuarioModel>> ListarTodos()
        {
            return await _contexto.Usuarios.ToListAsync();
        }

        public async Task<UsuarioModel> ProcurarPorId(int id)
        {
            return await _contexto.Usuarios.FirstOrDefaultAsync(user => user.Id == id);
        }
        public async Task<UsuarioModel> AdicionarUsuario(UsuarioModel usuario)
        {
            await _contexto.Usuarios.AddAsync(usuario);
            _contexto.SaveChanges();
            return usuario;
        }
        public async Task<UsuarioModel> AtualizarUsuario(int id, UsuarioModel usuario)
        {
            UsuarioModel usuariodb = await ProcurarPorId(id);
            if ( usuariodb == null )
            {
                throw new Exception($"Usuário de ID={id} não encontrado.");
            }
            usuariodb.Nome = usuario.Nome;
            usuariodb.Email = usuario.Email;
            _contexto.Usuarios.Update(usuariodb);
            await _contexto.SaveChangesAsync();
            return usuariodb;
        }
        public async Task<bool> ApagarUsuario(int id)
        {
            UsuarioModel RemoverUsuario = await ProcurarPorId(id);
            if ( RemoverUsuario == null )
            {
                throw new Exception($"Usuário de ID={id} não encontrado.");
            }
            _contexto.Usuarios.Remove(RemoverUsuario);
            await _contexto.SaveChangesAsync();
            return true;

        }
    }
}
