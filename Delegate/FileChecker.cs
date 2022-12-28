namespace Delegate
{
    /// <summary>
    /// Класс - подписант на событие класса DeerictoryChecker
    /// </summary>
    public class FileChecker
    {
        // Метод сигнатуры EventHandler
        public void NewFileFound(object sender, EventArgs args)
        {
            // Получаем из параметра args имя файла
            // и выводим его в консоль
            Console.WriteLine(((FileArgs)args).FileName);

            Console.WriteLine();
            
            // Запрашиваем пользователя.
            Console.Write("Показать следующий файл(y или Enter / n)? ");
            string? answer = Console.ReadLine();

            // Выставляем свойство GetNext класса-параметра
            ((FileArgs)args).GetNext = answer?.ToLower() == "y" || answer == string.Empty;
        }
    }
}
