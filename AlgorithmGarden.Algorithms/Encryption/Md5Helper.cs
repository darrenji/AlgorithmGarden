using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace AlgorithmGarden.Algorithms.Encryption
{
    public class Md5Helper
    {
        public static readonly string myKey = "helloishouldbelongerlongerlonger";

        public static string EncryptString(string text, string keyString)
        {
            //获取私钥的字节数组
            var key = Encoding.UTF8.GetBytes(keyString);

            using (var aesAlg = Aes.Create())
            {
                using (var encryptor = aesAlg.CreateEncryptor(key, aesAlg.IV))
                {
                    using (var msEncrypt = new MemoryStream())
                    {
                        using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        using (var swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(text);
                        }

                        var iv = aesAlg.IV;
                        var decryptedContent = msEncrypt.ToArray();
                        var result = new byte[iv.Length + decryptedContent.Length];

                        Buffer.BlockCopy(iv, 0, result, 0, iv.Length);
                        Buffer.BlockCopy(decryptedContent, 0, result, iv.Length, decryptedContent.Length);

                        return Convert.ToBase64String(result);
                    }
                }
            }
        }

        public static string DecryptString(string cipherText, string keyString)
        {
            var fullCipher = Convert.FromBase64String(cipherText);

            var iv = new byte[16];
            var cipher = new byte[16];

            Buffer.BlockCopy(fullCipher, 0, iv, 0, iv.Length);
            Buffer.BlockCopy(fullCipher, iv.Length, cipher, 0, iv.Length);
            var key = Encoding.UTF8.GetBytes(keyString);

            using (var aesAlg = Aes.Create())
            {
                using (var decryptor = aesAlg.CreateDecryptor(key, iv))
                {
                    string result;
                    using (var msDecrypt = new MemoryStream(cipher))
                    {
                        using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (var srDecrypt = new StreamReader(csDecrypt))
                            {
                                result = srDecrypt.ReadToEnd();
                            }
                        }
                    }
                    return result;
                }
            }
        }

        private static MD5 md5Hasher;
        private static MD5 GetMD5Hasher()
        {
            if(md5Hasher==null)
            {
                md5Hasher = MD5.Create();
            }
            return md5Hasher;
        }

        /// <summary>
        /// 根据字节数组得到md5字符串
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string MD5Encrypt(byte[] bytes)
        {
            if (bytes == null) return null;
            byte[] hashBytes = GetMD5Hasher().ComputeHash(bytes);
            string result = BitConverter.ToString(hashBytes);
            return result.Replace("-", "").ToUpper();
        }

        /// <summary>
        /// 32位md5字符串
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string MD5Encrypt(string s)
        {
            if (string.IsNullOrEmpty(s)) return null;
            return MD5Encrypt(EncodingHelper.EncodingStringToBytes(s));
        }

        

        /// <summary>
        /// md5加密返回16进制字符串
        /// </summary>
        /// <param name="plainText"></param>
        /// <param name="byteLength"></param>
        /// <returns></returns>
        public static string md5DigAsHex(string plainText)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(plainText));
            byte[] result = md5.Hash;
            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                strBuilder.Append(result[i].ToString("x2"));
            }
            return strBuilder.ToString();
        }

        public static string md5AsHex(string plainText)
        {
            try
            {
                MD5 md5 = new MD5CryptoServiceProvider();
                md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(plainText));
                byte[] result = md5.Hash;
                StringBuilder strBuilder = new StringBuilder();
                for (int i = 0; i < result.Length; i++)
                {
                    //其实就是对每个16进制数转成字符时，对小于10的数，前面如果有0去掉即可
                    //string hexTemp = result[i].ToString("x2").TrimStart(new Char[] { '0' });
                    string hexTemp = result[i].ToString("x2");
                    string firstLetter = hexTemp.Substring(0, 1);
                    if(firstLetter=="0")
                    {
                        hexTemp = "" + hexTemp.Substring(1);
                    }
                    strBuilder.Append(hexTemp);
                }
                return strBuilder.ToString();
            }
            catch (Exception ex)
            {
                
                return string.Empty;
            }
        }
        
    }
}
