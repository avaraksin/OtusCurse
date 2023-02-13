
namespace ParalelLinq
{
    public static class CalculateSum
    {
        public static long CalculateByProcedure(int[] ints)
        {
            // Перекладываем массив интов в лист лонгов.
            // Иначе происходит переполнение.
            List<long> items = new List<long>();
            foreach (int i in ints)
            {
                items.Add(i);
            }

            return items.Sum();
        }

        public static long CalculateByThreads(int[] ints) 
        {
            List<long> intList = new List<long>();
            int itemsCount = ints.Length;
            for (int i = 0; i < itemsCount; i++)
            {
                intList.Add(ints[i]);
            }
            
            int itemsPerThread = itemsCount / 4;
            int addOne = itemsCount % itemsPerThread == 0 ? 0 : 1;
            int threadsCount = itemsCount / itemsPerThread + addOne;
            List<long> sums = new List<long>();
            List<Task> tasks = new List<Task>();
            for (int i = 0; i < itemsCount; i += itemsPerThread)
            {
                TaskVar taskvar = new()
                {
                    list = intList.Skip(i).Take(itemsPerThread).ToList(),
                };
                tasks.Add(Task.Factory.StartNew(
                    () => sums.Add(taskvar.list.Sum())
                ));
            }

            Task.WaitAll(tasks.ToArray());
            return sums.Sum();
        }

        public static long PLinq(int[] ints)
        {
            List<long> intList = new List<long>();
            int itemsCount = ints.Length;
            for (int i = 0; i < itemsCount; i++)
            {
                intList.Add(ints[i]);
            }

            return intList.AsParallel().Sum();
        }
    }
}
