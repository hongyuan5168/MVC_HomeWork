using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_HomeWork.Extensions;
using MVC_HomeWork.Models.ViewModels;
using MVC_HomeWork.Repository;
using MVC_HomeWork.Service;

namespace MVC_HomeWork.Controllers
{
    public class MoneyController : Controller
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly MoneyService _moneyService;
        

        public MoneyController()
        {
            _unitOfWork = new UnitOfWork();
            _moneyService = new MoneyService(_unitOfWork);
        }

        // GET: Money
        public ActionResult Index()
        {
            ViewData["CategoryList"] = GetCategoryList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "Category,Date,Amount,Description")] MoneyViewModel model)
        {
           ViewData["CategoryList"] = GetCategoryList();
            try
            {
                if (ModelState.IsValid)
                {
                    _moneyService.Add(model);
                    _unitOfWork.Commit();

                    ModelState.AddModelError("Insert Success", "新增成功!!");

                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("error", ex.Message);
            }

            return View(model);
        }

        [ChildActionOnly]
        public ActionResult MoneyDetail()
        {
            //return View(_moneyService.GetMoneyDetail()); //原本的假資料
            return View(_moneyService.LookupAll());
        }

        private IEnumerable<SelectListItem> GetCategoryList()
        {
            IList<SelectListItem> items = new List<SelectListItem>();

            items.Insert(0, new SelectListItem()
            {
                Value = "0",
                Text = "請選擇"
            });
            //var x = Enum.GetValues(typeof(CategoryEnum)).AsQueryable();
            
            items.Insert(1, new SelectListItem()
            {
                //Value = CategoryEnum.收入.ToString(),
                Value = "1",
                Text = CategoryEnum.收入.GetDisplayName()
            });

            items.Insert(2, new SelectListItem()
            {
                //Value = CategoryEnum.支出.ToString(),
                Value = "2",
                Text = CategoryEnum.支出.GetDisplayName()
            });

            return items.AsEnumerable();
        }
    }
}