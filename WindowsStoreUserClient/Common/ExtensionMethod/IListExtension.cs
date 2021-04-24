using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsStore.Client.User.Common.ExtensionMethod
{
    public static class IListExtension
    {
        public static void RemoveRange<T>(this IList<T> source, Func<T, bool> predicate)
        {
            T item;
            do {
                item = source.FirstOrDefault(predicate);
                if (item != null)
                    source.Remove(item);
            } while (item != null);
        }
    }
}
