using System;

namespace FExtension
{
	/// <summary>
	/// Wraps an object in IComparable object with provided compare selector.
	/// </summary>
	/// <typeparam name="T">Type of object that will be wrapped</typeparam>
	public class Comparable<T> : IComparable<Comparable<T>>
	{
		public T Obj { get; private set; }
		private Func<T, IComparable> selector;

		public Comparable(T obj, Func<T, IComparable> selector)
		{
			Obj = obj;
			this.selector = selector;
		}

		public int CompareTo(Comparable<T> other)
		{
			return Obj.CompareSelectedTo(other.Obj, selector, selector);
		}
	}
}
