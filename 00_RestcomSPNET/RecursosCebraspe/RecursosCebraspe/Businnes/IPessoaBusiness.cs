using RecursosCebraspe.Models;
using System.Collections.Generic;

namespace RecursosCebraspe.Business

{
    public interface IPessoaBusiness
    {
        Pessoa Create(Pessoa pessoa);
        Pessoa FindById(int id);
        List<Pessoa> FindAll();
        Pessoa Update(Pessoa pessoa);
        void delete(int id);

    }
}
