namespace Delegate
{
    /// <summary>
    /// Класс-наследник EventArgs для передечи в событие в качестве параметра
    /// </summary>
    public class FileArgs : EventArgs
    {
        /// <summary>
        /// Имя файла
        /// </summary>
        public string FileName { get; set; }
        
        /// <summary>
        /// Показывать следующий файл
        /// </summary>
        public bool GetNext { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="filename">имя файла</param>
        public FileArgs(string filename)
        {
            FileName = filename;
        }
    }
}
