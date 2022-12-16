using Reflection;
using Newtonsoft.Json;
using System.Diagnostics;

SimpleClass simpleClass;
string s = String.Empty;
int iter = 100000;

//Создаем экзепляр класса
simpleClass = new();

Console.WriteLine("Класс:");
Console.WriteLine(JsonConvert.SerializeObject(simpleClass));
Console.WriteLine();

// Сериализуем его своим методом
s = MyConverter.SerializeObject(simpleClass);

Console.WriteLine($"Моя сериализация: {s}");
Console.WriteLine();

// Десериализуем своим методом
simpleClass = MyConverter.DeserializeObject<SimpleClass>(s);

Console.WriteLine("Моя десериализация:");
Console.WriteLine(JsonConvert.SerializeObject(simpleClass));
Console.WriteLine();

Console.WriteLine($"Число иттераций: {iter}");
Console.WriteLine("Моя рефлексия.");
Stopwatch stopWatch = new Stopwatch();
stopWatch.Start();
simpleClass = new();

//Замеряем скорость сериализации своего метода
for (int i = 0; i < iter; i++)
{
    s = MyConverter.SerializeObject(simpleClass);
}
stopWatch.Stop();
Console.WriteLine($"Сериализация: {stopWatch.ElapsedMilliseconds} мс" );

stopWatch.Reset();
stopWatch.Start();
//Замеряем скорость десериализации своего метода
for (int i = 0; i < iter; i++)
{
    simpleClass = MyConverter.DeserializeObject<SimpleClass>(s);
}
stopWatch.Stop();
Console.WriteLine($"Десериализация: {stopWatch.ElapsedMilliseconds} мс" );
Console.WriteLine();


// Измеряем скорость NewtonsoftJson
Console.WriteLine("NewtonsoftJson");
Console.WriteLine($"Число иттераций: {iter}");
stopWatch.Reset();
stopWatch.Start();

for (int i = 0; i < iter; i++)
{
    s = JsonConvert.SerializeObject(simpleClass);
}
stopWatch.Stop();
Console.WriteLine($"Сериализация: {stopWatch.ElapsedMilliseconds} мс" );

stopWatch.Reset();
stopWatch.Start();
for (int i = 0; i < iter; i++)
{
    simpleClass = JsonConvert.DeserializeObject<SimpleClass>(s);
}

stopWatch.Stop();
Console.WriteLine($"Десериализация: {stopWatch.ElapsedMilliseconds} мс" );
Console.WriteLine();


