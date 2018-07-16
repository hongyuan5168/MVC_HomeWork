using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MVC_HomeWork.Models.ViewModels
{
    public enum CategoryEnum
    {
        收入 = 'I',
        支出 = 'E'
    }

    public class MoneyViewModel
    {
        [DisplayName("類別")]
        public CategoryEnum Category { get; set; }
        [DisplayName("金額")]
        public int Amount { get; set; }
        [DisplayName("日期")]
        public DateTime Date { get; set; }
        [DisplayName("備註")]
        public string Description { get; set; }

    }

    
}