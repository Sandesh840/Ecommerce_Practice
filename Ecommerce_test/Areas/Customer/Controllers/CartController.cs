using Ecommerce.DataAccess.Repository.IRepository;
using Ecommerce.Models;
using Ecommerce.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Ecommerce_test.Areas.Customer.Controllers
{
    [Area("customer")]
    [Authorize]
    public class CartController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ShopingCartVM ShopingCartVM { get; set; }
        public CartController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            ShopingCartVM = new()
            {
                ShoppingCartList=_unitOfWork.ShopingCart.GetAll(u=>u.ApplicationUserId == userId,
                includeProperties:"Product")
            };
            foreach(var cart in ShopingCartVM.ShoppingCartList)
            {
                cart.Price =GetPriceBasedOnQuantity(cart);
                ShopingCartVM.OrderTotal += (cart.Price * cart.Count);
            }
            return View(ShopingCartVM);
        }

        public IActionResult Plus(int cartId)
        {
            var cartFromDb=_unitOfWork.ShopingCart.Get(u=>u.Id==cartId);
            cartFromDb.Count += 1;
            _unitOfWork.ShopingCart.Update(cartFromDb);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Summary()
        {
            return View();
        }
        public IActionResult Minus(int cartId)
        {
            var cartFromDb = _unitOfWork.ShopingCart.Get(u => u.Id == cartId);
            if(cartFromDb.Count <= 1)
            {
                //remove item from cart
                _unitOfWork.ShopingCart.Remove(cartFromDb);
            }
            else
            {
                cartFromDb.Count -= 1;
                _unitOfWork.ShopingCart.Update(cartFromDb);
            }            
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Remove(int cartId)
        {
            var cartFromDb = _unitOfWork.ShopingCart.Get(u => u.Id == cartId);            
             _unitOfWork.ShopingCart.Remove(cartFromDb);            
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }


        private double GetPriceBasedOnQuantity(ShoppingCart shoppingCart)
        {
            if (shoppingCart.Count <= 50)
            {
                return shoppingCart.Product.Price;
            }
            else
            {
                if (shoppingCart.Count <= 100)
                {
                    return shoppingCart.Product.Price50;
                }
                else
                {
                    return shoppingCart.Product.Price100;
                }
            }
        }
    }
}
