using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmGarden.MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 3, 1, 2, 4, 5};
            DoMergeSort(numbers);
            for(var i =0;i<numbers.Length;i++)
            {
                Console.Write(numbers[i] + " ");
            }
        }

        //divide, dive the problem into a number of subproblems
        //conquer, conquer the subproblems by solving them recursively.
        //combine the solutions to the subproblems into the solution for the original problem
        //分而治之的思想

        static void DoMergeSort(int[] numbers)
        {
            var sortedNumbers = MergeSort(numbers);
            for(int i=0; i < sortedNumbers.Length; i++)
            {
                numbers[i] = sortedNumbers[i];
            }
        }

        static int[] MergeSort(int[] numbers)
        {
            if (numbers.Length <= 1) return numbers;

            var left = new List<int>();
            var right = new List<int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                if (i % 2 > 0)
                {
                    left.Add(numbers[i]);
                }
                else
                {
                    right.Add(numbers[i]);
                }
            }

            //不断地拆分
            left = MergeSort(left.ToArray()).ToList();
            right = MergeSort(right.ToArray()).ToList();

            //最后合并
            return Merge(left, right);
        }

        static int[] Merge(List<int> left, List<int> right)
        {
            var result = new List<int>();

            while(left.Count>0&&right.Count>0)
            {
                if(left.First()<=right.First())
                {
                    result.Add(left.First());
                    left.RemoveAt(0);
                }
                else
                {
                    result.Add(right.First());
                    right.RemoveAt(0);
                }
            }

            while(NotEmpty(left))
            {
                result.Add(left.First());
                left.RemoveAt(0);
            }

            while(NotEmpty(right))
            {
                result.Add(right.First());
                right.RemoveAt(0);
            }

            return result.ToArray();
        }

        static bool NotEmpty(List<int> list)
        {
            return list.Count > 0;
        }
    }

    
}
