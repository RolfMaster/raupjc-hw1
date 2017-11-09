using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace raupjc_hw1
{

	public interface IIntegerList
	{
		/// <summary >
		/// Adds an item to the  collection.
		///  </summary >
		void Add(int item);
		/// <summary >
		/// Removes  the  first  occurrence  of an item  from  the  collection.
		/// If the  item  was  not found , method  does  nothing  and  returns  false.
		///  </summary >
		bool Remove(int item);
		/// <summary >
		/// Removes  the  item at the  given  index in the  collection.
		/// Throws  IndexOutOfRange  exception  if  index  out of  range.
		///  </summary >
		bool RemoveAt(int index);
		/// <summary >
		/// Returns  the  item at the  given  index in the  collection.
		/// Throws  IndexOutOfRange  exception  if  index  out of  range.
		///  </summary >
		int GetElement(int index);
		/// <summary >
		/// Returns  the  index of the  item in the  collection.
		/// If item is not  found in the  collection , method  returns  -1.
		///  </summary >
		int IndexOf(int item);
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
		bool Contains(int item);
	}

	public class IntegerList : IIntegerList
	{
		private int[] _internalStorage;

		public IntegerList()
		{
			_internalStorage = new int[4];
			Count = 0;
		}

		public IntegerList(int initialSize)
		{
			_internalStorage = new int[Math.Abs(initialSize)];
			Count = 0;
		}


		public void Add(int item)
		{
			if (_internalStorage.Length == Count)
			{
				int size = _internalStorage.Length;
				int[] a = new int[2 * size];

				for (int i = 0; i < size; i++)
					a[i] = _internalStorage[i];
				a[size] = item;

				_internalStorage = a;
			}

			_internalStorage[Count] = item;
			Count++;


		}

		public bool Remove(int item)
		{
			int i;
			for (i = 0; i < Count; i++)
			{
				if (_internalStorage[i] == item)
					return RemoveAt(i);
			}
			return false;
		}

		public bool RemoveAt(int index)
		{
			if ((index >= _internalStorage.Length) || (index < 0))
				throw new IndexOutOfRangeException();

			if (_internalStorage[index] == 0)
				return false;

			_internalStorage[index] = 0;

			for (int i = index+1; i <= Count; i++)
			{
				_internalStorage[i-1] = _internalStorage[i];
			}

			Count--;
			return true;
		}

		public int GetElement(int index)
		{
			if ((index >= _internalStorage.Length) || (index < 0))
				throw new IndexOutOfRangeException();

			return _internalStorage[index];
		}

		public int IndexOf(int item)
		{
			throw new NotImplementedException();
		}

		//private int _count;
		public int Count { get; private set; }

		public void Clear()
		{
			_internalStorage = new int[4];
			Count = 0;
		}

		public bool Contains(int item)
		{
			int i = 0;
			while (i <= Count)
			{
				if (_internalStorage[i] == item) return true;
			}
			return false;
		}


		public static void ListExample(IIntegerList listOfIntegers)
		{
			listOfIntegers.Add(1); // [1]
			listOfIntegers.Add(2); // [1,2]
			listOfIntegers.Add(3); // [1,2,3]
			listOfIntegers.Add(4); // [1,2,3,4]
			listOfIntegers.Add(5); // [1,2,3,4,5]
			listOfIntegers.RemoveAt(0); // [2,3,4,5]
			listOfIntegers.Remove(5); // [2,3,4]
			Console.WriteLine(listOfIntegers.Count); // 3
			Console.WriteLine(listOfIntegers.Remove(100)); //  false
			Console.WriteLine(listOfIntegers.RemoveAt(5)); //  false
			listOfIntegers.Clear(); // []
			Console.WriteLine(listOfIntegers.Count); // 0
		}
	}

	class hw1
	{
		static void Main(string[] args)
		{
			IntegerList myList = new IntegerList();
			IntegerList.ListExample(myList);
		}
	}
}
