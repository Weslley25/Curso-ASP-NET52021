using RecursosCebraspe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using RecursosCebraspe.Models.Context;

namespace RecursosCebraspe.Service.implementation
{
    public class PessoaServiceImplementation : IPessoaService
    {
        private SQLContext _context;
        public PessoaServiceImplementation(SQLContext context)
        {
            _context = context;
        }
        

        public Pessoa Create(Pessoa pessoa)
        {
            return pessoa;
        }

        public void delete(int id)
        {
            
        }

        public List<Pessoa> FindAll()
        {
            var listpessoas = _context.Pessoas.ToList();
            return listpessoas;
        }

        

        public Pessoa FindById(int id)
        {
            return new Pessoa
            {
               
            };
        }

        public Pessoa Update(Pessoa pessoa)
        {
            return pessoa;
        }       
    }
}
