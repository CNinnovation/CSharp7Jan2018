using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp7Samples
{
    public static class CollectionExtensions
    {
        public static IEnumerable<T> Filter<T>(this IEnumerable<T> source, Func<T, bool> pred)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (pred == null) throw new ArgumentNullException(nameof(pred));

            return FilterCore();

            IEnumerable<T> FilterCore()
            {
                foreach (T item in source)
                {
                    if (pred(item))
                    {
                        yield return item;
                    }
                }
            }
        }


    }
}
