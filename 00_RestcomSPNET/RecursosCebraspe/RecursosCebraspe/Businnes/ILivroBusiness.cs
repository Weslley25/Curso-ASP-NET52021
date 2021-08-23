using RecursosCebraspe.Models;
using System.Collections.Generic;

namespace RecursosCebraspe.Repository
{
    public interface ILivroBussines
    {
        Livro Create(Livro livro);
        Livro FindById(int id);
        List<Livro> FindAll();
        Livro Update(Livro livro);
        void delete(int id);
       

    }
}
