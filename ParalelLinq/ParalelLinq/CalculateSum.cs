using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParalelLinq
{
    public class CalculateSum
    {
        public long CalculateByProcedure(List<long> ints)
        {
            return ints.Sum();

        }

        public long CalculateByThreads(int[] ints) 
        {
            List<int> intList = ints.ToList();
            Barrier barrier= new Barrier(0);

            int itemsPerThread = intList.Count / 10;

            return 0;
        }
    }
}
