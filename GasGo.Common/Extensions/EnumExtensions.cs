using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GasGo.Common.Extensions
{
    public static class EnumExtensions
    {
        public static string GetEnumDescription(this Enum value)
        {
            var desc = value.GetAttributeFieldValue<DescriptionAttribute>(d => d.Description);
            return desc ?? value.ToString();
        }

        private static string? GetAttributeFieldValue<TAttribute>(
        this Enum value,
        Func<TAttribute, string> fieldSelector)
        where TAttribute : Attribute
        {
            var enumType = value.GetType();
            var enumValueName = value.ToString();
            var fieldInfo = enumType.GetField(enumValueName);

            if (fieldInfo == null) return null;

            var attribute = fieldInfo.GetCustomAttribute(typeof(TAttribute), false);

            return attribute == null ? null : fieldSelector((TAttribute)attribute);
        }
    }
}
