using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Service.Utilities.Extensions
{
    public static class ObjectExtentions
    {
        public static List<T> OrderByProperty<T>(this List<T> source, string propertyName, SortDirection direction)
        {
            PropertyInfo propInfo = typeof(T).GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

            if (propInfo == null)
            {
                return source;
            }

            if (direction == SortDirection.Ascending)
            {
                return source.OrderBy(x => propInfo.GetValue(x, null)).ToList();
            }
            else
            {
                return source.OrderByDescending(x => propInfo.GetValue(x, null)).ToList();
            }
        }
    }
}