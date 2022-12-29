namespace Delegate
{
    /// <summary>
    /// Класс - подписант на событие класса DirectoryChecker
    /// </summary>
    public class FileChecker
    {
        // Метод сигнатуры EventHandler
        public void NewFileFound(object sender, EventArgs args)
        {
            FileArgs? fileArgs = args as FileArgs;
            if (fileArgs == null) return;


            // Получаем из параметра args имя файла
            // и выводим его в консоль
            Console.WriteLine(fileArgs.FileName);

            Console.WriteLine();
            
            // Запрашиваем пользователя.
            Console.Write("Показать следующий файл(y или Enter / n)? ");
            string? answer = Console.ReadLine();

            // Выставляем свойство GetNext класса-параметра
            fileArgs.GetNext = answer?.ToLower() == "y" || answer == string.Empty;
        }
    }
}
