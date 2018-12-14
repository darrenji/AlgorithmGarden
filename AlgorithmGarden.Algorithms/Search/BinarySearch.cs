using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmGarden.Algotithms.Search
{
    public class BinarySearchHelper 
    {
        //对数时间复杂度O(logn)
        public int BinarySearch(int[] arr, int l, int r, int x)
        {
            if (r >= l)
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

        /*
         1 3 4 5 13 20 25 40 42 44 53
         如何用二分法找到13呢？当然前提是已经排好序了。
         这里有11个元素，索引位置从0-10
         中间位置是20，index=5
         5 = 0 + (11-1)/2
         */
    }
}
