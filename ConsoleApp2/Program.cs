using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad1
{
	class Program
	{
		static void Main(string[] args)
		{
			IntegerList a = new IntegerList();

			a.Add(1);
			a.Add(5);
			a.Add(-2);
			a.Add(3);
			a.Add(10);

			a.RemoveAt(2);
			a.Remove(5);
			int b = a.Count;
			bool boo = a.Contains(69);
			bool bo = a.Remove(24);
			a.Clear();
			b = a.Count;

		}
	}
}
