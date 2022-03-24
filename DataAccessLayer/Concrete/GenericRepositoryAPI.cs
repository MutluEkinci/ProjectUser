using DataAccessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProjectEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class GenericRepositoryAPI<T> : IRepositoryAPI<T> where T : class
    {
        string _url;
        public GenericRepositoryAPI(string url)
        {
            _url = url;
        }
        public T Create(T t)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> GetAll()
        {
            ProjectDBContext db = new ProjectDBContext();
            HttpClient istemci = new HttpClient();

            string data = istemci.GetStringAsync(_url).Result;

            List<T> list = JsonConvert.DeserializeObject<List<T>>(data);

            DbSet<T> dbp = db.Set<T>();

            dbp.AddRange(list);

            return dbp.ToListAsync();
        }
        //
        public T GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public T Update(T t)
        {
            throw new NotImplementedException();
        }
    }
}
