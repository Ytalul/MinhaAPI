using Microsoft.EntityFrameworkCore;
using MinhaAPI.Data;
using MinhaAPI.Models;
using MinhaAPI.Repositories.Interfaces;

namespace MinhaAPI.Repositories
{
    public class TarefaRepositorio : ITarefaRepositorio
    {
        private readonly BancoContext _contexto; 
        public TarefaRepositorio(BancoContext contexto)
        {
            _contexto = contexto;
        }
        public async Task<List<TarefaModel>> ListarTodas()
        {
            return await _contexto.Tarefas
                .Include(tarefa => tarefa.Usuario)
                .ToListAsync();
        }

        public async Task<TarefaModel> ProcurarPorId(int id)
        {
            TarefaModel tarefa = await _contexto.Tarefas
                .Include(tarefa => tarefa.Usuario)
                .FirstOrDefaultAsync(tarefaa => tarefaa.Id == id);
            return tarefa;
        }
        public async Task<TarefaModel> AdicionarTarefa(TarefaModel tarefa)
        {
            await _contexto.Tarefas.AddAsync(tarefa);
            _contexto.SaveChanges();
            return tarefa;
        }
        public async Task<TarefaModel> AtualizarTarefa(int id, TarefaModel tarefa)
        {
            TarefaModel tarefadb = await ProcurarPorId(id);
            if ( tarefadb == null )
            {
                throw new Exception($"Tarefa de ID={id} não encontrada.");
            }
            tarefadb.Nome = tarefa.Nome;
            tarefadb.Descrição = tarefa.Descrição;
            tarefadb.UsuarioId = tarefa.UsuarioId;
            tarefadb.Status = tarefa.Status;
            _contexto.Tarefas.Update(tarefadb);
            await _contexto.SaveChangesAsync();
            return tarefadb;
        }
        public async Task<bool> ApagarTarefa(int id)
        {
            TarefaModel Removertarefa = await ProcurarPorId(id);
            if ( Removertarefa == null )
            {
                throw new Exception($"Tarefa de ID={id} não encontrada.");
            }
            _contexto.Tarefas.Remove(Removertarefa);
            await _contexto.SaveChangesAsync();
            return true;

        }
    }
}
