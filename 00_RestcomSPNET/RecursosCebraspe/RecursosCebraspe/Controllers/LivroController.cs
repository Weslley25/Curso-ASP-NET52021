using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RecursosCebraspe.Models;
using RecursosCebraspe.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RecursosCebraspe.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
  
    public class LivroController : ControllerBase
    {
        private readonly ILivroBussines _livroBussines;
        private readonly ILogger<LivroController> _logger;
        public LivroController(ILogger<LivroController> logger, ILivroBussines livroBussines)
        {
            _logger = logger;
            _livroBussines = livroBussines;
        }


        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_livroBussines.FindAll());
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var livro = _livroBussines.FindById(id);
            if (livro == null)
            {
                return NotFound();
            }
            return Ok(livro);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public ActionResult Post([FromBody] Livro livro)
        {
            if (livro == null)
            {
                return BadRequest();
            }
            return Ok(_livroBussines.Create(livro));
        }

        // PUT api/<ValuesController>/5
        [HttpPut]
        public ActionResult Put([FromBody]Livro livro)
        {
            
            if (livro == null)
            {
                return BadRequest();
            }
            return Ok(_livroBussines.Update(livro));
                
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var livro = _livroBussines.FindById(id);
            if (livro == null)
            {
                return NotFound();
            }
            _livroBussines.delete(id);
            return NoContent();
        }
    }
}
