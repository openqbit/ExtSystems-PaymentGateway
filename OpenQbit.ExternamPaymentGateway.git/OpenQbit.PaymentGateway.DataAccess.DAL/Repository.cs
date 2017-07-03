using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQbit.PaymentGateway.DataAccess.Contracts;
using System.Data.Entity;
using System.Linq.Expressions;

namespace OpenQbit.PaymentGateway.DataAccess.DAL
{
    public class Repository : IRepository
    {
        private PaymentGatewayContext _db = new PaymentGatewayContext();
        //to get connection with InstituteDbContext


        public bool Create<T>(T obj) where T : class
        {
            try
            {
                _db.Set<T>().Add(obj);
                return true;
            }
            catch (Exception edb)
            {
                return false;
            }
        }

        public List<T> GetAll<T>() where T : class
        {
            return _db.Set<T>().ToList();
        }

        public bool Delete<T>(T obj) where T : class
        {
            try
            {
                _db.Set<T>().Remove(obj);
                return true;
            }
            catch (Exception edb)
            {
                return false;
            }
        }


        public T FindById<T>(int id) where T : class
        {
            return _db.Set<T>().Find(id);
        }

        public T Find<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return _db.Set<T>().Where(predicate).FirstOrDefault();
        }

        public List<T> FindList<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return _db.Set<T>().Where<T>(predicate).ToList();
        }


        public bool Save()
        {
            try
            {
                _db.SaveChanges();
                return true;
            }
            catch (Exception edb)
            {
                return false;
            }
        }

        public bool Update<T>(T obj) where T : class
        {
            try
            {
                var edbstate = _db.Entry(obj);
                _db.Set<T>().Attach(obj);
                edbstate.State = EntityState.Modified;
                return true;
            }
            catch (Exception edb)
            {
                return false;
            }
        }

        
    }
}
