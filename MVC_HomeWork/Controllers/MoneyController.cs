using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
            return View();
        }

        [ChildActionOnly]
        public ActionResult MoneyDetail()
        {
            //return View(_moneyService.GetMoneyDetail()); //原本的假資料
            return View(_moneyService.LookupAll());
        }

        
    }
}