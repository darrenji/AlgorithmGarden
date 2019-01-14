using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmGarden.Algorithms.Sorting
{
   public  class SelectionSort
    {
        public static int FindSmallestIndex(int[] arr, int startIndex, int n)
        {
            int smallest = arr[startIndex];
            int smallestIndex = startIndex;

            for(int i = smallestIndex + 1; i < n; i++)
            {
                if(arr[i] < smallest)
                {
                    smallestIndex = i;
                    smallest = arr[i];
                }
            }

            return smallestIndex;
        }

        public static void Swap(int[] arr, int firstIndex, int secondIndex)
        {
            int temp;
            temp = arr[firstIndex];
            arr[firstIndex] = arr[secondIndex];
            arr[secondIndex] = temp;
        }

        public static void SelectionSortGo(int[] arr, int n)
        {
            for(int i=0;i<n;i++)
            {
                int smallestIndex = FindSmallestIndex(arr, i, n);
                Swap(arr, i, smallestIndex);
            }
        }

        public static void Print(int[] arr, int n)
        {
            for(int i=0; i <n; i++)
            {
                Console.Write(arr[i] + "  ");
            }
        }
    }

    //O(n^2)
}
