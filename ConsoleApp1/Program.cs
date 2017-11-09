using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] args)
		{
			GenericList<String> a = new GenericList<string>();

			a.Add("bobo");
			a.Add("smrad");
			a.Add("je");
			a.Add("najbolji");
			a.Add("ikad");


			a.RemoveAt(2);
			a.Remove("smrad");
			int b = a.Count;
			bool boo = a.Contains("najgori");
			bool bo = a.Remove("najgorši");
			a.Clear();
			b = a.Count;
		}
	}
}
