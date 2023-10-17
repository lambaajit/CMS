using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dlwebclasses
{
    public interface IService<T> where T : class
    {
        IEnumerable<T> GetAll();
        T FindById(object id);
        void Add(T obj);
        void Update(T obj);
        void Delete(object id);
        void SaveChanges();
    }
}
