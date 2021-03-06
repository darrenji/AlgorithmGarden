﻿using AlgorithmGarden.Algorithms.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmGarden.Algorithms.Sorting
{

    public class BubbleSortSimple
    {
        public static void BubbleSort(int[] arr)
        {
            int i, j, temp;
            for(i=0;i<arr.Length;i++)
            {
                for(j=0;j<arr.Length-1-i;j++)
                {
                    if(arr[j]>arr[j+1])
                    {
                        temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }

        //如果没有交换的时候应该及时退出循环
        public static void BubbleSort1(int[] arr)
        {
            int i, j, temp;
            for (i = 0; i < arr.Length; i++)
            {
                bool IsSwapped = false;
                for (j = 0; j < arr.Length - 1 - i; j++)
                {
                   
                    if (arr[j] > arr[j + 1])
                    {
                        temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                        IsSwapped = true;
                    }
                }

                if(!IsSwapped)
                {
                    break;
                }
            }
        }

        //最差时间复杂度O(n^2)
        //最好时间复杂度O(n)
        //平均时间复杂度O(n^2)
        //空间复杂度O(1) 数组要了一块内存空间
    }
    /* 怎么来评价排序的效率呢？
     * 考虑最好、最差、平均复杂度，因为原始数据有些有序、有些无序，情况不一样
     * 当n趋向于无穷大的时候，会把常数、系数、低阶不考虑，但数据量很小的时候这些就需要考虑了
     * 要考虑元素的比较和交换次数
    */

    /*
     排序算法的内存消耗
     把空间复杂度O(1)的叫做原地排序(Sorted in place)
     */

    /*
     排序算法的稳定性是考量排序的一个标准
     如果排序的数据中存在相等的2个数据，排完序后，相等的2个数据原来的顺序还是不变
     为什么这样就是稳定呢？好奇怪！
     订单有下单时间和订单金额
     先按金额大小升序排列，再按下单时间从早到晚升序排列
     最正常的思路就是先按金额排序，再按下单时间排序，这样时间复杂度就高了
     如果按照稳定排序，首先按时间排序，再按金额排序，按金额排序之后，就不需要排序时间了，因为是稳定的，顺序会和按金额排序之前的顺序一样
     */

    /*
     冒泡排序每次比较相邻的两个元素
     初始状态 456321
     第一次冒泡 453216
     第二次冒泡 432156
     第三次冒泡 321456
     第四次冒泡 213456
     第五次冒泡 123456
     第六次冒泡 123456
     也就是6个元素最多走6次冒泡

     有时候用不到6次，那就对没有位置交换的打标记
     如果没有位置交换，那就说明冒泡排序要结束了

     只需要常量级的临时空间，空间复杂度O(1)，原地排序算法
     当有两个相等的元素，顺序不做交换，所以是稳定排序算法
     最好情况下，数据已经有序了，只需要一次遍历，最好情况复杂度O(n)
     最坏情况复杂度O(n^2)

     平均时间复杂度，加权平均期望时间复杂度
     阶乘，n!=n×(n-1)×(n-2)x…x3x2x1

     有序度，数组中有序关系的元素对个数，从小到大
     有序度满足：a[i] <= a[j] i <j
     2,4,3,1,5,6中有几个有序度呢？
     2,4 2,3 2,5 2,6 4,5, 4,6 3,5 3,6 1,5 1,6 5,6总共11个
     如果完全有序的数组，有序度时n*(n-1)/2，叫满有序度
     逆有序度i<j a[i] >= a[j]
     逆序度+有序度=满有序度
     可以把排序过程看作增加有序度，减少逆有序度，当达到满有序度的时候排序完成

     从有序度的角度看冒泡排序
     初始状态：456321  有序度3
     第一次冒泡：453216 有序度6
     第二次冒泡：432156 有序度9
     第三次冒泡：321456 有序度12
     第四次冒泡：213456 有序度14
     第五次冒泡：123456 有序度15

     每交换一次，有序度加1，这里做了15-3=12次交换

     对于n个数据的数组进行冒泡排序，平均交换次数多少？
     最坏情况，初始状态有序度0，要进行n*(n-1)/2次交换
     最好情况，初始状态有序度n*(n-1)/2,交换0次
     平均情况，就算时n*(n-1)/4
     */

    public class BubbleSorterHelper
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="n">数组的长度</param>
        public void BubbleSort(int[] source, int n)
        {
            //考虑特殊情况
            if (n <= 1) return;
            for(int i=0;i<n;i++) //这里决定遍历次数
            {
                //找一个标识，是否要提前退出冒泡，即是否没有位置交换了，就需要提前退出了
                bool flag = false;

                //比较的次数
                //每次冒泡后最大的那个就放在了最后一位，所以这个就不比较了，所以n-i
                //最后一个位置本来就不需要比较，所以-1
                for(int j =0; j < n-i-1;j++)
                {
                    if(source[j] > source[j+1])
                    {
                        int temp = source[j];
                        source[j] = source[j + 1];
                        source[j + 1] = temp;
                        flag = true;//表示有数据交换
                    }
                }

                if (!flag) break; //没有数据交换，提前退出
            }
        }
    }

    public static class BubbleSorter
    {
        public static void BubbleSort<T>(this IList<T> collection, Comparer<T> comparer = null)
        {
            comparer = comparer ?? Comparer<T>.Default;
            collection.BubbleSortAscending(comparer);
        }

        public static void BubbleSortAscending<T>(this IList<T> collection, Comparer<T> comparer)
        {
            //有多少个元素就遍历多少次
            for(int i=0;i<collection.Count;i++)
            {
                //如果为true的话就退出本次遍历
                bool flag = false;

                //最后一个元素不进行比较
                for(int j=0;j<collection.Count-1;j++)
                {
                    var currentItem = collection[j];
                    var nextItem = collection[j + 1];
                    if(comparer.Compare(currentItem, nextItem)>0)
                    {
                        collection.Swap(j, j + 1);
                        flag = true;
                    }
                }

                if (!flag) break;
            }
        }

        public static void BubbleSortDescending<T>(this IList<T> collection, Comparer<T> comparer)
        {
            //最后一个元素不管它
            for (int i = 0; i < collection.Count-1; i++)
            {
                bool flag = false;
                //比较从第二个元素开始
                //最后几个元素不管，因为是冒泡到那的
                for(int index=1;index<collection.Count-i;index++)
                {
                    var currentItem = collection[index];
                    var lastItem = collection[index - 1];
                    if(comparer.Compare(currentItem, lastItem)>0)
                    {
                        collection.Swap(index - 1, index);
                    }
                }
            }
        }
    }

}
