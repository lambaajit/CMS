using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dlwebclasses
{
    public class Service<T> : IService<T> where T : class
    {
        public IT_DatabaseEntities _context = null;
        public DbSet<T> table;
        public Service()
        {
            _context = new IT_DatabaseEntities();
            table = _context.Set<T>();
        }

        public void Delete(object id)
        {
            table.Remove(FindById(id));
        }

        public T FindById(object id)
        {
            return table.Find(id);
        }

        public IQueryable<T> GetAll()
        {
            return table.AsQueryable();
        }

        public virtual void Add(T obj)
        {
            table.Add(obj);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public virtual void Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }
    }
}
