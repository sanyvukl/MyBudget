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
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly AppDbContext _db;

        public CategoryRepository(AppDbContext db): base(db)
        {
            _db = db;
        }

        public void Update(Category category)
        {
            _db.Update(category);
            _db.SaveChanges();
        }
    }
}
