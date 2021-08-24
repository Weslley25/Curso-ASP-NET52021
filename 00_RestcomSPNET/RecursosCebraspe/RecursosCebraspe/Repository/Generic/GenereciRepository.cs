using Microsoft.EntityFrameworkCore;
using RecursosCebraspe.Models;
using RecursosCebraspe.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecursosCebraspe.Repository.Generic
{
    public class GenereciRepository<T> : IRepository<T> where T : BaseEntity
    {
        private SQLContext _context;
        private DbSet<T> dataset;
        public GenereciRepository(SQLContext context)
        {
            _context = context;
            dataset = _context.Set<T>();
        }

        public List<T> FindAll()
        {
            return dataset.ToList();
        }

        public T FindById(int id)
        {
            return dataset.SingleOrDefault(t => t.Id.Equals(id));
        }

        public T Create(T item)
        {
            try
            {
                dataset.Add(item);
                _context.SaveChanges();
                return item;
            }
            catch (Exception)
            {

                throw;
            }
        }
    

        public T Update(T item)
        {
            var result = dataset.SingleOrDefault(t => t.Id.Equals(item.Id));

            if (result != null)
            {
                
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(item);
                    _context.SaveChanges();
                    return item;
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                return null;
            }
            
        }
        public void delete(int id)
        {
            var resul = dataset.SingleOrDefault(p => p.Id.Equals(id));
            if(resul!= null)
            {
                try
                {
                    dataset.Add(resul);
                    _context.SaveChanges();

                }
                catch (Exception)
                {

                    throw;
                }

            }
        
            
        }

        public bool Exists(T T)
        {
            return dataset.Any(l => l.Id.Equals(T.Id));
        }
    }
}

