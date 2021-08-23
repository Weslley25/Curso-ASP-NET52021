using RecursosCebraspe.Models;
using RecursosCebraspe.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecursosCebraspe.Repository.implementation
{
    public class LivroRepositoryImplementation : ILivroRespository
    {
        public readonly SQLContext _context;

        public LivroRepositoryImplementation(SQLContext context)
        {
            _context = context;
        }

        public List<Livro> FindAll()
        {
            var listaLivro = _context.Livros.ToList();
            return listaLivro;
        }

        public Livro FindById(int id)
        {
            return _context.Livros.SingleOrDefault(l => l.Id.Equals(id));
        }

        public Livro Create(Livro livro)
        {
            try
            {
                _context.Livros.Add(livro);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            return livro;
        }

        public void delete(int id)
        {
            var livro = _context.Livros.SingleOrDefault(l => l.Id.Equals(id));
            if (livro != null)
            {
                try
                {
                    _context.Livros.Remove(livro);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public Livro Update(Livro livro)
        {
            if (!Exists(livro))
            {
                return null;
            }
            var result = _context.Livros.SingleOrDefault(l => l.Id.Equals(livro.Id));
            try
            {
                _context.Entry(result).CurrentValues.SetValues(livro);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            return livro;
        }

        public bool Exists(Livro livro)
        {
            return _context.Livros.Any(l => l.Id.Equals(livro.Id));
        }
    }
}
