using System;

namespace AlgorithmGarden.BinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 3, 5, 8, 9, 10, 12};
            int length = arr.Length;
            int query = 9;

            int result = BinarySearch(arr, 0, length - 1, query);
            if(result==-1)
            {
                Console.WriteLine($"找不到元素{query}");
            }
            else
            {
                Console.WriteLine($"{query}在{result}号位");
            }


        }

        //对数时间复杂度O(logn)
        static int BinarySearch(int[] arr, int l, int r, int x)
        {
            if(r>=l)
            {
                //不管是奇数还是偶数找到中间位置的方式如下
                int middle = l + (r - 1) / 2;

                //如果中间位置上的元素就是要找的元素就返回
                if (arr[middle] == x)
                    return middle;

                //如果中间位置上的元素大于要找的元素，就在左半部分继续寻找
                if (arr[middle] > x)
                    return BinarySearch(arr, l, middle - 1, x);

                //如果中间位置上的元素小于要找的元素，就在右半部分继续寻找
                if (arr[middle] < x)
                    return BinarySearch(arr, middle + 1, r, x);
            }
            return -1;
        }
    }
}
