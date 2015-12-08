namespace GP.Prescriptions.BusinessObjects.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Extensions for IEnumerables.
    /// </summary>
    public static class IEnumerableExtensions
    {
        /// <summary>
        /// ForEach extension.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumeration">The enumeration.</param>
        /// <param name="action">The action.</param>
        public static void ForEach<T>(this IEnumerable<T> enumeration, Action<T> action)
        {
            foreach (T item in enumeration)
            {
                action(item);
            }
        }

        /// <summary>
        /// Determines whether [is null or empty].
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumeration">The enumeration.</param>
        /// <returns>Boolean.</returns>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumeration)
        {
            return enumeration == null || !enumeration.Any();
        }
    }
}

