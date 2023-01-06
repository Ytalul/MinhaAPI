using Microsoft.AspNetCore.Mvc;
using MinhaAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MinhaAPI.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        // GET: api/<UsuarioController>
        [HttpGet]
        public ActionResult<List<UsuarioModel>> BuscarTodosUsuarios()  // nome do endpoint
        {
            return Ok();
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]   // isto é um verbo    e o método é um end point
        public string Get(int id)
        {
            return ;
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
