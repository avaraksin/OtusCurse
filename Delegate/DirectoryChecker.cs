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
            // Номер файла в массиве
            int fileNumber = 0;

            // массив файлов
            string[]? files;

            // Выводить следующий файл
            bool next = true;

            // Получаем списокфайлов в директории
            files = Directory.GetFiles(dirName);
            
            // Цикл по  всем файлам
            while (fileNumber < files.Length && next)
            {
                FileArgs fileArgs = new (string.Empty);
                
                // Генерируем событие. В качестве параметра передаем класс FileArgs - 
                // наследник EventArgs
                FileFound?.Invoke(this, fileArgs = new FileArgs(files[fileNumber]));
                
                fileNumber++;

                // Показывать следующий файл - передает подписант
                // через свойство класса - параметра события
                next = fileArgs.GetNext;
            }
            
        }


}
}
