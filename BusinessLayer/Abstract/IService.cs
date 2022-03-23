using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IService<T>
    {
        List<T> GetAll();
        T GetByID(int id);
        T Create(T t);
        void Delete(int id);
        T Update(T t);
    }
}
