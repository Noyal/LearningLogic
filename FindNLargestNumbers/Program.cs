using System;
using System.Collections.Generic;

namespace LearningLogic.FindNLargestNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var intArray = new List<int>()
            {
                314, 343, 380, 260, 827, 551
            };
            var compareArray = intArray;
            var largestElementsIndexMap = new Dictionary<int, int>();
            int i, largestIndex, j = 0, k = 1, maximumLimit;
            Console.WriteLine("Enter the limit of largest numbers in the array");
            maximumLimit = Convert.ToInt32(Console.ReadLine());
            while (largestElementsIndexMap.Count <= maximumLimit && largestElementsIndexMap.Count <= intArray.Count)
            {
                i = 0;
                largestIndex = 0;
                while (i < intArray.Count)
                {
                    if (largestElementsIndexMap.ContainsKey(i))
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
            foreach (var key in largestElementsIndexMap.Keys)
                Console.WriteLine(largestElementsIndexMap[key]);
            Console.ReadKey();
        }
    }
}
