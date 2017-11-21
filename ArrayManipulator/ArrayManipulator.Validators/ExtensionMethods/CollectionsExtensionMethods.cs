namespace System.Collections.Generic
{
    public static class CollectionsExtensionMethods
    {
        private const string DefaultStringJoinSeparator = " ";

        public static string StringJoin<T>(this IEnumerable<T> enumerable,
                                           string separator = DefaultStringJoinSeparator)
        {
            return string.Join(separator, enumerable);
        }
    }
}
