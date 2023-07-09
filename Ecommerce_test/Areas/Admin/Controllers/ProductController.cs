using Ecommerce.DataAccess.Repository.IRepository;
using Ecommerce.Models;
using Ecommerce.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ecommerce_test.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        //to access wwwroot folder
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<Product> objproduct = _unitOfWork.Product.GetAll().ToList();            
            return View(objproduct);
        }


        public IActionResult Upsert(int? id) 
        {
            ProductVM productVM = new()
            {
                CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }), 
                Product =new Product()
            };
            if(id==null || id == 0)  //insert
            {
                return View(productVM);
            }
            else  //update
            {
                productVM.Product=_unitOfWork.Product.Get(u=>u.Id==id);
                return View(productVM);
            }
        }

        [HttpPost]
        public IActionResult Upserts(ProductVM productVM)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Add(productVM.Product);
                _unitOfWork.Save();
                TempData["success"] = "Product created successfully";
                return RedirectToAction("Index");
            }

            else
            {
                productVM.CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });
            }
            return View(productVM);
        }


        /*  public IActionResult Upserts(ProductVM productVM, IFormFile? files)
          {                   
              if (ModelState.IsValid)
              {
                  string wwwRootPath = _webHostEnvironment.WebRootPath;
                  if(files!=null)
                  {
                      string fileName=Guid.NewGuid().ToString()+Path.GetExtension(files.FileName);
                      string productPath=Path.Combine(wwwRootPath, @"images\product");
                      if (!string.IsNullOrEmpty(productVM.Product.ImageUrl))
                      {
                          //delete oldImage 
                          var oldImagePath=Path.Combine(wwwRootPath,productVM.Product.ImageUrl.TrimStart('\\'));
                          if(System.IO.File.Exists(oldImagePath))
                          {
                              System.IO.File.Delete(oldImagePath);
                          }
                      }
                      using(var fileStream=new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                      {
                          files.CopyTo(fileStream);
                      }
                      productVM.Product.ImageUrl = @"\images\product\" + fileName;
                  }  
                  if(productVM.Product.Id==0)
                  {
                      _unitOfWork.Product.Add(productVM.Product);
                  }
                  else
                  {
                      _unitOfWork.Product.Update(productVM.Product);
                  }

                  _unitOfWork.Save();
                  TempData["success"] = "Product created successfully";
                  return RedirectToAction("Index");
              }
              else
              {
                  productVM.CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                      {
                          Text = u.Name,
                          Value = u.Id.ToString()                                     
                  });
              }
              return View(productVM);
          }  */


        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int id)
        {
            Product product = _unitOfWork.Product.Get(u => u.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            _unitOfWork.Product.Remove(product);
            _unitOfWork.Save();
            TempData["success"] = "Product delete successfully";
            return RedirectToAction("Index");
        }
    }
}
