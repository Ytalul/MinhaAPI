using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MinhaAPI.Models;
using MinhaAPI.Repositories.Interfaces;


namespace MinhaAPI.Controllers
{
    [Route("api/tarefa")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaRepositorio _repositorio;
        public TarefaController(ITarefaRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<TarefaModel>>> TodasTarefas()
        {
            List<TarefaModel> tarefas = await _repositorio.ListarTodas();
            if (tarefas == null)
            {
                return Ok(new ErrorMessage(403, "Não há tarefas cadastradas"));
            }
            else
            {
                return Ok(tarefas);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TarefaModel>> BuscarTarefaPorId(int id)
        {
            TarefaModel tarefa = await _repositorio.ProcurarPorId(id);
            if (tarefa == null)
            {
                return Ok(new ErrorMessage(403, $"Tarefa de Id {id} não encontrada."));
            }
            else
            {
                return Ok(tarefa);
            }
        }

        [HttpPost]
        public async Task<ActionResult<TarefaModel>> AdicionarTarefa([FromBody] TarefaModel tarefa)
        {
            tarefa.Id = 0;   
            TarefaModel tarefaADD = await _repositorio.AdicionarTarefa(tarefa);
            return Ok(tarefaADD);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TarefaModel>> AtualizarTarefa(int id,[FromBody] TarefaModel tarefa)  
        {
            if (ModelState.IsValid)
            {
                tarefa.Id = 0;
                TarefaModel tarefaATT = await _repositorio.AtualizarTarefa(id, tarefa);
                return Ok(tarefaATT);
            }
            else
            {
                return Ok(new ErrorMessage(401, "Erro ao adicionar tarefa, preencha os campos corretamente"));
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> ApagarTarefa(int id)
        {
            bool resposta = await _repositorio.ApagarTarefa(id);
            if ( resposta == false)
            {
                return Ok(new ErrorMessage(403, $"Usuário de id {id} não encontrdo para remover."));
            }
            else {
                return Ok(new ErrorMessage(200, "Usuário Excluído com sucesso"));
            }
            


        }
    }
}
