using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace PatrolControl.Service.Utils
{
    public static class MethodInfoExtension
    {
        private static string GetTypeName(Type type)
        {
            if (type.IsGenericType)
            {
                var genericTypeName = type.GetGenericTypeDefinition().Name;
                genericTypeName = genericTypeName.Substring(0,genericTypeName.IndexOf('`'));
                var genericArgs = string.Join(",", type.GetGenericArguments().Select(GetTypeName).ToArray());
                return genericTypeName + "<" + genericArgs + ">";
            }
            if (type.IsArray)
            {
                return type.GetElementType().Name + "[]";
            }
            return type.Name.Equals("Void") ? type.Name.ToLower() : type.Name;
        }

        public static string MethodSignature(this MethodInfo mi)
        {
            var param = mi.GetParameters()
                          .Select(p => String.Format("{0} {1}", GetTypeName(p.ParameterType), p.Name))
                          .ToArray();
            return String.Format("{0} {1}({2})", GetTypeName(mi.ReturnType), mi.Name, String.Join(",", param));
        }
    }
}