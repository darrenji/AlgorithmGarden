using AlgorithmGarden.Algorithms.Common;
using AlgorithmGarden.Algorithms.Encryption;
using AlgorithmGarden.Algorithms.Others;
using AlgorithmGarden.Maths;
using AlgorithmGarden.Patterns.State;
using System;
using System.Collections.Generic;

namespace AlgorithmGarden.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Algorithm
            #region 时间转换
            //string nowStr = "2018-11-28 10:29:22";
            //DateTime now = TimeConverHelper.ConvertToTimeFromStr(nowStr);

            //long nowLong = TimeConverHelper.ConvertToLong(now);
            //Console.WriteLine($"当前时间{nowStr}转换成long类型：{nowLong}");

            //DateTime newNow = TimeConverHelper.ConvertToTimeFromLong(nowLong);
            //Console.WriteLine($"当前long类型{nowLong}转换成时间：{newNow}");
            #endregion

            #region md5解密
            //var str = "eyJkaXN0cmlidXRib3giOnsiQnJlYWtlcnMiOnsiMSI6eyJ2ZXJzaW9uIjoiMS4wMyIsInRpdGxl\nIjoi5oC76LevIiwibW9kZWwiOiJKWksyTDEwMC1CTDY1MjMiLCJBbGFybSI6MCwiRW5hYmxlTmV0\nQ3RybCI6dHJ1ZSwiTVhEVyI6MC4wLCJNWEdHIjo3MDQwLjAsIk1YR0wiOjQ4LjAwLCJNWEdXIjo5\nMC4wLCJNWEdZIjoyNjAuMCwiTVhMRCI6MTAwLjAsIk1YUVkiOjEwMC4wLCJPcGVuQ2xvc2UiOmZh\nbHNlLCJhZGRyIjoxLCJwb3dlciI6MC4wLCJzcGVjaWZpY2F0aW9uIjozMiwiY29udHJvbCI6MSwi\ndmlzaWJpbGl0eSI6MSwidG90YWxDaGFubmVsSWQiOi0xLCJsaW5lVHlwZSI6IjIyMCIsIkFfQSI6\nMC4wMCwiQV9UIjo0My44LCJBX1YiOjIyMS4wLCJBX1dQIjowLjAsIkFfTEQiOjAuMCwiQV9QRiI6\nMC4wfSwiMiI6eyJ2ZXJzaW9uIjoiMS4wMyIsInRpdGxlIjoi57q/6LevMSIsIm1vZGVsIjoiSkZL\nMkwxMDMtQkw2NTIzIiwiQWxhcm0iOjAsIkVuYWJsZU5ldEN0cmwiOnRydWUsIk1YRFciOjAuMCwi\nTVhHRyI6NDQwMC4wLCJNWEdMIjozMC4wMCwiTVhHVyI6OTAuMCwiTVhHWSI6MjYwLjAsIk1YTEQi\nOjMwLjAsIk1YUVkiOjE3NS4wLCJPcGVuQ2xvc2UiOmZhbHNlLCJhZGRyIjoyLCJwb3dlciI6MC4w\nLCJzcGVjaWZpY2F0aW9uIjoyMCwiY29udHJvbCI6MSwidmlzaWJpbGl0eSI6MSwidG90YWxDaGFu\nbmVsSWQiOjEsImxpbmVUeXBlIjoiMjIwIiwiQV9BIjowLjAwLCJBX1QiOjM4LjUsIkFfViI6MjIx\nLjAsIkFfV1AiOjAuMCwiQV9MRCI6MC4wLCJBX1BGIjowLjB9LCIzIjp7InZlcnNpb24iOiIxLjAz\nIiwidGl0bGUiOiLnur/ot68yIiwibW9kZWwiOiJKRksyTDEwMy1CTDY1MjMiLCJBbGFybSI6MCwi\nRW5hYmxlTmV0Q3RybCI6dHJ1ZSwiTVhEVyI6MC4wLCJNWEdHIjo0NDAwLjAsIk1YR0wiOjMwLjAw\nLCJNWEdXIjo5MC4wLCJNWEdZIjoyNjAuMCwiTVhMRCI6MzAuMCwiTVhRWSI6MTc1LjAsIk9wZW5D\nbG9zZSI6dHJ1ZSwiYWRkciI6MywicG93ZXIiOjAuMCwic3BlY2lmaWNhdGlvbiI6MjAsImNvbnRy\nb2wiOjEsInZpc2liaWxpdHkiOjEsInRvdGFsQ2hhbm5lbElkIjoxLCJsaW5lVHlwZSI6IjIyMCIs\nIkFfQSI6MC4wMCwiQV9UIjozOC41LCJBX1YiOjIyMS4wLCJBX1dQIjowLjAsIkFfTEQiOjAuMCwi\nQV9QRiI6MC4wfSwiNCI6eyJ2ZXJzaW9uIjoiMS4wMyIsInRpdGxlIjoi57q/6LevMyIsIm1vZGVs\nIjoiSkZLMkwxMDMtQkw2NTIzIiwiQWxhcm0iOjAsIkVuYWJsZU5ldEN0cmwiOnRydWUsIk1YRFci\nOjAuMCwiTVhHRyI6NDQwMC4wLCJNWEdMIjozMC4wMCwiTVhHVyI6OTAuMCwiTVhHWSI6MjYwLjAs\nIk1YTEQiOjMwLjAsIk1YUVkiOjE3NS4wLCJPcGVuQ2xvc2UiOmZhbHNlLCJhZGRyIjo0LCJwb3dl\nciI6MC4wLCJzcGVjaWZpY2F0aW9uIjoyMCwiY29udHJvbCI6MSwidmlzaWJpbGl0eSI6MSwidG90\nYWxDaGFubmVsSWQiOjEsImxpbmVUeXBlIjoiMjIwIiwiQV9BIjowLjAwLCJBX1QiOjM4LjksIkFf\nViI6MjIxLjAsIkFfV1AiOjAuMCwiQV9MRCI6MC4wLCJBX1BGIjowLjB9LCI1Ijp7InZlcnNpb24i\nOiIxLjAzIiwidGl0bGUiOiLnur/ot680IiwibW9kZWwiOiJKRksyTDEwMy1CTDY1MjMiLCJBbGFy\nbSI6MCwiRW5hYmxlTmV0Q3RybCI6dHJ1ZSwiTVhEVyI6MC4wLCJNWEdHIjo0NDAwLjAsIk1YR0wi\nOjMwLjAwLCJNWEdXIjo5MC4wLCJNWEdZIjoyNjAuMCwiTVhMRCI6MzAuMCwiTVhRWSI6MTc1LjAs\nIk9wZW5DbG9zZSI6ZmFsc2UsImFkZHIiOjUsInBvd2VyIjowLjAsInNwZWNpZmljYXRpb24iOjIw\nLCJjb250cm9sIjoxLCJ2aXNpYmlsaXR5IjoxLCJ0b3RhbENoYW5uZWxJZCI6MSwibGluZVR5cGUi\nOiIyMjAiLCJBX0EiOjAuMDAsIkFfVCI6NDAuNCwiQV9WIjoyMjEuMCwiQV9XUCI6MC4wLCJBX0xE\nIjowLjAsIkFfUEYiOjAuMH19fSwic2VydmVyaW5mbyI6eyJwb3J0IjoiMTIzNDUiLCJoYXJkd2Fy\nZSI6IlQyNSIsImV4ZWNsZWFrY2hlY2siOiJmYWxzZSIsIm1hYyI6IjE4N0VENTMxNEREOCIsImxv\nZ2luaWQiOiIxODdFRDUzMTRERDgiLCJnYXRlIjoiIiwiaXAiOiIxOTIuMTY4LjAuMTAwIiwidmVy\nc2lvbiI6IjIuNTIiLCJsb2dpbnB3ZCI6IjdhNTdhNWE3NDM4OTRhZTQiLCJzc2lkcHdkIjoiOGM5\nZWY5NDg0MmJjYzJlNSIsInNzaWQiOiJtYW50dW4iLCJ0aW1lem9uZUlkIjoiQXNpYS9TaGFuZ2hh\naSIsInNlcnZlciI6Imh0dHA6Ly8xOTIuMTY4LjAuMjUyOjgwMDMvc25kIiwiZGF0ZXRpbWUiOiIy\nMDE4LTExLTI5IDExOjEwOjQ1IiwibGVha2NoZWNrZGF0ZSI6IjMsMTMsMzMiLCJsYXN0bGVha2No\nZWNrZGF0ZSI6IjIwMTctMDEtMDEgMTA6MDA6MDAifX0=\n";
            ////28fcfcdeac0788cc14c689860e61c63
            //var result = Md5Helper.md5AsHex(str);
            //Console.WriteLine(result);
            #endregion

            #region 深度比较
            Test1 t1 = new Test1
            {
                Id = 1,
                Name = "haha",
                Test2 = new Test2 { Id = 1, Remark = "ok" },
                test3s = new Dictionary<int, Test3> {
                    { 1, new Test3{ Id=1, Price=0.1m} },
                    { 2, new Test3{ Id=2, Price=0.2m} }
                }
            };

            Test1 t2 = new Test1
            {
                Id = 1,
                Name = "haha",
                Test2 = new Test2 { Id = 1, Remark = "ok" },
                test3s = new Dictionary<int, Test3> {
                    { 1, new Test3{ Id=1, Price=0.2m} },
                    { 2, new Test3{ Id=2, Price=0.2m} }
                }
            };

            Console.WriteLine(ObjectHelper.CompareSpecial(t1, t2));
            #endregion

            #endregion

            #region DataStructure

            #endregion

            #region Maths
            #region 二进制十进制转换
            //Console.WriteLine(BinaryHelpers.ConvertIntToBinary(53));
            //Console.WriteLine(BinaryHelpers.ConvertBinaryToInt("110101"));
            #endregion

            #region 位 左移
            //110101
            //左移右边填充零，保持6位数不变
            //1101010 左移增加2倍
            //Console.WriteLine(53 << 1);
            //左移2位，增加4倍
            //Console.WriteLine(53 << 2);
            #endregion

            #region 位 右移
            //110101
            //右移0110101 除以2的整数商
            //Console.WriteLine(53 >> 1);
            #endregion
            #endregion

            #region Design Pattern

            #region state
            //Context stateContext = new Context(new StateA());
            //stateContext.Request();
            //stateContext.Request();
            #endregion

            #endregion

        }
    }

    [Serializable]
    public class Test1
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Test2 Test2 { get; set; }
        public IDictionary<int, Test3> test3s { get; set; }
    }

    [Serializable]
    public class Test2
    {
        public int Id { get; set; }
        public string Remark { get; set; }
    }

    [Serializable]
    public class Test3
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
    }

}
