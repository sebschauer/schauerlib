using System.Collections;

namespace SchauerLib.Extensions
{
    public static class GenericCollectionExtensions
    {
        public static TElement? FirstOf<TElement>(this IEnumerable collection)
            where TElement : class 
        {
            var enumerator = collection.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (enumerator.Current is TElement element)
                {
                    return element;
                }
            }

            return null;
        }
    }
}
