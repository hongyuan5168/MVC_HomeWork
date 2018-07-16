using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_HomeWork.Models.ViewModels;

namespace MVC_HomeWork.Controllers
{
    public class MoneyController : Controller
    {
        // GET: Money
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult MoneyDetail()
        {
            return View(GetMoneyDetail());
        }

        public IEnumerable<MoneyViewModel> GetMoneyDetail()
        {
            for (int x = 1; x <= 50; x++)
            {
                yield return new MoneyViewModel()
                {
                    Category = (x % 2 == 0) ? CategoryEnum.收入 : CategoryEnum.支出,
                    Amount = x * 1000 + 50 - (x * 100),
                    Date = DateTime.Now.AddDays(-x)
                };
            }
        }
    }
}