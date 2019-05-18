using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithmGarden.LeetCode
{
    public class _268
    {
        //Given an array containing n distinct numbers taken from 0, 1, 2, ..., n, find the one that is missing from the array.


        /// <summary>
        /// 异或方式，x ^ x =0; x ^ 0 = x 没有溢出
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="range"></param>
        /// <returns></returns>
        public static int GetMissingNumberWithXOR(int[] arr, int range)
        {
            var result = 0;
            for(int i=0; i<arr.Length; i++)
            {
                result = result ^ arr[i];
            }

            for(int i=0; i<=range;i++)
            {
                result = result ^ i;
            }

            return result;
        }

        /// <summary>
        /// 求和方式，有溢出风险
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="range"></param>
        /// <returns></returns>
        public static int GetMissingNumberWithSum(int[] arr, int range)
        {
            int sum = 0;
            var total = (range) * (range + 1) / 2;
            for(int i=0; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            return total - sum;
        }

        /// <summary>
        /// 两个集合的差集
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="range"></param>
        /// <returns></returns>
        public static int[] GetMissingNumber(int[] arr, int range)
        {
            var source = new List<int>(arr);
            var full = Enumerable.Range(arr[0], arr[arr.Length - 1]);

            return full.Except(source).ToArray();
        }

    }
}
