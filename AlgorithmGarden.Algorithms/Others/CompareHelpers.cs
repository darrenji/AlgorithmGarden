using AlgorithmGarden.Algorithms.Encryption;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace AlgorithmGarden.Algorithms.Others
{
    public class ObjectHelper
    {
        public static bool CompareNormal<T>(T obj1, T obj2, Type type)
        {
            return CompareProperties(obj1, obj2, type) && CompareFields(obj1, obj2, type);
        }

        public static bool CompareSpecial(object obj1, object obj2)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();

            //把对象放到流中
            MemoryStream inputStream1;
            MemoryStream inputStream2;
            using (inputStream1 = new MemoryStream())
            {
                binaryFormatter.Serialize(inputStream1, obj1);
            }

            using (inputStream2 = new MemoryStream())
            {
                binaryFormatter.Serialize(inputStream2, obj2);
            }

            //把流转换成字节数组，得到md5字符串
            string md5_1 = Md5Helper.MD5Encrypt(inputStream1.ToArray());
            string md5_2 = Md5Helper.MD5Encrypt(inputStream2.ToArray());
            return (md5_1==md5_2);
        }

        public static bool CompareProperties<T>(T obj1, T obj2, Type type)
        {
            if (obj1 == null && obj2 == null) return true;
            if (obj1 == null || obj2 == null) return false;

            Type t = type;

            PropertyInfo[] props = t.GetProperties();
            foreach(var p in props)
            {
                if(IsCanCompare(p.PropertyType)) //这里是值类型的比较
                {
                    if(!p.GetValue(obj1).Equals(p.GetValue(obj2)))
                    {
                        return false;
                    }
                }
                else
                {
                    return CompareProperties(p.GetValue(obj1), p.GetValue(obj2), p.PropertyType);
                }
                
            }
            return true;
        }

        public static bool CompareFields<T>(T obj1, T obj2, Type type)
        {
            if (obj1 == null && obj2 == null) return true;
            if (obj1 == null || obj2 == null) return false;
            Type t = type;
            FieldInfo[] fields = t.GetFields();
            foreach(var f in fields)
            {
                if(IsCanCompare(f.FieldType)) //值类型
                {
                    if(!f.GetValue(obj1).Equals(f.GetValue(obj2)))
                    {
                        return false;
                    }
                }
                else
                {
                    return CompareFields(f.GetValue(obj1), f.GetValue(obj2), f.FieldType);
                }
            }
            return true;
        }

        /// <summary>
        /// 值类型可以比较，引用类型除了string不可以比较
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        private static bool IsCanCompare(Type t)
        {
            if(t.IsValueType)
            {
                return true;
            }
            else
            {
                if(t.FullName==typeof(String).FullName)
                {
                    return true;
                }
                return false;
            }
        }
    }
}
