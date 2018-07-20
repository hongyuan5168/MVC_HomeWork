using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_HomeWork.Models.ViewModels
{
    public enum CategoryEnum
    {
        [Display(Name = "收入")]
        收入 = 1,
        [Display(Name = "支出")]
        支出 = 2
    }

    public class MoneyViewModel
    {
        [DisplayName("類別")]
        [Required(ErrorMessage = "請選擇類別")]
        public CategoryEnum Category { get; set; }

        [DisplayName("金額")]
        [Required(ErrorMessage = "請填入金額")]
        [DisplayFormat(DataFormatString = "{0:n0}")]
        public int Amount { get; set; }

        [DisplayName("日期")]
        [Required(ErrorMessage = "請輸入日期")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime Date { get; set; }

        [DisplayName("備註")]
        [Required(ErrorMessage = "請輸入備註")]
        public string Description { get; set; }

    }

    
}