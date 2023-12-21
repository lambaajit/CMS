﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace dlwebclasses
{
        public class Service<T,C> : IService<T,C> where T : class where C : DbContext, new()
        {
            //The following variable is going to hold the EmployeeDBContext instance
            public DbContext _context = null;
            //The following Variable is going to hold the DbSet Entity
            public DbSet<T> table = null;

            //Using the Parameterized Constructor, 
            //we are initializing the context object and table variable
            public Service()
            {
                this._context = new C();
                table = _context.Set<T>();
            }
            //This method will return all the Records from the table
            public IEnumerable<T> GetAll()
            {
                return table.AsEnumerable();
            }
            //This method will return the specified record from the table
            //based on the ID which it received as an argument
            public T FindById(object id)
            {
                return table.Find(id);
            }
            //This method will Insert one object into the table
            //It will receive the object as an argument which needs to be inserted into the database
            public void Insert(T obj)
            {
                //It will mark the Entity state as Added State
                table.Add(obj);
            }
            //This method is going to update the record in the table
            //It will receive the object as an argument
            public void Update(T obj)
            {
                //First attach the object to the table
                table.Attach(obj);
                //Then set the state of the Entity as Modified
                _context.Entry(obj).State = EntityState.Modified;
            }



        
            //This method is going to remove the record from the table
            //It will receive the primary key value as an argument whose information needs to be removed from the table
            public void Delete(object id)
            {
                //First, fetch the record from the table
                T existing = table.Find(id);
                //This will mark the Entity State as Deleted
                table.Remove(existing);
            }

            //This method will make the changes permanent in the database
            //That means once we call Insert, Update, and Delete Methods, 
            //Then we need to call the Save method to make the changes permanent in the database
            public void SaveChanges()
            {
                _context.SaveChanges();
            }

        
    }

}
