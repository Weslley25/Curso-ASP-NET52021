using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RecursosCebraspe.Models;
using RecursosCebraspe.Service;


namespace RecursosCebraspe.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class PessoaController : ControllerBase
    {
        

        private readonly ILogger<PessoaController> _logger;
        private readonly IPessoaService _pessoaService;

        public PessoaController(ILogger<PessoaController> logger, IPessoaService pessoaService)
        {
            _logger = logger;
            _pessoaService = pessoaService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_pessoaService.FindAll());
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var pessoa = _pessoaService.FindById(id);
            if (pessoa == null) return NotFound("Não existe pessoa para o id:"+id);
            return Ok(pessoa);
        }

        [HttpPost]
        public ActionResult Post([FromBody] Pessoa pessoa)
        {
            if (pessoa == null) return BadRequest();
            var person =  _pessoaService.Create(pessoa);
            return Ok(person);
        }
        [HttpPut]
        public ActionResult Put([FromBody] Pessoa pessoa)
        {
            var consultapessoa = _pessoaService.FindById(pessoa.ID);
            if (consultapessoa == null)
            {
                return NotFound("Não existe pessoa para o id:" + pessoa.ID);
            }
            return Ok(_pessoaService.Update(pessoa));
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
           var pessoa = _pessoaService.FindById(id);
            if (pessoa == null)
            {
                return NotFound("Não existe pessoa para o id:" + id);
            }
            _pessoaService.delete(id);
            return NoContent();
        }

    }
}
