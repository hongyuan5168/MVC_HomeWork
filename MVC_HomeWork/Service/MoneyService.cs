using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC_HomeWork.Models;
using MVC_HomeWork.Models.ViewModels;
using MVC_HomeWork.Repository;

namespace MVC_HomeWork.Service
{
    public class MoneyService
    {
        private readonly IRepository<AccountBook> _accountBookRepository;

        public MoneyService(IUnitOfWork unitOfWork)
        {
            _accountBookRepository = new Repository<AccountBook>(unitOfWork);
        }

        public IEnumerable<MoneyViewModel> LookupAll()
        {
            var source = _accountBookRepository.LookupAll();
            var result = source.Select(m => new MoneyViewModel()
            {
                Category = m.Categoryyy == 0 ? CategoryEnum.收入: CategoryEnum.支出,
                Date = m.Dateee,
                Amount = m.Amounttt,
                Description = m.Remarkkk
            });
            return result;
        }

        public MoneyViewModel GetSingle(Guid id)
        {
            var source = _accountBookRepository.GetSingle(d => d.Id == id);
            return new MoneyViewModel
            {
                Category = source.Categoryyy == 0 ? CategoryEnum.收入 : CategoryEnum.支出,
                Date = source.Dateee,
                Amount = source.Amounttt
            };
        }

        public void Add(MoneyViewModel accountBook)
        {
            if (accountBook != null)
            {
                _accountBookRepository.Create(new AccountBook()
                {
                    Id = Guid.NewGuid(),
                    Categoryyy = accountBook.Category == CategoryEnum.收入 ? 0 : 1,
                    Amounttt = accountBook.Amount,
                    Dateee = accountBook.Date,
                    Remarkkk = accountBook.Description
                });
            }
        }

        public void Edit(Guid id, MoneyViewModel pageData)
        {
            var oldData = _accountBookRepository.GetSingle(d => d.Id == id);
            if (oldData != null)
            {
                oldData.Categoryyy = pageData.Category == CategoryEnum.收入 ? 0 : 1;
                oldData.Amounttt = pageData.Amount;
                oldData.Dateee = pageData.Date;
                oldData.Remarkkk = pageData.Description;
            }
        }

        public void Delete(Guid id)
        {
            _accountBookRepository.Remove(_accountBookRepository.GetSingle(d => d.Id == id));
        }


        /// <summary>
        /// 原本的假資料
        /// </summary>
        /// <returns></returns>
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