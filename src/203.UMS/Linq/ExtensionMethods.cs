using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace _203.UMS.Linq
{
    public static class ExtensionMethods
    {
        public static IQueryable<T> IncludeMultiple<T>(this IQueryable<T> query, params Expression<Func<T, object>>[] includes) where T : class
        {
            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }
            return query;
        }
    }
}
