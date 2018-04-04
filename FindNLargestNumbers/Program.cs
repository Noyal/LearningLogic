using System;
using System.Collections.Generic;

namespace LearningLogic.FindNLargestNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int[] intArray = new int[1000 * 1000];
            int i;
            Console.WriteLine("Enter size of the array");
            var arryaLimit = Convert.ToInt32(Console.ReadLine());
            var start = GetMilliseconds();
            for (i = 0; i < arryaLimit; i++)
            {
                intArray[i] = random.Next(1000 * 1000);
            }
            var end = GetMilliseconds();
            Console.WriteLine("Array generated in {0} milliseconds.", end - start);
            Console.WriteLine("Enter the limit of largest numbers in the array");
            var maximumLimit = Convert.ToInt32(Console.ReadLine());
            start = GetMilliseconds();
            var largestElementsIndexMap = FindNLargestNumbers(intArray, maximumLimit);
            end = GetMilliseconds();
            Console.WriteLine("OP method in {0} milliseconds.", end - start);
            Console.ReadKey();
            foreach (var key in largestElementsIndexMap.Keys)
                Console.WriteLine(largestElementsIndexMap[key]);
            Console.ReadKey();

        }
        private static long GetMilliseconds()
        {
            return DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
        }

        private static Dictionary<int, int> FindNLargestNumbers(int[] intArray, int maximumLimit)
        {
            int i, largestIndex;
            var compareArray = intArray;
            var largestElementsIndexMap = new Dictionary<int, int>();
            while (largestElementsIndexMap.Count <= maximumLimit && largestElementsIndexMap.Count <= intArray.Length)
            {
                i = 0;
                largestIndex = 0;
                while (i < intArray.Length)
                {
                    if (largestElementsIndexMap.ContainsKey(i))
                    {
                        i++;
                        continue;
                    }
                    if (largestElementsIndexMap.ContainsValue(intArray[i]))
                    {
                        i++;
                        continue;
                    }
                    if (intArray[i] > compareArray[largestIndex])
                    {
                        largestIndex = i;
                    }
                    i++;
                }
                if (largestElementsIndexMap.ContainsKey(largestIndex))
                    break;
                largestElementsIndexMap.Add(largestIndex, intArray[largestIndex]);
            }
            return largestElementsIndexMap;
        }
    }
}
