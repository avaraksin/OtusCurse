namespace ParalelLinq
{
    /// <summary>
    /// Создаем начальный массив интов
    /// </summary>
    public class InitArray
    {
        private readonly int _arraySize = 10000000;
        public int[] ints { get; }

        public InitArray(int arraySize) 
        {
            _arraySize = arraySize;
            ints = new int[_arraySize];
            for(int i = 0; i < _arraySize; i++)
            {
                var item = new Random().Next(0, 100000000);
                ints[i] = item;
            }
        }
    }
}
