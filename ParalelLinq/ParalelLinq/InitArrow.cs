namespace ParalelLinq
{
    /// <summary>
    /// Создаем начальный массив интов
    /// </summary>
    public class InitArrow
    {
        private const int _array = 10000000;
        public int[] ints { get; }

        public InitArrow() 
        {
            ints = new int[_array];
            for(int i = 0; i < _array; i++)
            {
                var item = new Random().Next(0, 100000000);
                ints[i] = item;
            }
        }
    }
}
