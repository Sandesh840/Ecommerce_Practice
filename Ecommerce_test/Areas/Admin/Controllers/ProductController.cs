﻿using Ecommerce.DataAccess.Repository.IRepository;
using Ecommerce.Models;
using Ecommerce.Models.ViewModels;
using Ecommerce.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;

namespace Ecommerce_test.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
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
            List<Product> objproduct = _unitOfWork.Product.GetAll(includeProperties:"Category").ToList();            
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
                productVM.Product=_unitOfWork.Product.Get(u=>u.Id==id, includeProperties: "ProductImage");
                return View(productVM);
            }
        }

        [HttpPost]
        public IActionResult Upserts(ProductVM productVM,List<IFormFile>? files)
        {
            if (ModelState.IsValid)
            {
                if (productVM.Product.Id == 0)
                {
                    _unitOfWork.Product.Add(productVM.Product);
                }
                else
                {
                    _unitOfWork.Product.Update(productVM.Product);
                }
                _unitOfWork.Save();
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (files != null)
                {
                    foreach(IFormFile file in files)
                    {
                        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                        string productPath=@"images\products\product-"+productVM.Product.Id;
                        string finalPath = Path.Combine(wwwRootPath, productPath);
                        if(!Directory.Exists(finalPath)) { Directory.CreateDirectory(finalPath); }
                        using (var fileStream = new FileStream(Path.Combine(finalPath, fileName), FileMode.Create))
                        {
                            file.CopyTo(fileStream);
                        }
                        ProductImage productImage = new()
                        {
                            ImageUrl = @"\" + productPath + @"\" + fileName,
                            ProductId=productVM.Product.Id,
                        };
                        if (productVM.Product.ProductImage == null)
                        {
                            productVM.Product.ProductImage = new List<ProductImage>();
                        }
                        productVM.Product.ProductImage.Add(productImage);
                       // _unitOfWork.ProductImage.Add(productImage);
                    }
                    _unitOfWork.Product.Update(productVM.Product);
                    _unitOfWork.Save();
                }
               
                if (productVM.Product.Id == 0)
                {TempData["success"] = "Product created successfully";}
                else
                {TempData["success"] = "Product updated successfully";}               
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
        

        public IActionResult DeleteImage(int imageId)
        {
            var imageToBeDeleted=_unitOfWork.ProductImage.Get(u=>u.Id == imageId);
            int productId=imageToBeDeleted.ProductId;
            if(imageToBeDeleted != null)
            {
                if (!string.IsNullOrEmpty(imageToBeDeleted.ImageUrl))
                {
                    var oldImgPath = Path.Combine(_webHostEnvironment.WebRootPath, imageToBeDeleted.ImageUrl.TrimStart('\\'));
                    if (System.IO.File.Exists(oldImgPath))
                    {
                        System.IO.File.Delete(oldImgPath);
                    }
                }
                _unitOfWork.ProductImage.Remove(imageToBeDeleted);
                _unitOfWork.Save();
                TempData["success"] = "Image deleted successfully";
            }
            return RedirectToAction(nameof(Upsert), new { id = productId });
        }

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Product> objproduct = _unitOfWork.Product.GetAll(includeProperties: "Category").ToList();
            return Json(new { data = objproduct });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var productToBeDeleted = _unitOfWork.Product.Get(u => u.Id == id);
            if (productToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            string productPath = @"images\products\product-" + id;
            string finalPath = Path.Combine(_webHostEnvironment.WebRootPath, productPath);

            if (Directory.Exists(finalPath))
            {
                string[] filePaths = Directory.GetFiles(finalPath);
                foreach (string filePath in filePaths)
                {
                    System.IO.File.Delete(filePath);
                }

                Directory.Delete(finalPath);
            }


            _unitOfWork.Product.Remove(productToBeDeleted);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Delete Successful" });
        }
        #endregion
    }
}
