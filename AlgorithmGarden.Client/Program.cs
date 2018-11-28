using AlgorithmGarden.Algorithms.Common;
using System;

namespace AlgorithmGarden.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 时间转换
            string nowStr = "2018-11-28 10:29:22";
            DateTime now = TimeConverHelper.ConvertToTimeFromStr(nowStr);

            long nowLong = TimeConverHelper.ConvertToLong(now);
            Console.WriteLine($"当前时间{nowStr}转换成long类型：{nowLong}");

            DateTime newNow = TimeConverHelper.ConvertToTimeFromLong(nowLong);
            Console.WriteLine($"当前long类型{nowLong}转换成时间：{newNow}");
            #endregion
        }
    }
}
