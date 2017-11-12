﻿using System.Collections.Generic; //ovdje moram koristiti System.Collections zbog IEnumerable

namespace ConsoleApp1
{
	public interface IGenericList<X> : IEnumerable<X>
	{
		/// <summary >
		/// Adds an item to the  collection.
		///  </summary >
		void Add(X item);

		/// <summary >
		/// Removes  the  first  occurrence  of an item  from  the  collection.
		/// If the  item  was  not found , method  does  nothing.
		///  </summary >
		bool Remove(X item);

		/// <summary >
		/// Removes  the  item at the  given  index in the  collection.
		///  </summary >
		bool RemoveAt(int index);

		/// <summary >
		/// Returns  the  item at the  given  index in the  collection.
		///  </summary >
		X GetElement(int index);

		/// <summary >
		/// Returns  the  index of the  item in the  collection.
		/// If item is not  found in the  collection , method  returns  -1.
		///  </summary >
		int IndexOf(X item);

		/// <summary >
		/// Readonly  property. Gets  the  number  of  items  contained  in the collection.
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
}