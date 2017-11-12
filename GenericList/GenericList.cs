using System;
using System.Collections;			//moram koristiti System.Collections kako bih implementirao enumerable sučelje
using System.Collections.Generic;



namespace ConsoleApp1
{
	public class GenericList<X> : IGenericList<X>
	{

		private X[] container;
		public int Count { get; private set; }

		public GenericList() : this(4) {
		}

		public GenericList(int initialSize)
		{
			if (initialSize <= 0)
				container = null;
			else
			{
				container = new X[initialSize];
			}
		}


		public void Add(X item)
		{
			if (Count == container.Length)
			{
				X[] a = new X[2 * container.Length];
				for (int i = 0; i < Count; i++)
					a[i] = container[i];
				container = a;
			}
			container[Count] = item;
			Count++;
		}

		public bool Remove(X item)
		{
			return RemoveAt(IndexOf(item));
		}

		public bool RemoveAt(int index)
		{
			if ((index < 0) || (index > (Count - 1)))
				return false;

			int i;
			for (i = index; i < Count - 1; i++)
			{
				container[i] = container[i + 1];
			}
			container[i] = default(X);
			Count--;
			return true;
		}

		public X GetElement(int index)
		{
			if ((index < 0) || (index > (Count - 1)))
				throw new IndexOutOfRangeException();

			else
			{
				return container[index];
			}
		}

		public int IndexOf(X item)
		{
			for (int i = 0; i < Count; i++)
			{
				if (Equals(container[i], item))
					return i;
			}
			return -1;
		}

		public void Clear()
		{
			for (int i = 0; i < Count; i++)
			{
				container[i] = default(X);
			}

			Count = 0;

			container = new X[4];
		}

		public bool Contains(X item)
		{
			int a = IndexOf(item);

			if (a == -1)
				return false;
			else
				return true;
		}

		public IEnumerator<X> GetEnumerator()
		{
			return new GenericListEnumerator<X>(this);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}



	public class GenericListEnumerator<T> : IEnumerator<T>
	{
		private int _index;
		private GenericList<T> listPointer;

		public GenericListEnumerator(GenericList<T> genericList)
		{
			_index = -1;
			listPointer =  genericList;
		}

		public void Dispose()
		{
			Current = default(T);
		}

		public bool MoveNext()
		{
			_index++;
			try
			{
				Current = (T) listPointer.GetElement(_index);
				return true;
			}
			catch (IndexOutOfRangeException)
			{
				_index--;
				return false;
			}
		}

		public void Reset()
		{
			Current = default(T);
			_index = -1;
		}

		public T Current { get; private set; }

		object IEnumerator.Current
		{
			get { return Current; }
		}
	}
}