using System;
using System.Collections.Generic;
using System.Numerics;

namespace Otus.Generics.Demo
{
	public static class MyDefault
	{


		public static void DisplayDefault<T>(T val = default(T))
		{
			Console.WriteLine($"The value of type {typeof(T)} is: {(val == null ? "null" : val.ToString())}");
		}

	}

	class Foo { }

	public class DefaultShower : IBaseDemoShower
	{
		public void Show()
		{
			MyDefault.DisplayDefault<int>();
			MyDefault.DisplayDefault<int>(124);



			MyDefault.DisplayDefault<bool>();

			MyDefault.DisplayDefault<bool>(true);
			MyDefault.DisplayDefault<DateTime>();
			MyDefault.DisplayDefault<Foo>();
			MyDefault.DisplayDefault<string>();
			MyDefault.DisplayDefault<Complex>();
		}
	}
}