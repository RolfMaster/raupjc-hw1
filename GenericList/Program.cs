using System;


namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] args)
		{
			GenericList<String> a = new GenericList<string>();

			a.Add("ovi");
			a.Add("stringovi");
			a.Add("se");
			a.Add("ispisuju");
			a.Add("na ekran");

			/*
			a.RemoveAt(2);
			a.Remove("smrad");
			int b = a.Count;
			bool boo = a.Contains("najgori");
			bool bo = a.Remove("najgorši");
			a.Clear();
			b = a.Count;
			*/

			foreach (var i in a)
			{
				Console.Out.WriteLine(i);
			}
		}
	}
}
