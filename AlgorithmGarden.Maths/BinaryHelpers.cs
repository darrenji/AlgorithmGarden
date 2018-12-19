﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithmGarden.Maths
{
    /// <summary>
    /// 十进制、二进制转换
    /// </summary>
    public class BinaryHelpers
    {
        public static string ConvertIntToBinary(int n)
        {
            return Convert.ToString(n, 2);
        }

        public static int ConvertBinaryToInt(string b)
        {
            //把字符串转换成数组
            var reverseBits = b.Reverse().ToArray();
            var result = 0;
            for (var i = 0; i < reverseBits.Count(); i++)
            {
                var currentItem = reverseBits[i];
                if (currentItem == '1')
                {
                    var currentResult = (int)System.Math.Pow(2, i);
                    result += currentResult;
                }
            }
            return result;
        }
    }

    /*
 10进制
 1256
 1*10^3 + 2*10^2 + 5*10^1 + 6*10^0
 10就是10进制的基数

 2进制
 看作以2为基数
 110101
 1*2^5 + 1*2^4 + 0*2^3 + 1*2^2 + 0*2^1 + 1*2^0=32+16+0+4+0+1=53
 */

    /*
电路只有断开和接通两个状态
电路接通的状态用1表示，断开的状态用0表示
逻辑运算中的真就时1，逻辑运算中的假就时0。那么逻辑运算中的额或、与都可以用1或0表示。

二进制位操作，也叫位运算
直接对内存中的二进制位进行操作

向左移位，向右移位
向左移动就是在最后加一个0，比如110101(53)向左移动一位就是1101010
这里要注意数字溢出了，二进制的位数超出了系统指定的位数。
或者可以理解为向左移动一位，最后面用0填上
1101010换算成十进制就时106，正好时53的两倍。
【结论】二进制向左移动一位，数字翻倍

向右移位，零填充到最前面
110101变成了011010，换算成10进制就时26，也就时53除以2的整数商
【结论】二进制向右移动一位，就是数字除以2并求整数商的操作
*/

    /*
     十进制转换成二进制
     先考虑二进制转换成十进制
     二进制的数量级从右到左就是2^0 2^1 2^2,每一个数量级上的可能值就时0或1
     所以，二进制转换成十进制就时不断乘2的过程，十进制转换成二进制就是不断除2的过程
     把783转换成二进制
     不断除以2
     把每次得到的余数写下来
     1111000011
     如果是Int16表示16位二进制，在前面补零，补足到16位
     如果Int32表示32位二进制，在前面补零，补到32位
     如何把负数的十进制抓换成二进制呢？
     先得到正数的二进制，在把所有位前后颠倒，再加1
     如何知道一个二进制是正数还是负数呢？
     需要看数据类型。如果是Int16，第一个是0就是正数，第一个是1那就是负数。
     对于UInt16根据第一个数无法判定是正数还是负数
     */

    /*
     二进制转换成十进制
     过程和十进制转换成二进制相反
     如果把负数二进制转换十进制呢？
     先把二进制的前后位置颠倒，得到十进制，再加1，再得到负数的十进制
     */

    /*
     A|B
     只要一个是1，结果就是1
     */

    /*
     A&B
     只有两个都是1，结果就是1
     */

    /*
     A^B
     1^1 结果是0
     0^1 1^0结果却是1
     */

    /*
     ~A 0变成1 1变成0
     */

    /*
     circular left shift
     所有向左移动一位，把第一位放到最后面一位
     cirular right shift
     所有向右移动一位，把最后一位放到最前面一位
     */

    /*
     十六进制 
     0 1 2 3 4 5 6 7 8 9
     A B C D E F
     */
}
