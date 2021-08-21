using RecursosCebraspe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using RecursosCebraspe.Models.Context;
using RecursosCebraspe.Repository;

namespace RecursosCebraspe.Business.implementation
{
    public class PessoaBusinessImplementation : IPessoaBusiness
    {
        private readonly IPessoaRespository _pessoaRepository;
        public PessoaBusinessImplementation(IPessoaRespository pessoaRespository)
        {
           _pessoaRepository = pessoaRespository;
           
        }
        

        public Pessoa Create(Pessoa pessoa)
        {
            return _pessoaRepository.Create(pessoa);
        }

        public void delete(int id)
        {
            _pessoaRepository.delete(id);
        }

        public List<Pessoa> FindAll()
        {
            var listpessoas = _pessoaRepository.FindAll();
            return listpessoas;
        }

        

        public Pessoa FindById(int id)
        {
            return _pessoaRepository.FindById(id);
        }

        public Pessoa Update(Pessoa pessoa)
        {
            
            
            return _pessoaRepository.Update(pessoa);
        }

        
    }
}
