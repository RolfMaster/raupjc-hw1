using System;
using ConsoleApp2;

namespace zad1
{
	public class IntegerList : IIntegerList
	{
		private int[] container;
		public int Count { get; private set; }

		public IntegerList() : this(4) {
		}

		public IntegerList(int initialSize)
		{
			if (initialSize <= 0)
				container = null;
			else
			{
				container = new int[initialSize];
			}
		}

		public void Add(int item)
		{
			if (Count == container.Length)
			{
				int[] a = new int[2 * container.Length];
				for (int i = 0; i < Count; i++)
					a[i] = container[i];
				container = a;
			}
			container[Count] = item;
			Count++;
		}

		public bool Remove(int item)
		{
			return RemoveAt(IndexOf(item));
		}

		public bool RemoveAt(int index)
		{
			if ((index < 0) || (index >(Count-1)))
				return false;

			int i;
			for (i = index; i < Count-1; i++)
			{
				container[i] = container[i + 1];
			}
			container[i] = 0;
			Count--;
			return true;
		}

		public int GetElement(int index)
		{
			if ((index < 0) || (index > (Count - 1)))
				throw new IndexOutOfRangeException();

			else
			{
				return container[index];
			}
		}

		public int IndexOf(int item)
		{
			for (int i = 0; i < Count; i++)
			{
				if (container[i] == item)
					return i;
			}
			return -1;
		}

		public void Clear()
		{
			for (int i = 0; i < Count; i++)
			{
				container[i] = 0;
			}

			Count = 0;

			container = new int[4];
		}

		public bool Contains(int item)
		{
			int a = IndexOf(item);

			if (a == -1)
				return false;
			else
				return true;
		}
	}
}