using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace raupjc_hw1
{

	public interface IGenericList<X>
	{
		/// <summary >
		/// Adds an item to the  collection.
		///  </summary >
		void Add(X item);
		/// <summary >
		/// Removes  the  first  occurrence  of an item  from  the  collection.
		/// If the  item  was  not found , method  does  nothing  and  returns  false.
		///  </summary >
		bool Remove(X item);
		/// <summary >
		/// Removes  the  item at the  given  index in the  collection.
		/// Throws  IndexOutOfRange  exception  if  index  out of  range.
		///  </summary >
		bool RemoveAt(int index);
		/// <summary >
		/// Returns  the  item at the  given  index in the  collection.
		/// Throws  IndexOutOfRange  exception  if  index  out of  range.
		///  </summary >
		X GetElement(int index);
		/// <summary >
		/// Returns  the  index of the  item in the  collection.
		/// If item is not  found in the  collection , method  returns  -1.
		///  </summary >
		int IndexOf(X item);
		/// <summary >
		/// Readonly  property. Gets  the  number  of  items  contained  in the
		/// collection.
		///  </summary >
		int Count { get; }
		/// <summary >
		/// Removes  all  items  from  the  collection.
		///  </summary >
		void Clear();
		/// <summary >
		/// Determines  whether  the  collection  contains a specific  value.
		///  </summary >
		bool Contains(X item);
	}

	public class GenericList<X> : IGenericList<X>
	{
		private X[] _internalStorage;

		public GenericList()
		{
			_internalStorage = new X[4];
			Count = 0;
		}

		public GenericList(int initialSize)
		{
			_internalStorage = new X[Math.Abs(initialSize)];
			Count = 0;
		}


		public void Add(X item)
		{
			if (_internalStorage.Length == Count)
			{
				int size = _internalStorage.Length;
				X[] a = new X[2 * size];

				for (int i = 0; i < size; i++)
					a[i] = _internalStorage[i];
				a[size] = item;

				_internalStorage = a;
			}

			_internalStorage[Count] = item;
			Count++;


		}

		public bool Remove(X item)
		{
			int i;
			for (i = 0; i < Count; i++)
			{
				if (_internalStorage[i].Equals(item))
					return RemoveAt(i);
			}
			return false;
		}

		public bool RemoveAt(int index)
		{
			if ((index >= _internalStorage.Length) || (index < 0))
				throw new IndexOutOfRangeException();

			if (_internalStorage[index].Equals(default(X)))
				return false;

			_internalStorage[index] = default(X);

			for (int i = index+1; i <= Count; i++)
			{
				_internalStorage[i-1] = _internalStorage[i];
			}

			Count--;
			return true;
		}

		public X GetElement(int index)
		{
			if ((index >= _internalStorage.Length) || (index < 0))
				throw new IndexOutOfRangeException();

			return _internalStorage[index];
		}

		public int IndexOf(X item)
		{
			throw new NotImplementedException();
		}

		//private int _count;
		public int Count { get; private set; }

		public void Clear()
		{
			_internalStorage = new X[4];
			Count = 0;
		}

		public bool Contains(X item)
		{
			int i = 0;
			while (i <= Count)
			{
				if (_internalStorage[i].Equals(item)) return true;
			}
			return false;
		}


		public static void ListExample(IGenericList<int> listOfGenerics)
		{
			listOfGenerics.Add(1); // [1]
			listOfGenerics.Add(2); // [1,2]
			listOfGenerics.Add(3); // [1,2,3]
			listOfGenerics.Add(4); // [1,2,3,4]
			listOfGenerics.Add(5); // [1,2,3,4,5]
			listOfGenerics.RemoveAt(0); // [2,3,4,5]
			listOfGenerics.Remove(5); // [2,3,4]
			Console.WriteLine(listOfGenerics.Count); // 3
			Console.WriteLine(listOfGenerics.Remove(100)); //  false
			Console.WriteLine(listOfGenerics.RemoveAt(5)); //  false
			listOfGenerics.Clear(); // []
			Console.WriteLine(listOfGenerics.Count); // 0
		}
	}

	class hw1
	{
		static void Main(string[] args)
		{
			GenericList<int> myList = new GenericList<int>();
			GenericList<int>.ListExample(myList);
		}
	}
}
