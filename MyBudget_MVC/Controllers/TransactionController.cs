using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyBudget.DataAccess.Repository.IRepository;
using MyBudget.Models;
using MyBudget.Models.VM;
using MyBudget.Utility;

namespace MyBudget_MVC.Controllers
{
    public class TransactionController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public TransactionController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpGet]
        public IActionResult Index()
        {
            List<Transaction> transactions = _unitOfWork.Transaction.GetAll(includeProperties: "Category").ToList();

            return View(transactions);
        }

        [HttpGet]
        public IActionResult Create()
        {
            TransactionVM transactionVM = new TransactionVM()
            {
                Transaction = new Transaction(),
                CategoryList = _unitOfWork.Category.GetAll().Select(c => new SelectListItem { Text = c.Name, Value = c.Id.ToString() })
            };

            return View(transactionVM);
        }

        [HttpPost]
        public IActionResult Create(TransactionVM transactionVM)
        {
            if(!ModelState.IsValid) 
            {
                transactionVM.CategoryList = _unitOfWork.Category.GetAll().Select(c => new SelectListItem { Text = c.Name, Value = c.Id.ToString() });
                return View(transactionVM);
            }
            _unitOfWork.Transaction.Add(transactionVM.Transaction);
            _unitOfWork.Save();
            TempData["success"] = "Transaction Created Successfuly";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            
            TransactionVM transactionVM = new TransactionVM()
            {
                Transaction = _unitOfWork.Transaction.Get(t => t.Id == id, includeProperties: "Category"),
                CategoryList = _unitOfWork.Category.GetAll().Select(c => new SelectListItem { Text = c.Name, Value = c.Id.ToString() })
            };

            if (transactionVM.Transaction == null)
            {
                return NotFound();
            }

            return View(transactionVM);
        }

        [HttpPost]
        public IActionResult Edit(TransactionVM transactionVM)
        {
            if (!ModelState.IsValid)
            {
                return View(transactionVM);
            }
            _unitOfWork.Transaction.Update(transactionVM.Transaction);
            _unitOfWork.Save();

            TempData["success"] = "Transaction Updated Successfuly";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }

            TransactionVM transactionVM = new TransactionVM()
            {
                Transaction = _unitOfWork.Transaction.Get(t => t.Id == id, includeProperties: "Category"),
                CategoryList = _unitOfWork.Category.GetAll().Select(c => new SelectListItem { Text = c.Name, Value = c.Id.ToString() })
            };

            if (transactionVM.Transaction == null)
            {
                return NotFound();
            }

            return View(transactionVM);
        }

        [HttpPost]
        public IActionResult Delete(TransactionVM transactionVM) 
        {
            Transaction transactionToDelete = _unitOfWork.Transaction.Get(t=>t.Id == transactionVM.Transaction.Id);

            if(transactionToDelete == null)
            {
                return NotFound();
            }

            _unitOfWork.Transaction.Remove(transactionToDelete);
            _unitOfWork.Save();

            TempData["success"] = "Transaction Deleted Successfuly";
            return RedirectToAction("Index");
        }

    }
}
