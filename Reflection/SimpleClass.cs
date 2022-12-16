namespace Reflection
{
    /// <summary>
    /// Экземпляр класса используется для проверки сериализации/десериализации
    /// </summary>
    public class SimpleClass
    {
        public int i1 { get; set; }
        public int i2 { get; set; }
        public int i3 { get; set; }
        public int i4 { get; set; }
        public int i5 { get; set; }

        public SimpleClass(int j1, int j2, int j3, int j4, int j5)
        {
            i1 = j1;
            i2 = j2;
            i3 = j3;
            i4 = j4;
            i5 = j5;
        }

        /// <summary>
        /// Конструктор по умочанию для корректной работы Десериализатора
        /// </summary>
        public SimpleClass() 
        {
            i1 = new Random().Next(100);
            i2 = new Random().Next(100);
            i3 = new Random().Next(100);
            i4 = new Random().Next(100);
            i5 = new Random().Next(100);
        }
    }
}
