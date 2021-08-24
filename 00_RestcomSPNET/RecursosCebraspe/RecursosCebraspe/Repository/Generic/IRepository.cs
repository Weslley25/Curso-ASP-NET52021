using RecursosCebraspe.Models;
using System.Collections.Generic;

namespace RecursosCebraspe.Repository.Generic
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Create(T item);
        T FindById(int id);
        List<T> FindAll();
        T Update(T item);
        void delete(int id);
        bool Exists(T T);

    }
}
