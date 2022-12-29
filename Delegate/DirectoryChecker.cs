namespace Delegate
{
    /// <summary>
    /// Класс, генерирующий событие FileFound
    /// </summary>
    public class DirectoryChecker
    {
        /// <summary>
        /// Директория
        /// </summary>
        private string dirName;

        /// <summary>
        /// Событие типа делегата EventHandler
        /// </summary>
        public event EventHandler? FileFound;

        /// <summary>
        /// Конструктор класса, передаем директорию
        /// </summary>
        /// <param name="dirName">Директория</param>
        public DirectoryChecker(string dirName)
        {
            this.dirName = dirName;
        }

        /// <summary>
        /// Метод поиска всех файлов в директории dirName
        /// </summary>
        public void GetFilesInDir()
        {
            // Получаем список файлов в директории
            string[]? files = Directory.GetFiles(dirName);
            
            // Цикл по  всем файлам
            foreach (string file in files)
            {
                FileArgs fileArgs = new FileArgs(file);
                
                // Генерируем событие. В качестве параметра передаем класс FileArgs - 
                // наследник EventArgs
                FileFound?.Invoke(this, fileArgs);
                
                
                // Показывать следующий файл - передает подписант
                // через свойство класса - параметра события
                if (fileArgs.GetNext == false) break;
            }            
        }
    }
}
