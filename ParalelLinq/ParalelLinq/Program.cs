
using ParalelLinq;
using System.Diagnostics;

var initArraow = new InitArrow();
var ints = initArraow.initList;

Console.WriteLine($"Число элементов в массиве: {ints.Count()}");
Console.WriteLine();

var calc = new CalculateSum();

Stopwatch Stopwatch= Stopwatch.StartNew();
long sum = calc.CalculateByProcedure(ints);
Stopwatch.Stop();
Console.WriteLine($"Метод. Сумма: {sum}, Время (млс): {Stopwatch.Elapsed.TotalMilliseconds}");