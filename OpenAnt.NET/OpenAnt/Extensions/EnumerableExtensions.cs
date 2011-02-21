namespace OpenAnt
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Enumerable extensions.
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Perform action for each item in the enumeration.
        /// </summary>
        /// <param name="source">
        /// The source.
        /// </param>
        /// <param name="action">
        /// The action.
        /// </param>
        /// <typeparam name="T">
        /// Type to iterate over.
        /// </typeparam>
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (var t in source)
            {
                action(t);
            }
        }
    }
}
