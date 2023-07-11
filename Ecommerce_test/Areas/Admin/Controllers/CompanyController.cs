using Ecommerce.DataAccess.Repository.IRepository;
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
    //[Authorize(Roles = SD.Role_Admin)]
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CompanyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Company> objcompany = _unitOfWork.Company.GetAll().ToList();            
            return View(objcompany);
        }


        public IActionResult Upsert(int? id) 
        {
           
            if(id==null || id == 0)  //insert
            {
                return View(new Company());
            }
            else  //update
            {
                Company companyObj=_unitOfWork.Company.Get(u=>u.Id==id);
                return View(companyObj);
            }
        }

        [HttpPost]
        public IActionResult Upserts(Company companyObj)
        {
            if (ModelState.IsValid)
            {              
                if (companyObj.Id == 0)
                {
                    _unitOfWork.Company.Add(companyObj);
                }
                else
                {
                    _unitOfWork.Company.Update(companyObj);
                }
                _unitOfWork.Save();
                if (companyObj.Id == 0)
                {TempData["success"] = "Company created successfully";}
                else
                {TempData["success"] = "Company updated successfully";}               
                return RedirectToAction("Index");
            }

            else
            {
                return View(companyObj);
            }
            
        }
        

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Company> objcompany = _unitOfWork.Company.GetAll().ToList();
            return Json(new { data = objcompany });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var companyToBeDeleted = _unitOfWork.Company.Get(u => u.Id == id);
            if (companyToBeDeleted == null)
            {
                return Json(new { success = false, message = "errpr while deleting" });
            }
            _unitOfWork.Company.Remove(companyToBeDeleted);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Successfully deleting" });
        }
        #endregion
    }
}
