using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FlukeDemo.ExtensionMethods
{
    public static class Enums
    {
        public static string GetDescription(this Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            var attribute = fi.CustomAttributes.First();
            
            if (attribute.AttributeType.Name == "DescriptionAttribute")
                return attribute.ConstructorArguments.FirstOrDefault().Value.ToString();
            else
                return value.ToString();
        }
    }
}
