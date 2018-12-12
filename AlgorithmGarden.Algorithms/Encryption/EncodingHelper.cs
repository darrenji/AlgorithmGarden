using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmGarden.Algorithms.Encryption
{
    public class EncodingHelper
    {
        /// <summary>
        /// 字符串到字节数组
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static byte[] EncodingStringToBytes(string s)
        {
            byte[] result = UTF8Encoding.UTF8.GetBytes(s);
            return result;
        }

        /// <summary>
        /// 字节数组到字符串
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string GetStringFromBytes(byte[] bytes)
        {
            string s = UTF8Encoding.UTF8.GetString(bytes);
            return s;
        }

        /// <summary>
        /// 字节数组到16进制字符串
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string GetHex16FromBytes(byte[] bytes)
        {
            int int32 = BitConverter.ToInt32(bytes, 0);
            string hexStr = Convert.ToString(int32, 16);
            return hexStr;
        }
    }
}
