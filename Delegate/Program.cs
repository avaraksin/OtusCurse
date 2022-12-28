using Delegate;

// *************************************************************************************
//                           Д Е Л Е Г А Т 
// *************************************************************************************

// Для примера используем T: int
// Определяем метод GetNumber(int n) типа делегат Func<in int, out float>
Func<int, float> GetNumber = (n) => (float) n;

// Тестовый список для поиска максимального элемента
List<int> myList = new List<int>{ 1, 3, 6, 8, 10, 5 };

string output = string.Empty;
foreach (int i in myList)
{
    output += i.ToString() + ", "; 
}
output = output.Substring(0, output.Length - 2);


Console.Write($"Максимальный элемент коллекции ({output}): ");
// Выводим в консоль максимальный элемент коллекции с помощью метода GetMax,
// где в качестве параметра передаем метод GetNumber
Console.WriteLine(myList.GetMax(GetNumber));

Console.WriteLine();
Console.WriteLine();




// *************************************************************************************
//                           С О Б Ы Т И Е
// *************************************************************************************

string dirName = "C:\\ozon";
Console.WriteLine($"Список файлов директории {dirName}:");

/// <summary>
///  Создаем экземпляр класса, генерирующего событие.
///  В качестве параметра передаем папку C:\ozon
/// </summary>
DirectoryChecker directoryChecker = new DirectoryChecker(dirName);

// Создаем экземпляр класса-подписанта
FileChecker fileChecker = new();

// Подписываемся на событие
directoryChecker.FileFound += fileChecker.NewFileFound;

// Стартуем метод - поиск файло в директории 
directoryChecker.GetFilesInDir();