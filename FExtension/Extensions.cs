using System;
using System.Collections.Generic;
using System.Linq;

namespace FExtension
{
    public static class Extensions 
    {
        /// <summary>
        /// Checks Equality of two objects by selected fields/objects
        /// </summary>
        /// <typeparam name="TInA">The Type of object A that will be compared to B</typeparam>
        /// <typeparam name="TInB">The Type of object B that will be compared to A</typeparam>
        /// <typeparam name="ComparableA">Type of object returned by SelectorA</typeparam>
        /// <typeparam name="ComparableB">Type of object returned by SelectorB</typeparam>
        /// <param name="A">The object A that will be compared to B</param>
        /// <param name="B">The object B that will be compared to A</param>
        /// <param name="selectorA">Delegate which returns object that will compared</param>
        /// <param name="selectorB">Delegate which returns object with which will be compared</param>
        /// <returns>true if the  object returned by selectorA is equal to the object returned by selectorB; otherwise, false</returns>
        public static bool IsEqual<TInA, TInB, ComparableA, ComparableB>(this TInA A, TInB B, Func<TInA, ComparableA> selectorA, Func<TInB, ComparableB> selectorB)
        {
            if (selectorA is null)
                throw new ArgumentNullException(nameof(selectorA));
            if (selectorB is null)
                throw new ArgumentNullException(nameof(selectorB));

            return selectorA(A).Equals(selectorB(B));
        }
        
        /// <summary>
        /// Checks Equality of two objects by selected fields/objects
        /// </summary>
        /// <typeparam name="TInA">The Type of object A that will be compared to B</typeparam>
        /// <typeparam name="ComparableA">Type of object returned by SelectorA</typeparam>
        /// <typeparam name="Comparable2">Type of object returned by SelectorB</typeparam>
        /// <param name="A">The object A that will be compared to B</param>
        /// <param name="selectorA">The delegate which returns object that will compared</param>
        /// <param name="selectorB">The delegate which returns object with which will be compared</param>
        /// <returns>Returns a value that indicates whether the object returned by selectorA is equal to object returned by selectorB.</returns>
        public static bool IsEqual<TInA, ComparableA, ComparableB>(this TInA A, Func<TInA, ComparableA> selectorA, Func<ComparableB> selectorB)
        {
            if (selectorA is null)
                throw new ArgumentNullException(nameof(selectorA));
            if (selectorB is null)
                throw new ArgumentNullException(nameof(selectorB));

            return selectorA(A).Equals(selectorB());
        }
       
        /// <summary>
        /// Compares two objects by selected fields/objects
        /// </summary>
        /// <typeparam name="TInA">The Type of object A that will be compared to B</typeparam>
        /// <typeparam name="TInB">The Type of object B that will be compared to A</typeparam>
        /// <typeparam name="ComparableA">Type of object returned by SelectorA</typeparam>
        /// <typeparam name="ComparableB">Type of object returned by SelectorB</typeparam>
        /// <param name="A">The object A that will be compared to B</param>
        /// <param name="B">The object B that will be compared to A</param>
        /// <param name="selectorA">Delegate which returns object that will compared</param>
        /// <param name="selectorB">Delegate which returns object with which will be compared</param>
        /// <returns>A signed integer that indicates the relative position of object returned by selectorA and object returned by selectorB in the sort order</returns>
        public static int CompareSelectedTo<TInA, TInB, ComparableA, ComparableB>(this TInA A, TInB B, Func<TInA, ComparableA> selectorA, Func<TInB, ComparableB> selectorB) where ComparableA : IComparable where ComparableB : IComparable 
        {
            if (selectorA is null)
                throw new ArgumentNullException(nameof(selectorA));
            if (selectorB is null)
                throw new ArgumentNullException(nameof(selectorB));

            return selectorA(A).CompareTo(selectorB(B));
        }
        
        /// <summary>
        /// Compares two objects by selected fields/objects
        /// </summary>
        /// <typeparam name="TInA">The Type of object A that will be compared to B</typeparam>
        /// <typeparam name="ComparableA">Type of object returned by SelectorA</typeparam>
        /// <typeparam name="ComparableB">Type of object returned by SelectorB</typeparam>
        /// <param name="A">The object A that will be compared to B</param>
        /// <param name="selectorA">Delegate which returns object that will compared</param>
        /// <param name="selectorB">Delegate which returns object with which will be compared</param>
        /// <returns>A signed integer that indicates the relative position of object returned by selectorA and object returned by selectorB in the sort order</returns>
        public static int CompareSelectedTo<TInA, ComparableA, ComparableB>(this TInA A,  Func<TInA, ComparableA> selectorA, Func<ComparableB> selectorB) where ComparableA : IComparable where ComparableB : IComparable
        {
            if (selectorA is null)
                throw new ArgumentNullException(nameof(selectorA));
            if (selectorB is null)
                throw new ArgumentNullException(nameof(selectorB));

            return selectorA(A).CompareTo(selectorB());
        }

        /// <summary>
        /// Returns IEnumerable of objects wrapped into Comparable with provided selector
        /// </summary>
        /// <typeparam name="T">Type of object that will be wrapped</typeparam>
        /// <param name="source">Source collection</param>
        /// <param name="selector">Delegate which returns object that will compared</param>
        /// <returns>IEnumerable of Comparable objects</returns>
        public static IEnumerable<Comparable<T>> ToComparable<T>(this IEnumerable<T> source, Func<T, IComparable> selector)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));
            if (selector is null)
                throw new ArgumentNullException(nameof(selector));

            return source.Select(x => new Comparable<T>(x, selector));
        }

        /// <summary>
        /// Wraps an object into Comparable with provided selector
        /// </summary>
        /// <typeparam name="T">Type of object that will be wrapped</typeparam>
        /// <param name="obj">The object that will be wrapped</param>
        /// <param name="selector">Delegate which returns object that will compared</param>
        /// <returns>Returns and object wrapped into Comparable with provided selector</returns>
        public static Comparable<T> ToComparableObject<T>(this T obj, Func<T, IComparable> selector)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(obj));
            if (selector is null)
                throw new ArgumentNullException(nameof(selector));

            return new Comparable<T>(obj, selector);
        }

        /// <summary>
        /// Calls passed Action for each item in IEnumerable collection
        /// </summary>
        /// <typeparam name="T">Type of item</typeparam>
        /// <param name="source">Source Collection</param>
        /// <param name="action">Action that will be called for each item</param>
        /// <returns>Source Collection</returns>
        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));
            if (action is null)
                throw new ArgumentNullException(nameof(action));

            foreach (var item in source)
            {
                action(item);
            }
            return source;
        }

        /// <summary>
        /// Calls action for items in collection 
        /// </summary>
        /// <typeparam name="T">Type of item</typeparam>
        /// <param name="source">Source collection</param>
        /// <param name="action">Action that will be called for each item</param>
        /// <param name="startIndex">Start value of index</param>
        /// <param name="indexIncrement">The Func to set the way of index incrementation. Default is index++</param>
        /// <returns>Source Collection</returns>
        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> source, Action<T,int> action, int startIndex = 0, Func<int,int> indexIncrement = null)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));
            if (action is null)
                throw new ArgumentNullException(nameof(action));

            int index = startIndex;
            if (indexIncrement is null)
            {
                indexIncrement = x => x++;
            }
            foreach (var item in source)
            {
                action(item, index);
                index = indexIncrement(index); 
            }
            return source;
        }

        /// <summary>
        /// Calls action for items in collection based on index 
        /// </summary>
        /// <typeparam name="T">Type of items</typeparam>
        /// <param name="source">Source collection</param>
        /// <param name="action">Action that will be called for each item</param>
        /// <param name="startIndex">Start value of index</param>
        /// <param name="indexIncrement">The Func to set the way of index incrementation. Default is index++</param>
        /// <returns>Source Collection</returns>
        public static IEnumerable<T> For<T>(this IEnumerable<T> source, Action<T, int> action, int startIndex = 0, Func<int, int> indexIncrement = null)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));
            if (action is null)
                throw new ArgumentNullException(nameof(action));

            int index = startIndex;
            int lastIndex = 0;
            if (indexIncrement is null)
            {
                indexIncrement = x => x++;
            }
            foreach (var item in source)
            {
                if (lastIndex < index - 1)
                {
                    lastIndex++;
                    continue;
                }
                action(item, index);
                lastIndex = index;
                index = indexIncrement(index);
            }
            return source;
        }

        /// <summary>
        /// Invokes all sub-delegates and returns results 
        /// </summary>
        /// <typeparam name="T">Type of result</typeparam>
        /// <param name="func">Delegate that will be Invoked</param>
        /// <param name="args">Arguments that will be passed</param>
        /// <returns>List of results</returns>
        public static List<T> MultiResultInvoke<T>(this Delegate func, params Object[] args)
        {
            var delegateList = func.GetInvocationList();
            if (delegateList.Length == 0)
            {
                return new List<T>();
            }
            else if (delegateList.Length == 1)
            {
                var result = new List<T>();
                result.Add((T)delegateList[0].DynamicInvoke(args));
                return result;
            }

            return delegateList.Select(x => x.MultiResultInvoke<T>(args)).SelectMany(x => x).ToList();
        }
    }
}
