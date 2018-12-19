using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmGarden.Maths
{
    /*
     迭代法
     迭代与其说是一种方法，不如说是一种重要的思想。
     体现了等价原则。一个复杂的问题总是可以等价成更简单的问题。
     所谓的迭代就是根据一个已知的变量得到一个新变量的过程。
     用公式表示：f(xn)=f(xn-1)*2 
     */

    /*
     第一个格子放1，第二个格子放2，第三个格子放4，第63个格子放多少？
     */

    public class Iterative1
    {
        /// <summary>
        /// 最多放到第几格
        /// </summary>
        /// <param name="maxGrid"></param>
        /// <returns></returns>
        public static long GetNumOfGrids(int maxGrid)
        {
            long result = 0;
            long currentNumInGrid = 0;

            //第一格开始
            currentNumInGrid = 1;
            result += currentNumInGrid;

            //第二个格子开始
            for (int i = 2; i <= maxGrid; i++)
            {
                currentNumInGrid *= 2;
                result += currentNumInGrid;
            }

            //这里无论是currentNumInGrid还是result都是根据前一个得到后一个，迭代

            return result;
        }
    }

    /*
     迭代还可以用更好的方法
     二分法就是一种
     二分法体现的是先粗后细的思想，还是有点反直觉的

     给你两个一模一样的玻璃球，两个球到达一定的高度掉到地上就会坏掉，在1层和100层楼之间，如何用最少的次数求出玻璃球摔碎的楼层？
     --可以10层10层地试，比如到了60层一个玻璃球坏了，那答案是在50和60之间，再从50-60之间依次试，这样不出20次就能得到答案。

     最先进的手术机器人电机一开始速度很快，是粗调。等约接近目标，转速越慢，变成精调。

     机器学习，是不断调整数学模型参数的过程，直到最佳收敛点。

     本田的NSX超级跑车有4个发动机，一个是传统的汽油发动机提供主要动力，相当于粗调。一个电动发动机提供起跑一瞬间的加速，相当于精调。另外两个一个是加速，一个是减速，也算精调。

     机器学习中，运用很多算法的过程也是迭代的过程，或者说从粗调到精调的过程。比如K-均值算法k-means clustering, PageRank的马尔科夫链Markov chain,梯度下降法Gradient descent等，最终来到一个局部的最优解。
     */

    /*
     计算某个大于1的正整数的平方根？
     等价于：在1-n之间找一个数等于n的平方根
     */
    public class Iterative2
    {
        /// <summary>
        /// 计算某个大于1正整数的平方根
        /// </summary>
        /// <param name="n">要求值的数</param>
        /// <param name="deltaThreashold">误差的阈值</param>
        /// <param name="maxTry"></param>
        /// <returns></returns>
        public static double GetSquareRoot(int n, double deltaThreashold, int maxTry)
        {
            if(n<=1)
            {
                return -1.0;
            }

            double min = 1.0;
            double max = (double)n;
            for(int i=0; i < maxTry; i++)
            {
                //二分法的前提是先排好了序
                double middle = (min + max) / 2; //这里体现了二分法
                double square = middle * middle;

                double delta = Math.Abs((square/n)-1);
                if (delta <= deltaThreashold) //小于精度误差范围直接返回结果
                {
                    return middle;
                }
                else //精度范围不合适
                {
                    if (square > n)
                    {
                        max = middle; //接下来在左半边找
                    }
                    else
                    {
                        min = middle; //在右边边找
                    }
                }
            }

            return -2.0;
        }

        /*
         在一组字符串集合中找出一个字符串
         */

        public class Iterative3
        {
            public static bool Search(string[] arr, string wordToFind)
            {
                if (arr == null) return false;
                if (arr.Length == 0) return false;

                int left = 0;
                int right = arr.Length - 1;
                while(left<=right)
                {
                    int middle = (left + right) / 2;
                    if(arr[middle]==wordToFind)
                    {
                        return true;
                    }
                    else
                    {
                        if (arr[middle].CompareTo(wordToFind) > 0)
                        {
                            right = middle - 1;
                        }
                        else
                        {
                            left = middle + 1;
                        }
                    }
                }

                return false;
            }
        }

        /*
         总结：迭代法体现的等价思想非常非常重要。而迭代法使用的二分法体现了粗调和精调的思想。不断更新变量值，不断缩小范围，这就是迭代的特征。
         */
    }
}
