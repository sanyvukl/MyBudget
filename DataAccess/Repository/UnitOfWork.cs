using MyBudget.DataAccess.Data;
using MyBudget.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBudget.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _db;
        public ICategoryRepository Category { get; private set; }
        public ITransactionRepository Transaction { get; private set; }
        public UnitOfWork(AppDbContext db) 
        {
            _db = db;
            Category = new CategoryRepository(db);
            Transaction = new TransactionRepository(db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
