using RecursosCebraspe.Models;
using System.Collections.Generic;

namespace RecursosCebraspe.Service
{
    public interface IPessoaService
    {
        Pessoa Create(Pessoa pessoa);
        Pessoa FindById(int id);
        List<Pessoa> FindAll();
        Pessoa Update(Pessoa pessoa);
        void delete(int id);

    }
}
