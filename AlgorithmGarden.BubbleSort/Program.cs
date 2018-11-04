using System;

namespace AlgorithmGarden.BubbleSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 2, 5, 3, 12, 8 };
            BubbleSort(arr);
            foreach(var item in arr)
            {
                Console.Write(item + " ");
            }
        }

        static void BubbleSort(int[] input)
        {
            bool hasSwapped;
            do
            {
                hasSwapped = false;
                for(var i=0; i<input.Length-1;i++)
                {
                    if(input[i] > input[i+1])
                    {
                        var oldValue = input[i + 1];
                        input[i + 1] = input[i];
                        input[i] = oldValue;
                        hasSwapped = true;
                    }
                }
            } while (hasSwapped);
        }
    }
}
