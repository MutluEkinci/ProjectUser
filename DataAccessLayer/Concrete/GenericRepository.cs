using DataAccessLayer.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        ProjectDBContext c = new ProjectDBContext();

        DbSet<T> _object;

        public GenericRepository()
        {
            _object = c.Set<T>();
        }

        public GenericRepository(ProjectDBContext ctx)
        {
            _object = c.Set<T>();
        }
        public T Create(T t)
        {
            _object.Add(t);
            c.SaveChanges();

            return t;
        }

        public void Delete(int id)
        {
            var deleted = GetByID(id);
            _object.Remove(deleted);
            c.SaveChanges();
        }

        public List<T> GetAll()
        {
            return _object.ToList();
        }

        public T GetByID(int id)
        {
            return _object.Find(id);
        }

        public T Update(T t)
        {
            _object.Update(t);
            c.SaveChanges();
            return t;
        }
    }
}
