using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAB301_Assignment2
{
    public static class Utilities
    {
        public static List<int> createRandomlist(int count)
        {
            Random r = new Random(DateTime.Now.Millisecond);
            List<int> randomList = new List<int>();

            for (int i = 0; i < count; i++)
                randomList.Add(r.Next(0, 100000));

            return randomList;
        }
        
    }
}
