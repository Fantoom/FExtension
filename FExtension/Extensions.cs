using System;

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
            return selectorA(A).CompareTo(selectorB());
        }
    }
}
