using Microsoft.AspNetCore.Mvc;
using MinhaAPI.Models;
using MinhaAPI.Repositories.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MinhaAPI.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepositorio _repositorio;
        public UsuarioController(IUsuarioRepositorio repositorio)
        {
            _repositorio = repositorio;
        }
        // GET: api/<UsuarioController>
        [HttpGet]
        public async Task<ActionResult<List<UsuarioModel>>> BuscarTodosUsuarios()  // nome do endpoint
        {
            List<UsuarioModel> usuarios = await  _repositorio.ListarTodos();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioModel>> ProcurarUsuario(int id)
        {
            UsuarioModel usuario = await _repositorio.ProcurarPorId(id);
            if (usuario == null)
            {
                return Ok(new ErrorMessage(403, "Usuario Não encontrado"));
            }
            else { return Ok(usuario);  }
            
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioModel>> Adicionar([FromBody]UsuarioModel usuario)
        {
            if ( ModelState.IsValid)
            {
                usuario.Id = 0;
                UsuarioModel user = await _repositorio.AdicionarUsuario(usuario);
                return Ok(user);
            }
            else { return Ok(new ErrorMessage(403, "Usuário inválido para adicionar, preencha os campos corretamente.")); }
            
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UsuarioModel>> Atualizar(int id, [FromBody] UsuarioModel usuario)
        {
            if ( ModelState.IsValid)
            {
                UsuarioModel user = await _repositorio.AtualizarUsuario(id, usuario);
                return Ok(user);
            }

            else { return Ok(new ErrorMessage(403, "Usuário inválido para atualizar, preencha os campos corretamente.")); }
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> ExcluirUsuario(int id)
        {
            bool resposta = await _repositorio.ApagarUsuario(id);
            if ( resposta == false)
            {
                return Ok(new ErrorMessage(401, $"Usuário de Id {id} não encontrado."));
            }
            else
            {
                return Ok(true);
            }
            
        }
    }
}
