using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace CAB301_Assignment2
{
    class Program
    {

        static void Main(string[] args)
        {
            List<Int32> testList = new List<Int32>
            {
                1,2,3,4,5,6,7,8,9
            };

            List<int> testList2 = new List<int>
            {
                1,2,3,4,5,6,7,8,9,10
            };

            
            
            Console.ReadLine();
        }
        
    }

}

#region dump
//not worth the 2 or so lines of code it saved
//public static void RecordExecutionTimes()
//{
//    Stopwatch stopwatch = new Stopwatch();
//    Func<IList<int>, int?> bfm = l => BruteForceMedian(l);
//    Func<IList<int>, int?> em = l => Median(l);

//    for (int i = 0; i < 500; i++)
//    {
//        Console.WriteLine(i);
//        for (int j = 0; j <= maxTestArrayLength; j += 1)
//        {
//            List<int> testList = createRandomlist(j);

//            stopwatch.recordAlgorithmExecutionTime(testList, bfm);
//            bruteForceMedianResults.Append($"{stopwatch.ElapsedTicks}, "); ;

//            stopwatch.Reset();

//            stopwatch.recordAlgorithmExecutionTime(testList, em);
//            efficientMedianResults.Append($"{stopwatch.ElapsedTicks}, ");

//            stopwatch.Reset();

//        }

//        bruteForceMedianResults.AppendLine("");
//        efficientMedianResults.AppendLine("");

//    }

//    bruteForceMedianResults.Write("BruteForceMedianExecutionTimeResults.csv");
//    efficientMedianResults.Write("EfficientMedianExecutionTimeResults.csv");

//}

//public static T? BruteForceMedian<T>(IList<T> list) where T : struct, IComparable
//{

//    int count = list.Count;
//    int k = (count + 1) / 2;
//    int numSmaller, numEqual, j;

//    for (int i = 0; i < count; i++)
//    {
//        numSmaller = 0;
//        numEqual = 0;

//        for (j = 0; j < count; j++)
//        {
//            if (list[j].CompareTo(list[i]) == -1)
//                numSmaller++;
//            else if (list[i].CompareTo(list[j]) == 0)
//                numEqual++;
//        }

//        if (k > numSmaller && k <= numSmaller + numEqual)
//            return list[i];
//    }

//    return null; //should only return if an empty array is passed in as an arguement

//}

//public static T? EfficientMedian<T>(IList<T> list) where T : struct, IComparable
//{
//    int count = list.Count;

//    if (count == 0)
//        return null;
//    if (count == 1)
//        return list[0];
//    else
//        return Select(list, 0, (count - 1) / 2, count - 1);
//}

//public static T Select<T>(IList<T> list, int low, int medium, int high) where T : IComparable
//{
//    int position = Partition(list, low, high);

//    if (position == medium)
//        return list[position];
//    else if (position > medium)
//        return Select(list, low, medium, position - 1);
//    else
//        return Select(list, position + 1, medium, high);

//}

//public static int Partition<T>(IList<T> list, int low, int high) where T : IComparable
//{
//    T pivotValue = list[low];
//    int pivotLocation = low;

//    for (int i = low + 1; i <= high; i++)
//    {
//        if (list[i].CompareTo(pivotValue) == -1)
//        {
//            pivotLocation++;
//            list.Swap(pivotLocation, i);
//        }
//    }

//    list.Swap(low, pivotLocation);
//    return pivotLocation;
//}
#endregion dump