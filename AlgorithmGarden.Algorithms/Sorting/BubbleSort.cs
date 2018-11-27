using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmGarden.Algotithms.Sorting
{
    class BubbleSortHelper 
    {
        public void BubbleSort(int[] input)
        {
            bool hasSwapped;
            do
            {
                hasSwapped = false;
                for (var i = 0; i < input.Length - 1; i++)
                {
                    if (input[i] > input[i + 1])
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
