namespace ParalelLinq
{
    public class CalculateSum
    {
        /// <summary>
        /// Вычмсляем сумму массива в методе.
        /// </summary>
        /// <param name="ints"></param>
        /// <returns></returns>
        public static long CalculateByProcedure(int[] ints)
        {
            return ints.Aggregate<int, long>(0,
                        (total, next) => total + next
                    );
        }

        /// <summary>
        /// Создавая новые таски
        /// </summary>
        /// <param name="ints"></param>
        /// <returns></returns>
        public static long CalculateByThreads(int[] ints) 
        {
            int itemsCount = ints.Length;
            
            // Вычисляем необходимые переменные для 
            // правильного задания диапазонов в тасках
            int itemsPerThread = itemsCount / 4;
            int addOne = itemsCount % itemsPerThread == 0 ? 0 : 1;
            int threadsCount = itemsCount / itemsPerThread + addOne;
            long[] sums = new long[itemsCount / itemsPerThread + addOne];
            List<Task> tasks = new ();

            int j = 0;

            for (int i = 0; i < itemsCount; i += itemsPerThread)
            {
                // Каждой таске передается своя переменная на вход!
                TaskVar taskvar = new()
                {
                    list = ints.Skip(i).Take(itemsPerThread).ToArray(),
                };

                // Запускаем таски.
                tasks.Add(Task.Factory.StartNew(
                    () => 
                    { 
                        sums[j++] = taskvar.list.Aggregate<int, long>(0, (total, next) => total + next); 
                    }));
            }

            //Ждем завершения работы всех тасок
            Task.WaitAll(tasks.ToArray());
            return sums.Aggregate<long, long>(0, (total, next) => total + next);
        }

        /// <summary>
        /// Вымчсляем сумму массива через PLinq
        /// </summary>
        /// <param name="ints"></param>
        /// <returns></returns>
        public static long PLinq(int[] ints)
        {
            return ints.AsParallel().Aggregate<int, long>(0, 
                        (total, next) => total + next
                    );
        }
    }
}
