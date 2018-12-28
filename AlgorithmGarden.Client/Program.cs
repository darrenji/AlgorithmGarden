using AlgorithmGarden.Algorithms.Common;
using AlgorithmGarden.Algorithms.Encryption;
using AlgorithmGarden.Algorithms.Others;
using AlgorithmGarden.Maths;
using AlgorithmGarden.Patterns.State;
using ObjectsComparer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using System.IO;
using System.Text;

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
            //Test1 t1 = new Test1
            //{
            //    Id = 1,
            //    Name = "haha",
            //    Test2 = new Test2 { Id = 1, Remark = "ok" },
            //    test3s = new Dictionary<int, Test3> {
            //        { 1, new Test3{ Id=1, Price=0.1m} },
            //        { 2, new Test3{ Id=2, Price=0.2m} }
            //    }
            //};

            //Test1 t2 = new Test1
            //{
            //    Id = 1,
            //    Name = "haha",
            //    Test2 = new Test2 { Id = 1, Remark = "ok" },
            //    test3s = new Dictionary<int, Test3> {
            //        { 1, new Test3{ Id=1, Price=0.2m} },
            //        { 2, new Test3{ Id=2, Price=0.2m} }
            //    }
            //};

            //Console.WriteLine(ObjectHelper.CompareSpecial(t1, t2));
            #endregion

            #region Object Comparer深度比较

            //比较对象
            //var a1 = new ClassA { Id = 1, Name = "haha" };
            //var a2 = new ClassA { Id = 1, Name = "ha" };
            //var comparer = new ObjectsComparer.Comparer<ClassA>();

            //比较数组
            //var a1 = new[] { 1,2,3};
            //var a2 = new[] { 1,2};
            //var comparer = new ObjectsComparer.Comparer<int[]>();

            //比较ArrayList
            //var a1 = new ArrayList { "1", "2" };
            //var a2 = new ArrayList {"1"};
            //var comparer = new ObjectsComparer.Comparer<ArrayList>();

            //多维数组
            //var a1 = new[] { new[] { 1,2} };
            //var a2 = new[] { new[] { 1,3} };
            //var comparer = new ObjectsComparer.Comparer<int[][]>();

            //运行时对象
            //dynamic a1 = new ExpandoObject();
            //a1.Name = "hello";
            //dynamic a2 = new ExpandoObject();
            //a2.Name = "world";
            //var comparer = new ObjectsComparer.Comparer();

            //编译时对象
            //dynamic a1 = new { Name="hi"};
            //dynamic a2 = new { Name = "hi" };
            //var comparer = new ObjectsComparer.Comparer();

            //自定义类型的比较规则
            //var a1 = new ClassA { Id = 1, Name = "haha" };
            //var a2 = new ClassA { Id=1, Name="HAH"};
            //var comparer = new ObjectsComparer.Comparer<ClassA>();
            //comparer.AddComparerOverride<string>(new MyValueComparer());
            //comparer.AddComparerOverride(typeof(string), new MyValueComparer());
            //comparer.AddComparerOverride(typeof(string), new MyValueComparer(), member => !member.Name.StartsWith("Na")); //某个属性的比较不采用自定义规则
            //comparer.AddComparerOverride<string>(new MyValueComparer(), member => !member.Name.StartsWith("Na"));
            //comparer.AddComparerOverride(()=> new ClassA().Name, new MyValueComparer()); //把自定义规则用在某个属性上
            //comparer.AddComparerOverride(typeof(ClassA).GetTypeInfo().GetMember("Name").First(),new MyValueComparer());
            //comparer.AddComparerOverride(()=>new ClassA().Name, (s1, s2, parentSettings) => s1?.Length == s2?.Length, s => s.ToString()); //就地自定义规则

            //例子 期望的信息
            //var a1 = new Message {
            //    MessageType=1,
            //    Status=0
            //};

            //var a2 = new Message
            //{
            //    Id = "M12345",
            //    DateCreated = DateTime.Now,
            //    DateSent = DateTime.Now,
            //    DateReceived = DateTime.Now,
            //    MessageType = 1,
            //    Status = 0
            //};
            //var comparer = new ObjectsComparer.Comparer<Message>(new ComparisonSettings {
            //    EmptyAndNullEnumerablesEqual = true //默认false
            //    //RecursiveComparison=true, //默认true,所有非值类型，且没有自定义比较规则，且没有实现ICompareble接口
            //    //UseDefaultIfMemberNotExist = false, //默认false,适用于dynamic类型

            //});
            //comparer.AddComparerOverride<DateTime>(DoNotCompareValueComparer.Instance);
            //comparer.AddComparerOverride(()=>new Message().Id, DoNotCompareValueComparer.Instance);
            //comparer.AddComparerOverride(()=> new Error().Message, DoNotCompareValueComparer.Instance);

            //例子 比较Person
            //var _factory = new MyComparersFactory();
            //var comparer = _factory.GetObjectsComparer<Person>();

            //var a1 = new Person
            //{
            //    PersonId = Guid.NewGuid(),
            //    FirstName = "John",
            //    LastName = "Doe",
            //    MiddleName = "F",
            //    PhoneNumber = "111-555-8888"
            //};
            //var a2 = new Person
            //{
            //    PersonId = Guid.NewGuid(),
            //    FirstName = "John",
            //    LastName = "Doe",
            //    PhoneNumber = "(111) 555 8888"
            //};

            //比较json文件
            //var settings0Json = LoadJson("Settings0.json");
            //var settings0 = JsonConvert.DeserializeObject<ExpandoObject>(settings0Json);
            //var settings1Json = LoadJson("Settings1.json");
            //var settings1 = JsonConvert.DeserializeObject<ExpandoObject>(settings1Json);
            //var _comparer = new ObjectsComparer.Comparer(new ComparisonSettings { UseDefaultIfMemberNotExist = true });
            ////Some fields should be ignored
            //_comparer.AddComparerOverride("ConnectionString", DoNotCompareValueComparer.Instance);
            //_comparer.AddComparerOverride("Email", DoNotCompareValueComparer.Instance);
            //_comparer.AddComparerOverride("Notifications", DoNotCompareValueComparer.Instance);
            ////Smart Modes are disabled by default. These fields are not case sensitive
            //var disabledByDefaultComparer = new DefaultValueValueComparer<string>("Disabled", IgnoreCaseStringsValueComparer.Instance);
            //_comparer.AddComparerOverride("SmartMode1", disabledByDefaultComparer);
            //_comparer.AddComparerOverride("SmartMode2", disabledByDefaultComparer);
            //_comparer.AddComparerOverride("SmartMode3", disabledByDefaultComparer);
            ////http prefix in URLs should be ignored
            //var urlComparer = new DynamicValueComparer<string>(
            //    (url1, url2, settings) => url1.Trim('/').Replace(@"http://", string.Empty) == url2.Trim('/').Replace(@"http://", string.Empty));
            //_comparer.AddComparerOverride("SomeUrl", urlComparer);
            //_comparer.AddComparerOverride("SomeOtherUrl", urlComparer);
            ////DataCompression is Off by default.
            //_comparer.AddComparerOverride("DataCompression", new DefaultValueValueComparer<string>("Off", NulableStringsValueComparer.Instance));
            ////ProcessTaskTimeout and TotalProcessTimeout fields have default values.
            //_comparer.AddComparerOverride("ProcessTaskTimeout", new DefaultValueValueComparer<long>(100, DefaultValueComparer.Instance));
            //_comparer.AddComparerOverride("TotalProcessTimeout", new DefaultValueValueComparer<long>(500, DefaultValueComparer.Instance));

            //IEnumerable<Difference> differences;
            //var isEqual = _comparer.Compare(settings0, settings1, out differences);
            //Console.WriteLine(isEqual ? "相等" : string.Join(',', differences));

            //例子 如果集合中数量不相等，就不会比较
            #endregion

            #region 两个集合的差集
            //List<int> list1 = new List<int> { 1, 2, 3, 5, 6 };
            //List<int> list2 = new List<int> { 1, 3 };
            //List<int> result = list1.Except(list2).ToList();
            //Console.WriteLine(string.Join(',', result));
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

            #region 比较迭代法和归纳法的差异
            //int grid = 63;

            //Stopwatch watch1 = new Stopwatch();
            //watch1.Start();
            //Console.WriteLine($"前n个元素之和是：{Iterative1.GetNumOfGrids(63)}");
            //Console.WriteLine($"耗时：{watch1.ElapsedMilliseconds}"); //28
            //watch1.Stop();

            //Stopwatch watch2 = new Stopwatch();
            //watch2.Start();
            //Console.WriteLine($"前n个元素之和是：{(long)(Math.Pow(2, grid))-1}");
            //Console.WriteLine($"耗时：{watch2.ElapsedMilliseconds}");//0
            //watch2.Stop();

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

        private static string LoadJson(string fileName)
        {
            using (StreamReader r = new StreamReader(fileName))
            {
                return r.ReadToEnd();

            }

        }

    }

    #region 深度比较
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
    #endregion

    #region Object Comparer
    public class ClassA
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Activity Activity { get; set; }
    }

    public class Activity
    {
        public bool IsGo { get; set; }
    }

    public class MyValueComparer : AbstractValueComparer<string>
    {
        public override bool Compare(string obj1, string obj2, ComparisonSettings settings)
        {
            return obj1.ToLower() == obj2.ToLower();
        }
    }

    public class Error
    {
        public int Id { get; set; }
        public string Message { get; set; }
    }

    public class Message
    {
        public string Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateSent { get; set; }
        public DateTime DateReceived { get; set; }
        public int MessageType { get; set; }
        public int Status { get; set; }
        public List<Error> Errors { get; set; }

        public override string ToString()
        {
            return $"Id:{Id}, Date:{DateCreated}, Type:{MessageType}, Status:{Status}";
        }
    }

    public class Person
    {
        public Guid PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string PhoneNumber { get; set; }
        public override string ToString()
        {
            return $"{FirstName} {MiddleName} {LastName} ({PhoneNumber})";
        }
    }

    public class PhoneNumberComparer : AbstractValueComparer<string>
    {
        public override bool Compare(string obj1, string obj2, ComparisonSettings settings)
        {
            return ExtractDigits(obj1) == ExtractDigits(obj2);
        }

        private string ExtractDigits(string str)
        {
            return string.Join(string.Empty, (str ?? string.Empty).ToCharArray().Where(char.IsDigit));
        }
    }

    public class MyComparersFactory : ComparersFactory
    {
        public override ObjectsComparer.IComparer<T> GetObjectsComparer<T>(ComparisonSettings settings = null, BaseComparer parentComparer = null)
        {
            if (typeof(T) == typeof(Person))
            {
                var comparer = new ObjectsComparer.Comparer<Person>(settings, parentComparer, this);
                comparer.AddComparerOverride<Guid>(DoNotCompareValueComparer.Instance);
                comparer.AddComparerOverride(() => new Person().MiddleName, (s1, s2, parentSettings) => string.IsNullOrWhiteSpace(s1) || string.IsNullOrWhiteSpace(s2) || s1 == s2);
                comparer.AddComparerOverride(() => new Person().PhoneNumber, new PhoneNumberComparer());
                return (ObjectsComparer.IComparer<T>)comparer;
            }
            return base.GetObjectsComparer<T>(settings, parentComparer);
        }
    }
    #endregion

}
