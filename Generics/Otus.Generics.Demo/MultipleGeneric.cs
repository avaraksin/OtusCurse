using System;

namespace Otus.Generics.Demo
{
	// Два обобщенных типа TKey и TValue
	class MyKeyValue<TKey, TValue>
	{
		public MyKeyValue(TKey key, TValue value)
		{
			Key = key;
			Value = value;
		}
		public TKey Key { get; set; }
		public TValue Value { get; set; }

		public override string ToString()
		=> $"Key={Key}, Value={Value}";
	}


	public class MultipleGenericShower : IBaseDemoShower
	{
		public void Show()
		{
			var kv1 = new MyKeyValue<int, string>(1, "Hello");
			var kv2 = new MyKeyValue<float, bool>(1.4f, false);
			Console.WriteLine(kv1);
			Console.WriteLine(kv2);
		}
	}
}