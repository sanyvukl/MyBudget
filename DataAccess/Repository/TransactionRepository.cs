using MyBudget.DataAccess.Data;
using MyBudget.DataAccess.Repository.IRepository;
using MyBudget.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBudget.DataAccess.Repository
{
    public class TransactionRepository : Repository<Transaction>, ITransactionRepository
    {
        private readonly AppDbContext _db;

        public TransactionRepository(AppDbContext db): base(db)
        {
            _db = db;
        }

        public void Update(Transaction transaction)
        {
            _db.Update(transaction);
            _db.SaveChanges();
        }
    }
}
