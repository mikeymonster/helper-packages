using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Reflection;

namespace Wild.TestHelpers.Extensions;

public static class ObjectExtensions
{
    public static ExpandoObject ToExpandoObject(this object value)
    {
        ArgumentNullException.ThrowIfNull(value);

        var obj = new ExpandoObject() as IDictionary<string, object>;

        foreach (var property in value.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
        {
            obj.Add(property.Name, property.GetValue(value, null));
        }

        return (ExpandoObject)obj;
    }
}
