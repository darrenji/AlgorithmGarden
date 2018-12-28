using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithmGarden.Maths
{
    /*
     递归
     */

    //在归纳思想中看到了递归的影子，也就是递归的前提是归纳是正确的
    //递归和迭代怎么说呢？有了迭代为什么还要递归呢？是因为在有些场景下，递归更容易实现。

    /*
     有四种面额的钱：1元、2元、5元、10元，如果想得到10元，共有几种给发呢？
     也就是，在限定总和的情况下，求所有加和的可能性

     既然是求和，总是一步一步求出来的，先用迭代来考虑。
     当n=1，比如拿1元
     当n=2,比如拿2元或5元
     ....
     这样的可能性简直太多了！

     如果用递归呢？
     当有了归纳，就很容易给出递归方法。
     但是，这里不是要计算一个最终的值，而是要列举出所有的可能性。

     比较常见的归纳思想是这样的：
     首先考虑初始状态，边界条件，n=1的时候，命题是否成立；
     当n=k-1的时候命题成立，当n=k的时候命题也成立，且n>1；

     放到这里的场景，还可以抽象化成：
     当n=1时，问题如何解决。
     假设当n=k-1时问题已经解决，当n=k时问题如何解决。

     再具体一点。
     当n=k-1，可以算出有多少种可能。
     当n=k，会有哪些可能。剩下需要多少可以领。
     当n=1，会有哪些可能。
     */

    public class DiGuiHelper
    {
        public static long[] rewards = { 1, 2, 5, 10 };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="totalReward">剩余多少没拿</param>
        /// <param name="result">临时结果</param>
        public static void Get(long totalReward, List<long> result)
        {
            //totalReward可以理解为游标，不断地变，根据这个游标决定要做的逻辑,并且确保递归不会进入死循环
            //递归总有一个临时变量
            if (totalReward == 0)
            {
                Console.WriteLine(string.Join(',', result));
                return;
            }
            else if (totalReward < 0)
            {
                return;
            }
            else
            {
                for (int i = 0; i < rewards.Length; i++)
                {
                    List<long> newResult = new List<long>(result);
                    newResult.Add(rewards[i]); //记录当前的选择，每次就解决一点问题
                    Get(totalReward - rewards[i], newResult);//不管了，递归去解决
                }
            }
        }
    }

    /*
     递归与归并排序merge sort
     归并，把两个有序的数列合并起来变成一个更大的有序数列

     比如合并两个有序数列A和B
     开辟一个新的存储空间C，用户保存合并后的结果
     比较两个数列的第一个数，如果A数列的第一个数小于B数列的第一个数，就把A数列的第一个数放入C，并把这个数从A数列中删除。
     总之就是把更小的一个数放入C队列，并把该数从所在队列删除。
     如果到某一步A或B数列为空，就直接将另一个数列中剩下的数依次取出放入C。

     数列A：1 2 5 8
     数列B：3 4 6
     数列C：

     数列A：2 5 8
     数列B：3 4 6
     数列C：1

     数列A：5 8
     数列B：3 4 6
     数列C：1 2

     数列A：5 8
     数列B：4 6
     数列C：1 2 3

     数列A：5 8
     数列B：6
     数列C：1 2 3 4

     数列A：8
     数列B：6
     数列C：1 2 3 4 5

     数列A：8
     数列B：
     数列C：1 2 3 4 5 6

     数列A：
     数列B：
     数列C：1 2 3 4 5 6 8

     归并排序的前提是，排序前两个数列都是有序的。
     如果归并前两个数列不是有序呢？
     其实可以用递归解决。

     归并排序体现了分而治之的思想，Divide and Conquer
     将一个复杂的问题分解成多个类似的子问题
     直到子问题变得很简单，可以被求解。
     同样体现了等价思想。
     归并排序每次把长度对半分，只要经过log2^n次归并就可以得到结果。
     实现是用递归实现的。

     7 6 2 4 1 9 3 8 0 5
     7 6 2 4 1 | 9 3 8 0 5
     
     7 6 | 2 4 1
     76   2  41
     76   2  4 1
     67   2 14
     67   124
     12467

     93 805
     93 8 05
     93 8 0 5
     39 8 05
     39 258
     03589

     12467 03589
     0123456789
     */

    public class DiGuiAndGuiBing
    {
        /// <summary>
        /// 归并排序
        /// </summary>
        /// <param name="to_sort">等待归并排序的数组</param>
        /// <returns>返回按升序排好的数组</returns>
        public static int[] Merge_Sort(int[] to_sort)
        {
            if (to_sort == null) return new int[0];

            //终止递归的条件
            if (to_sort.Length == 1) return to_sort; 

            //分而治之
            int mid = to_sort.Length / 2;

            int[] left = to_sort.Take(mid).ToArray();
            int[] right = to_sort.Skip(mid).ToArray();

            left = Merge_Sort(left);
            right = Merge_Sort(right);

            //归并开始
            int[] merged = merge(left, right);
            return merged;
        }

        public static int[] merge(int[] a, int[] b)
        {
            if (a == null) a = new int[0];
            if (b == null) b = new int[0];

            int[] merged_one = new int[a.Length + b.Length];
            int mi = 0, ai = 0, bi = 0;

            while(ai<a.Length&&bi<b.Length)
            {
                if (a[ai] <= b[bi])
                {
                    merged_one[mi] = a[ai];
                    ai++;
                }
                else
                {
                    merged_one[mi] = b[bi];
                    bi++;
                }
                mi++;
            }

            if (ai < a.Length)
            {
                for (int i = ai; i < a.Length; i++) {
                    merged_one[mi] = a[i];
                    mi++;
                }
            }else
            {
                for(int i=bi; i < b.Length; i++)
                {
                    merged_one[mi] = b[i];
                    mi++;
                }
            }

            return merged_one;
        }
    }

    /*
     分而治之在分布式系统中
     当需要排序的数组很大，比如1000GB
     没法把这些数据塞入普通机器内存里
     把这个超级大的数据集，分解为更小的数据集，比如16GB
     然后分配到多台机器
     让各个并行处理
     等所有机器处理完后，中央服务器再进行结果的合并。
     在单台机器上实现归并排序，只需要在递归函数内，实现数组的分组及合并。
     在分布式环境中，多个机器的递归函数除了分组合并，还要把数据分发到某台服务器上。

     数据切分到不同的机器或者本机上

     MapReduce
     将数据源进行切分、分割，将分片发送到Mapper上
     Mapper根据应用的需求，按照键值存储到哈希结构中
     */
}
