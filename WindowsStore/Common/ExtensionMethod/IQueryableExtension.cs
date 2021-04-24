using Store.Common.Infrastructure;
using System.Linq;

namespace Store.Common.ExtensionMethod
{
    public static class QueryableExtension
    {
        public static IQueryable<T> Page<T>(this IQueryable<T> query, FilterBase filter)
        {
            return query.Skip(filter.PageIndex * filter.PageSize).Take(filter.PageSize);
        }
    }
}
