using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAB301_Assignment2
{
    public class Algorithms
    {

        private int partitionCounter = 0;
        private int bruteForceCounter = 0;

        private int maxTestArrayLength = 1000;
        private int numberOfTrials = 500;

        private void resetCounters()
        {
            partitionCounter = 0;
            bruteForceCounter = 0;
        }

        public StringBuilder initialiseStringBuilder()
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i <= maxTestArrayLength; i++)
                stringBuilder.Append($"{i},");

            stringBuilder.AppendLine("");

            return stringBuilder;
        }

        #region data_collection
        public void RecordExecutionTimes()
        {
            StringBuilder bruteForceMedianResults = initialiseStringBuilder();
            StringBuilder partitionMedianResults = initialiseStringBuilder();
            Stopwatch stopwatch = new Stopwatch();
            

            for (int i = 0; i < numberOfTrials; i++)
            {
                Console.WriteLine(i);
                for (int j = 0; j <= maxTestArrayLength; j++)
                {
                    List<int> testList = Utilities.createRandomlist(j);
                    stopwatch.Start();
                    BruteForceMedian(testList);
                    stopwatch.Stop();
                    bruteForceMedianResults.Append($"{stopwatch.ElapsedTicks}, "); ;

                    stopwatch.Reset();

                    stopwatch.Start();
                    PartitionMedian(testList);
                    stopwatch.Stop();
                    partitionMedianResults.Append($"{stopwatch.ElapsedTicks}, ");

                    stopwatch.Reset();

                }

                bruteForceMedianResults.AppendLine("");
                partitionMedianResults.AppendLine("");

            }

            bruteForceMedianResults.Write("BruteForceMedianExecutionTimeResults.csv");
            partitionMedianResults.Write("PartitionMedianExecutionTimeResults.csv");

        }
        
        public void RecordBasicOperations()
        {
            StringBuilder bruteForceMedianResults = initialiseStringBuilder();
            StringBuilder partitionMedianResults = initialiseStringBuilder();

            for (int i = 0; i < numberOfTrials; i++)
            {
                Console.WriteLine(i);
                for (int j = 0; j <= maxTestArrayLength; j += 1)
                {
                    List<int> testList = Utilities.createRandomlist(j);

                    BruteForceMedian(testList);
                    bruteForceMedianResults.Append($"{this.bruteForceCounter}, "); ;

                    PartitionMedian(testList);
                    partitionMedianResults.Append($"{this.partitionCounter}, ");

                    resetCounters();
                }

                bruteForceMedianResults.AppendLine("");
                partitionMedianResults.AppendLine("");

            }

            bruteForceMedianResults.Write("BruteForceMedianBasicOperationsResults.csv");
            partitionMedianResults.Write("PartitionMedianBasicOperationsResults.csv");
        }
        #endregion data_collection

        #region algorithms
        #region brute_force
        public T? BruteForceMedian<T>(IList<T> list) where T : struct, IComparable
        {
            int count = list.Count;
            int k = (count+1) / 2;
            int numSmaller, numEqual, j;

            for (int i = 0; i < count; i++)
            {
                numSmaller = 0;
                numEqual = 0;

                for (j = 0; j < count; j++)
                {
                    //this.bruteForceCounter++; //COMMENT WHEN RECORDING EXECUTION TIME

                    if (list[j].CompareTo(list[i]) == -1)
                        numSmaller++;
                    else if (list[i].CompareTo(list[j]) == 0)
                        numEqual++;
                }

                if (numSmaller < k && k <= numSmaller + numEqual)
                    return list[i];
            }

            return null;

        }
        #endregion brute_force

        #region partition
        public T? PartitionMedian<T>(IList<T> list) where T : struct, IComparable
        {
            int count = list.Count;

            if (count == 0)
                return null;
            else if (count == 1)
                return list[0];
            else
                return Select(list, 0, count / 2, count - 1);
        }

        public T Select<T>(IList<T> list, int low, int middle, int high) where T : IComparable
        {
            int position = Partition(list, low, high);

            if (position == middle)
                return list[position];
            else if (position > middle)
                return Select(list, low, middle, position - 1);
            else
                return Select(list, position + 1, middle, high);

        }

        public int Partition<T>(IList<T> list, int low, int high) where T : IComparable
        {
            T pivotValue = list[low];
            int pivotLocation = low;

            for (int i = low + 1; i <= high; i++)
            {
                //partitionCounter++; //COMMENT WHEN RECORDING EXECUTION TIME
                if (list[i].CompareTo(pivotValue) == -1)
                {
                    pivotLocation++;
                    list.Swap(pivotLocation, i);
                }
            }

            list.Swap(low, pivotLocation);
            return pivotLocation;
        }
        #endregion partition
        #endregion algorithms
    }
}
