using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dlwebclasses
{
    public interface IService<T,C> where T : class where C : DbContext
    {
        IEnumerable<T> GetAll();
        T FindById(object id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(object id);
        void SaveChanges();
    }

}
