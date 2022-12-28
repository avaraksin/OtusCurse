using Delegate;

Func<int, float> GetNumber = (n) => (float) n;

IEnumerable<int> myList = new List<int>{ 1, 3, 6, 8, 10, 5 };

Console.WriteLine(myList.GetMax(GetNumber));
