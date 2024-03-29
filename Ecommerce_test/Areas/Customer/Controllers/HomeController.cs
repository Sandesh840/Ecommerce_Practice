﻿using Algorithm;
using Ecommerce.DataAccess.Repository.IRepository;
using Ecommerce.Models;
using Ecommerce.Models.ViewModels;
using Ecommerce.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PagedList;
using PagedList.Mvc;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;

namespace Ecommerce_test.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        //to access wwwroot folder
            
        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;           
        }

        public IActionResult Index(int page = 1, int pageSize = 12, string search = "")
        {
            // Retrieve products based on the search query
            IEnumerable<Product> productList = _unitOfWork.Product.GetAll(includeProperties: "Category,ProductImage")
                .Where(product => search == "" || product.Title.ToLower().StartsWith(search.ToLower()));

            int totalItems = productList.Count();
            List<Product> itemsOnPage = productList.Skip((page - 1) * pageSize)
                                      .Take(pageSize)
                                      .ToList();
            var viewModel = new PaginatedViewModel<Product>
            {
                CurrentPage = page,
                PageSize = pageSize,
                TotalItems = totalItems,
                Items = itemsOnPage
            };

            return View(viewModel);
        }


        public IActionResult Details(int productId)
        {
            ShoppingCart cart = new()
            {
                Product = _unitOfWork.Product.Get(u => u.Id == productId, includeProperties: "Category,ProductImage"),
                Count = 1,
                ProductId = productId
            };
            List<Product> products = (List<Product>)_unitOfWork.Product.GetAll(includeProperties: "Category,ProductImage");
            CosineSimilarityAlgorithm algo = new CosineSimilarityAlgorithm(products);
            List<int> productIds = algo.GetSimilarProducts(productId);
            List<Product> recommendProducts = products.Where(p=>productIds.Contains(p.Id)).Cast<Product>().ToList();
            return View(new DetailVM() { ShoppingCart = cart, RecommendedProducts = recommendProducts });
        }

        [HttpPost]
        [Authorize]
        public IActionResult Details(ShoppingCart shoppingCart)
        {
            //get the user id 
           var claimsIdentity=(ClaimsIdentity)User.Identity;
           var userId=claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            shoppingCart.ApplicationUserId = userId;
            ShoppingCart cartFromDb=_unitOfWork.ShopingCart.Get(u=>u.ApplicationUserId == userId && u.ProductId== shoppingCart.ProductId);
            if (cartFromDb != null)
            {
                //cart already exist
                cartFromDb.Count += shoppingCart.Count;
                _unitOfWork.ShopingCart.Update(cartFromDb);
                _unitOfWork.Save();
            }
            else
            {
                //add cart
                _unitOfWork.ShopingCart.Add(shoppingCart);
                _unitOfWork.Save();
                HttpContext.Session.SetInt32(SD.SessionCart, _unitOfWork.ShopingCart.GetAll(u => u.ApplicationUserId == userId).Count());
            }           
            
            TempData["success"] = "Cart updated successfully";
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}