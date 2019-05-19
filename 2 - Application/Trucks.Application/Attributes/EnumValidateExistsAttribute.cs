using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Trucks.Application.Attributes
{
    /// <summary>
    /// Attribute to validate if Enum is defined.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class EnumValidateExistsAttribute : DataTypeAttribute
    {
        public EnumValidateExistsAttribute()
            : base("Enumeration")
        {
        }

        public override bool IsValid(object value)
        {
            var enumType = value.GetType();

            return enumType.IsEnum && Enum.IsDefined(enumType, value);
        }
    }
}
