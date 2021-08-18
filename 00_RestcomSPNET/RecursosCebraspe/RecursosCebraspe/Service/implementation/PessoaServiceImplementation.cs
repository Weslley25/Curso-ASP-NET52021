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
            try
            {
                _context.Add(pessoa);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw ;
            }
            return pessoa;
        }

        public void delete(int id)
        {
            var result = _context.Pessoas.SingleOrDefault(p => p.ID.Equals(id));
            if (result != null)
            {
                try
                {
                    _context.Pessoas.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public List<Pessoa> FindAll()
        {
            var listpessoas = _context.Pessoas.ToList();
            return listpessoas;
        }

        

        public Pessoa FindById(int id)
        {
            return _context.Pessoas.SingleOrDefault(p => p.ID.Equals(id));
        }

        public Pessoa Update(Pessoa pessoa)
        {
            if (!Exists(pessoa))
            {
                return new Pessoa();
            }
            var result = _context.Pessoas.SingleOrDefault(p => p.ID.Equals(pessoa.ID));
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(pessoa);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            
            return pessoa;
        }

        private bool Exists(Pessoa pessoa)
        {
            return _context.Pessoas.Any(p => p.ID.Equals(pessoa.ID));
        }
    }
}
