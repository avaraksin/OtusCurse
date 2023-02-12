namespace ParalelLinq
{
    /// <summary>
    /// Создаем начальный массив интов
    /// </summary>
    public class InitArrow
    {
        private const int _array = 10000000;
       public List<long> initList { get; private set; }

        public InitArrow() 
        {
            initList= new List<long>();
            for(int i = 0; i < _array; i++)
            {
                var item = new Random().Next(0, 100000000);
                initList.Add(item);
            }
        }
    }
}
