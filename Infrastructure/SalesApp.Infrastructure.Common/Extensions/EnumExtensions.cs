using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SalesApp.Infrastructure.Common.Extensions
{
    public static class EnumExtensions
    {
        // Returns "Display Name" string for enum value given 
        public static string GetDisplayName(this Enum enumValue)
        {
            var type = enumValue.GetType();
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<DisplayAttribute>()
                            .GetName();
        }
    }
}
