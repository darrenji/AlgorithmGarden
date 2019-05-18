using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmGarden.LeetCode
{
    public class _342
    {
        //判断一个数是否是4的幂等Power of Four

        public static bool IsPowerOfFourNormal(int num)
        {
            while((num!=0) && (num%4==0))
            {
                num = num / 4;
            }

            return num == 1;
        }

        public static bool IsPowerOfFourBinary(int num) 
        {
            //找一些4的幂等，对应的二进制，奇数位1偶数位0
            //列出32位的符合上面条件的二进制数，它的十六进制是0x55555555
            //如果一个数与这个二进制发生逻辑与操作后，保持不变，那这个数就是4的幂等
            if (num <= 0) return false;

            //首先要满足是2的幂等
            if ((num & num - 1) != 0) return false;

            //再毛南族4的幂等
            if ((num & 0x55555555) == num) return true;

            return false;

        }
    }
}
