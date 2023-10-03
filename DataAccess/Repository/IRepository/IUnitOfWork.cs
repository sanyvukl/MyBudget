using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBudget.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepository Category { get; }
        ITransactionRepository Transaction { get; }
        public void Save();
    }
}
