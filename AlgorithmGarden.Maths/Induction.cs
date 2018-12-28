using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmGarden.Maths
{
    /*
     归纳法
    */

    /*
     迭代法侧重从已知到未知，一步一步得到结果。或者先粗后细，采用二分法得到结果。
     归纳法根据已知猜出规律，通过规律或者说公式求解，这是以结果为导向，省略中间过程的一种做法。
     */

    /*
     1 2 4 8 16 32 64 128 前63位数加起来的和是多少？
     不难找出规律，n个元素的值是：2^(n-1)
     也不难找出求和的规律，前n个元素加起来的和是：2^n-1
     当然，写代码到这里就可以写了。但是在写之前要证明结论的正确。如何证明呢？

     要证明两点：
     1. 第n位元素的值是2^(n-1)
     2. 前n位元素的和是2^n-1

     首先证明边界条件，然后证明任意相邻的两位。
     当n=1时
     当n=k-1和n=k时

     测试：比较迭代法和归纳法的差异
     */

    public class WheatResult
    {
        public int Current { get; set; } = 0;
        public int Total { get; set; } = 0;
    }

    public class InductionHelper
    {
        public static bool Prove(int k, WheatResult result)
        {
            if(k==1)
            {
                if ((Math.Pow(2, 1) - 1) == 1)
                {
                    result.Current = 1;
                    result.Total = 1;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else //n=k-1时成立，证明n=k时也成立
            {
                //这里的递归的前提是建立在归纳的正确之上的
                bool previousSuccess = Prove(k - 1, result);
                result.Current *= 2;
                result.Total += result.Total;
                bool currentSuccess = false;
                if (result.Total == (Math.Pow(2, k) - 1)) currentSuccess = true;

                if(currentSuccess&&previousSuccess)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


    }
}
