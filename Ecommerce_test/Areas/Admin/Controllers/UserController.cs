using Ecommerce.DataAccess.Data;
using Ecommerce.DataAccess.Repository;
using Ecommerce.DataAccess.Repository.IRepository;
using Ecommerce.Models;
using Ecommerce.Models.ViewModels;
using Ecommerce.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Ecommerce_test.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly UserManager<IdentityUser> _userManager;

        public UserController(ApplicationDbContext applicationDbContext, UserManager<IdentityUser> userManager)
        {
            _applicationDbContext = applicationDbContext;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RoleManagment(string userId)
        {
            string RoleId=_applicationDbContext.UserRoles.FirstOrDefault(u=>u.UserId==userId).RoleId;
            RoleManagmentVM RoleVM = new RoleManagmentVM()
            {
                ApplicationUser=_applicationDbContext.ApplicationUser.Include(u=>u.Company).FirstOrDefault(u=>u.Id==userId),


                RoleList = _applicationDbContext.Roles.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Name
                }),
                CompanyList = _applicationDbContext.Company.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
            };
            RoleVM.ApplicationUser.Role=_applicationDbContext.Roles.FirstOrDefault(u=>u.Id==RoleId).Name;
            return View(RoleVM);
        }

        [HttpPost]
        public IActionResult RoleManagment(RoleManagmentVM roleManagmentVM)
        {
            string RoleId = _applicationDbContext.UserRoles.FirstOrDefault(u => u.UserId == roleManagmentVM.ApplicationUser.Id).RoleId;
            string oldRole = _applicationDbContext.Roles.FirstOrDefault(u => u.Id == RoleId).Name;
            if (!(roleManagmentVM.ApplicationUser.Role == oldRole))
            {
                //role was updated
                ApplicationUser applicationUser = _applicationDbContext.ApplicationUser.FirstOrDefault(u => u.Id == roleManagmentVM.ApplicationUser.Id);
                if (roleManagmentVM.ApplicationUser.Role == SD.Role_Company)
                {
                    applicationUser.CompanyId=roleManagmentVM.ApplicationUser.CompanyId;
                }
                if (oldRole == SD.Role_Company)
                {
                    applicationUser.CompanyId = null;
                }
                _applicationDbContext.SaveChanges();
                _userManager.RemoveFromRoleAsync(applicationUser, oldRole).GetAwaiter().GetResult();
                _userManager.AddToRoleAsync(applicationUser, roleManagmentVM.ApplicationUser.Role).GetAwaiter().GetResult();
            }            
            return RedirectToAction("Index");
        }

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            List<ApplicationUser> objUserList = _applicationDbContext.ApplicationUser.Include(u=>u.Company).ToList();
            var userRoles = _applicationDbContext.UserRoles.ToList();
            var roles=_applicationDbContext.Roles.ToList();
            foreach (var user in objUserList)
            {
                var roleId = userRoles.FirstOrDefault(u => u.UserId == user.Id).RoleId;
                user.Role = roles.FirstOrDefault(u => u.Id == roleId).Name;
                if (user.Company == null)
                {
                    user.Company = new() { Name = "" };
                }
            }
            return Json(new { data = objUserList });
        }

        [HttpPost]
        public IActionResult LockUnlock([FromBody]string id)
        {
           var objFromDb=_applicationDbContext.ApplicationUser.FirstOrDefault(u=> u.Id == id);            
                if (objFromDb == null)
                {
                    return Json(new { success = false, message = "Error while Locking/Unlocking" });
                }
                if (objFromDb.LockoutEnd != null && objFromDb.LockoutEnd > DateTime.Now)
                {
                    //usedr is currently locked and we need to unlock the user
                    objFromDb.LockoutEnd = DateTime.Now;
                }
                else
                {
                    objFromDb.LockoutEnd = DateTime.Now.AddDays(7);
                }
                _applicationDbContext.SaveChanges();
                return Json(new { success = true, message = "Operation Successfully" });
           
        }
        #endregion
    }
}
