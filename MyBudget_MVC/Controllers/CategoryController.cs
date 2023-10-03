using Microsoft.AspNetCore.Mvc;
using MyBudget.DataAccess.Repository.IRepository;
using MyBudget.Models;
using MyBudget.Utility;

namespace MyBudget_MVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpGet]
        public IActionResult Index()
        {
            List<Category> categories = _unitOfWork.Category.GetAll().ToList();

            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if(!ModelState.IsValid) 
            {
                return View(category);
            }
            _unitOfWork.Category.Add(category);
            _unitOfWork.Save();
            TempData["success"] = "Category Created Successfuly";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            
            var categoryFromDb = _unitOfWork.Category.Get(category => category.Id == id);
            if(categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }
            _unitOfWork.Category.Update(category);
            _unitOfWork.Save();
            TempData["success"] = "Category Updated Successfuly";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }

            var categoryFromDb = _unitOfWork.Category.Get(category => category.Id == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        [HttpPost]
        public IActionResult Delete(Category category) 
        {
            _unitOfWork.Category.Remove(category);
            _unitOfWork.Save();

            TempData["success"] = "Category Deleted Successfuly";
            return RedirectToAction("Index");
        }

    }
}
