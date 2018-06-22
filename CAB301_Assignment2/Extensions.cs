using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAB301_Assignment2
{
    public static class Extensions
    {
        public static void Swap<T>(this IList<T> list, int first, int second)
        {
            T firstTemp = list[first];
            list[first] = list[second];
            list[second] = firstTemp;
        }

        public static void Print<T>(this IList<T> list)
        {
            for (int i = 0; i < list.Count - 1; i++)
                Console.Write($"{i}, ");

            Console.WriteLine(list[list.Count - 1]);
        }

        public static void Write(this StringBuilder csv, string fileName)
        {
            try
            {
                string path = fileName;

                if (File.Exists(path))
                    File.Delete(path);

                using (FileStream stream = File.Create(path))
                {
                    byte[] csvBytes = new UTF8Encoding(true).GetBytes(csv.ToString());
                    stream.Write(csvBytes, 0, csvBytes.Length);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }                   

        public static void recordAlgorithmExecutionTime<T>(this Stopwatch stopwatch, IList<T> list, Func<IList<T>, T?> method)
            where T : struct, IComparable
        {
            stopwatch.Start();
            method(list);
            stopwatch.Stop();
        }

    }
}
