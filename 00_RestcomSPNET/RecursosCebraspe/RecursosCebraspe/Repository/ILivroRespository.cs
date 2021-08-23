using RecursosCebraspe.Models;
using System.Collections.Generic;

namespace RecursosCebraspe.Repository
{
    public interface ILivroRespository
    {
        Livro Create(Livro Livro);
        Livro FindById(int id);
        List<Livro> FindAll();
        Livro Update(Livro livro);
        void delete(int id);
        bool Exists(Livro livro);

    }
}
