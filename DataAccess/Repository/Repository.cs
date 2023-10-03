using Microsoft.EntityFrameworkCore;
using MyBudget.DataAccess.Data;
using MyBudget.DataAccess.Repository.IRepository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyBudget.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T: class
    {
        private readonly AppDbContext _db;
        private readonly DbSet<T> dbSet;
        public Repository(AppDbContext db)
        {
            _db = db;
            dbSet = _db.Set<T>();
        }
        
        public IEnumerable<T> GetAll(Expression<Func<T,bool>> filter = null, string includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            
            try
            {
                if(includeProperties != null)
                {
                    query = query.Include(includeProperties);
                }
                if(filter != null)
                {
                    query = query.Where(filter);
                }

            }
            catch (Exception e){/*toast.Error("Error while retrieving data from db)*/}

            return query;
        }
        public T Get(Expression<Func<T, bool>> filter, string includeProperties = null)
        {
            IQueryable<T> query = dbSet;

            try
            {
                if (includeProperties != null)
                {
                    query = query.Include(includeProperties);
                }
                if (filter != null)
                {
                    query = query.Where(filter);
                }

            }
            catch (Exception e) {/*toast.Error("Error while retrieving data from db)*/}

            return  query.FirstOrDefault();
        }
        public void Add(T entity)
        {
            try
            {
                 _db.Add(entity);
                _db.SaveChanges();
            }
            catch (Exception e) {/*toast.Error("Error while adding to db)*/}
        }
        public void Remove(T entity)
        {
            try
            {
                dbSet.Remove(entity);
                _db.SaveChanges();
            }
            catch (Exception e) {/*toast.Error("Error while deleting data from db)*/}
        }
    }
}
