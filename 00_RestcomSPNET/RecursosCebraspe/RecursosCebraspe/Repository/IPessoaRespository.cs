using RecursosCebraspe.Models;
using System.Collections.Generic;

namespace RecursosCebraspe.Repository
{
    public interface IPessoaRespository
    {
        Pessoa Create(Pessoa pessoa);
        Pessoa FindById(int id);
        List<Pessoa> FindAll();
        Pessoa Update(Pessoa pessoa);
        void delete(int id);
        bool Exists(Pessoa pessoa);

    }
}
