using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace MVC_HomeWork.Extensions
{
    public static class EnumExtension
    {
        public static string GetDisplayName(this Enum enumType)
        {
            return enumType.GetType()
                           .GetMember(enumType.ToString())
                           .First()
                           .GetCustomAttribute<DisplayAttribute>()
                           .Name;
        }
    }
}
