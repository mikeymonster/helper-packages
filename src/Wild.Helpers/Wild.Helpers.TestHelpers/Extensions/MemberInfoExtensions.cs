using System;
using System.Reflection;

namespace Wild.Helpers.TestHelpers.Extensions
{
    public static class MemberInfoExtensions
    {
        public static T GetValue<T>(this MemberInfo memberInfo, object obj)
            where T : class
        {
            return memberInfo.MemberType switch
            {
                MemberTypes.Field => ((FieldInfo) memberInfo).GetValue(obj) as T,
                MemberTypes.Property => ((PropertyInfo) memberInfo).GetValue(obj) as T,
                _ => throw new NotImplementedException()
            };
        }
    }
}
