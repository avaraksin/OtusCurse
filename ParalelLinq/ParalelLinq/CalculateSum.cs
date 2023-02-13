
namespace ParalelLinq
{
    public static class CalculateSum
    {
        /// <summary>
        /// Вычмсляем сумму массива в методе.
        /// </summary>
        /// <param name="ints"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Создавая новые таски
        /// </summary>
        /// <param name="ints"></param>
        /// <returns></returns>
        public static long CalculateByThreads(int[] ints) 
        {
            // Преобразуем в лист лонгов
            List<long> intList = new List<long>();
            int itemsCount = ints.Length;
            for (int i = 0; i < itemsCount; i++)
            {
                intList.Add(ints[i]);
            }
            
            // Вычисляем необходимые переменные для 
            // правильного задания диапазонов в тасках
            int itemsPerThread = itemsCount / 4;
            int addOne = itemsCount % itemsPerThread == 0 ? 0 : 1;
            int threadsCount = itemsCount / itemsPerThread + addOne;
            List<long> sums = new List<long>();
            List<Task> tasks = new List<Task>();
            
            for (int i = 0; i < itemsCount; i += itemsPerThread)
            {
                // Каждой таске передается своя переменная на вход!
                TaskVar taskvar = new()
                {
                    list = intList.Skip(i).Take(itemsPerThread).ToList(),
                };

                // Запускаем таски.
                tasks.Add(Task.Factory.StartNew(
                    () => sums.Add(taskvar.list.Sum())
                ));
            }

            //Ждем завершения работы всех тасок
            Task.WaitAll(tasks.ToArray());
            return sums.Sum();
        }

        /// <summary>
        /// Вымчсляем сумму массива через PLinq
        /// </summary>
        /// <param name="ints"></param>
        /// <returns></returns>
        public static long PLinq(int[] ints)
        {
            // Преобразуем в лист лонгов
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
