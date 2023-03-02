using ParalelLinq;
using System.Diagnostics;
using System.Globalization;

for (int i = 0; i < 3; i++)
{
    var initArray = new InitArray(100000 * (int)Math.Pow(10, i));
    var ints = initArray.ints;

    var format = (NumberFormatInfo)CultureInfo.InvariantCulture.NumberFormat.Clone();
    format.NumberGroupSeparator = " ";
    format.NumberDecimalDigits = 0;

    Console.WriteLine($"Число элементов в массиве: {ints.Length.ToString("N", format)}");
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

    Console.WriteLine();
    Console.WriteLine();
}



