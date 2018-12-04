using AlgorithmGarden.DataStructures.Lists;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmGarden.Algorithms.Common
{
    public static class Helpers
    {
        public static void Swap<T>(this IList<T> list, int firstIndex, int secondIndex)
        {
            if (list.Count < 2 || firstIndex == secondIndex) return;

            var temp = list[firstIndex];
            list[firstIndex] = list[secondIndex];
            list[secondIndex] = temp;
        }

        public static void Populate<T>(this IList<T> collection, T value)
        {
            if (collection == null) return;

            for(int i=0;i<collection.Count;i++)
            {
                collection[i] = value;
            }
        }

        public static void Swap<T>(this ArrayList<T> list, int firstIndex, int secondIndex)
        {
            if (list.Count < 2 || firstIndex == secondIndex)   
                return;

            var temp = list[firstIndex];
            list[firstIndex] = list[secondIndex];
            list[secondIndex] = temp;
        }
    }
}
