using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using ProjectEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class Manager<T> : IService<T> where T : class
    {
        private IRepository<T> _repo;

        public Manager()
        {
            _repo = new GenericRepository<T>();
        }

        public T Create(T t)
        {
            return _repo.Create(t);
        }

        public void Delete(int id)
        {
            _repo.Delete(id);
        }

        public List<T> GetAll()
        {
            return _repo.GetAll();
        }

        public T GetByID(int id)
        {
            return _repo.GetByID(id);
        }

        public T Update(T t)
        {
            return _repo.Update(t);
        }
    }
}
