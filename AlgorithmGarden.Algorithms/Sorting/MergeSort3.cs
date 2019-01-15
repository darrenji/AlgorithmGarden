using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmGarden.Algorithms.Sorting
{
   public  class MergeSort3
    {
        public static void DoMergeSort(int[] arr)
        {
            MergeSort(arr, new int[arr.Length], 0, arr.Length - 1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="leftStart">最小的索引</param>
        /// <param name="rightEnd">最大的索引</param>
        public static void MergeSort(int[] arr, int[] temp, int leftStart, int rightEnd)
        {
            if (leftStart >= rightEnd) return;

            //分
            int middle = (leftStart + rightEnd) / 2;
            MergeSort(arr, temp, leftStart, middle);
            MergeSort(arr, temp, middle + 1, rightEnd);

            //合
            MergeHalves(arr, temp, leftStart, rightEnd);
        }

        //排序并合并
        public static void MergeHalves(int[] array, int[] temp, int leftStart, int rightEnd)
        {
            int leftEnd = (rightEnd + leftStart) / 2; //左边结束的位置
            int rightStart = leftEnd + 1;//右边开始的位置
            int size = rightEnd - leftStart + 1; //总共的元素个数

            int left = leftStart;//左边开始的位置，游标
            int right = rightStart;//右边开始的位置，游标
            int index = leftStart;//游标索引
            while(left <= leftEnd && right <=rightEnd)
            {
                if(array[left] <= array[right])
                {
                    temp[index] = array[left];
                    left++;
                }
                else
                {
                    temp[index] = array[right];
                    right++;
                }
                index++;
            }

            //处理剩余的
            Array.Copy(array, left, temp, index, leftEnd - left + 1);
            Array.Copy(array, right, temp, index, rightEnd - right + 1);
            Array.Copy(temp, leftStart, array, leftStart, size);
        }
    }
}
