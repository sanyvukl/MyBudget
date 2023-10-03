using MyBudget.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBudget.DataAccess.Repository.IRepository
{
    public interface ITransactionRepository: IRepository<Transaction>
    {
        void Update(Transaction category);
    }
}
