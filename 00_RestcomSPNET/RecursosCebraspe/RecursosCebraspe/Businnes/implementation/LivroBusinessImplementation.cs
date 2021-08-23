using RecursosCebraspe.Models;
using RecursosCebraspe.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecursosCebraspe.Business.implementation
{
    public class LivroBusinessImplementation : ILivroBussines
    {
        public readonly ILivroRespository _livroRespository;

        public LivroBusinessImplementation(ILivroRespository livroRespository)
        {
            _livroRespository = livroRespository;
        }

        public Livro Create(Livro livro)
        {
            return _livroRespository.Create(livro);
        }

        public void delete(int id)
        {
            _livroRespository.delete(id);
        }

        public List<Livro> FindAll()
        {
           return _livroRespository.FindAll();
        }

        public Livro FindById(int id)
        {
            return _livroRespository.FindById(id);
        }

        public Livro Update(Livro livro)
        {
            return _livroRespository.Update(livro);
        }
    }
}
