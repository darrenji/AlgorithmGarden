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
using AlgorithmGarden.Algorithms.Sorting;
using AlgorithmGarden.LeetCode;

namespace AlgorithmGarden.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var watcher = new Stopwatch();
            watcher.Start();

            int[] arr = new int[] { 1, 2, 4 };
            Console.WriteLine(_268.GetMissingNumberWithSum(arr, 4));

            watcher.Stop();
            Console.WriteLine($"execution time {watcher.ElapsedMilliseconds}");

            Console.ReadKey();

        }


    }



}
