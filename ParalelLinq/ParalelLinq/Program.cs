
using ParalelLinq;
using System.Diagnostics;

var initArraow = new InitArrow();
var ints = initArraow.ints;

Console.WriteLine($"Число элементов в массиве: {ints.Length}");
Console.WriteLine();

long sum;

Stopwatch stopwatch = Stopwatch.StartNew();
sum = CalculateSum.PLinq(ints);
stopwatch.Stop();
Console.WriteLine($"PLinq\tСумма: {sum}\tВремя (млс): {stopwatch.Elapsed.TotalMilliseconds}");
Task.Delay(1000).Wait();

stopwatch.Restart();
sum = CalculateSum.CalculateByThreads(ints);
stopwatch.Stop();
Console.WriteLine($"Threads\tСумма: {sum}\tВремя (млс): {stopwatch.Elapsed.TotalMilliseconds}");
Task.Delay(1000).Wait();

stopwatch.Restart();
sum = CalculateSum.CalculateByProcedure(ints);
stopwatch.Stop();
Console.WriteLine($"Метод.\tСумма: {sum}\tВремя (млс): {stopwatch.Elapsed.TotalMilliseconds}");



