using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;


namespace dlwebclasses
{

    public interface ITrackedEntity
    {
        string CreatedBy { get; set; }
        Nullable<System.DateTime> CreatedDate { get; set; }
        string ModifiedBy { get; set; }
        Nullable<System.DateTime> ModifiedDate { get; set; }

    }

    public interface IEntity
    {
        int ID { get; set; }
    }

    public class TrackedEntity<T> : Service<T> where T : class, ITrackedEntity
    {
        public override void Add(T obj)
        {
            obj.CreatedDate = DateTime.Now;
            obj.CreatedBy = HttpContext.Current.User.Identity.Name;

            table.Add(obj);
        }

        public override void Update(T obj)
        {

            obj.ModifiedDate = DateTime.Now;
            obj.ModifiedBy = HttpContext.Current.User.Identity.Name;

            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;

        }
    }

    public class TrackedEntityWithLogging<T> : TrackedEntity<T> where T : class, ITrackedEntity, IEntity
    {
        public override void Add(T obj)
        {
            obj.CreatedDate = DateTime.Now;
            obj.CreatedBy = HttpContext.Current.User.Identity.Name;

            table.Add(obj);
        }

        public override void Update(T obj)
        {

            obj.ModifiedDate = DateTime.Now;
            obj.ModifiedBy = HttpContext.Current.User.Identity.Name;

            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;

            var _logsOfModification = new LogsOfModification()
            {
                ModfiedTable = typeof(T).ToString(),
                ModifiedBy = HttpContext.Current.User.Identity.Name,
                ModifiedDate = DateTime.Now,
                ModifiedId = obj.ID
            };

            _context.LogsOfModifications.Add(_logsOfModification);

        }
    }
}
