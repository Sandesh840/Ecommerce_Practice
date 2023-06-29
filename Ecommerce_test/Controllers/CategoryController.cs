using Ecommerce_test.Data;
using Ecommerce_test.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_test.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public CategoryController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;      
        }
        public IActionResult Index()
        {
            List<Category> objCategory=_applicationDbContext.Category.ToList();
            return View(objCategory);
        }
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The Display Order can not be same as Category name");
            }
            /*if (obj.Name!=null &&  obj.Name.ToLower() == "test")
            {
                ModelState.AddModelError("", "Test is invalid");
            }*/
            if (ModelState.IsValid)
            {
                _applicationDbContext.Category.Add(obj);
                _applicationDbContext.SaveChanges();
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Edit(int? id)
        {
            if(id==null || id == 0){
                return NotFound();
            }
            Category category = _applicationDbContext.Category.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The Display Order can not be same as Category name");
            }
           
            if (ModelState.IsValid)
            {
                _applicationDbContext.Category.Update(obj);
                _applicationDbContext.SaveChanges();
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category category = _applicationDbContext.Category.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int id)
        {
            Category category = _applicationDbContext.Category.Find(id);
            if (category == null)
            {
                return NotFound() ;
            }
            _applicationDbContext.Category.Remove(category); 
            _applicationDbContext.SaveChanges();
            TempData["success"] = "Category delete successfully";
            return RedirectToAction("Index");
        }
    }
}
