using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmGarden.LeetCode
{
    //Assume we are dealing with an environment which could only store integers within the 32-bit signed integer range: [−231,  231 − 1]. For the purpose of this problem, assume that your function returns 0 when the reversed integer overflows.
    public class FanZhuan
    {
        public static int Reverse(int x)
        {
            bool isNegative = x < 0;

            if (isNegative)
            {
                x = -x;
            }

            //转换成字符串
            string xStr = x.ToString();

            //转换成char并反转再转换成string
            char[] xChars = xStr.ToCharArray();
            Array.Reverse(xChars);
            string newx = new string(xChars);
            newx.TrimStart('0'); //考虑开头是零的情况

            //重新转换成int
            try
            {
                int tempResult = 0;

                foreach (char c in newx)
                {
                    // Ex. 123 -> 1, 1 * 10 = 10, 10 + 2 = 12, 12*10 = 120, 120 + 3 = 123 etc
                    tempResult = checked(tempResult * 10);
                    var digit = c - '0'; //字符串转换成int
                    tempResult = checked(tempResult + digit);
                }

                if (isNegative) //考虑负数的情况
                {
                    tempResult = tempResult * -1;
                }

                return tempResult;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
