using AlgorithmGarden.Algorithms.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmGarden.Algorithms.Sorting
{
    //分而治之，递归实现

    public static class  MergeSorter
    {
        public static List<T> MergeSort<T>(this List<T> collection, Comparer<T> comparer=null)
        {
            comparer = comparer ?? Comparer<T>.Default;
            return InternalMergeSort(collection, 0, collection.Count - 1, comparer);
        }

        private static List<T> InternalMergeSort<T>(List<T> collection, int startIndex, int endIndex, Comparer<T> comparer)
        {
            if(collection.Count<2)
            {
                return collection;
            }

            if(collection.Count==2)
            {
                if(comparer.Compare(collection[endIndex], collection[startIndex])<0)
                {
                    collection.Swap(endIndex, startIndex);
                }
                return collection;
            }

            //开始分了 整个求解时间T(a)
            int midIndex = collection.Count / 2;
            var leftCollection = collection.GetRange(startIndex, midIndex);//如果这里的求解时间是T(b)
            var rightCollection = collection.GetRange(midIndex, (endIndex - midIndex) + 1); //这里的求解时间是T(c)

            leftCollection = InternalMergeSort<T>(leftCollection, 0, leftCollection.Count - 1, comparer);
            rightCollection = InternalMergeSort<T>(rightCollection, 0, rightCollection.Count - 1, comparer);

            //开始合并
            //从最小的单元开始合并
            return InternalMerge<T>(leftCollection, rightCollection, comparer); //合并的时间k

            //T(a) = T(b) + T(c) + k;
            //对n个元素进行归并排序需要的时间是T(n)
            //分解成两个子集合，需要的时间都是T(n/2)
            //合并函数InternalMerge的时间复杂度是O(n)

            /*
             T(1)=C; 表示n=1时需要常量时间
             T(n) = 2* T(n/2) + n;n>1

             T(n) = 2* T(n/2) + n;
                = 2*(2*T(n/4) + n/2) + n
                ...
            
            可以推倒：T(n)=2^kT(n/2^k) + kn,相当于O(nlogn)
             */

            /*
             从空间上来看，归并排序不是原地排序算法
             在合并两个有序数组的时候，需要借助额外的存储空间
             尽管每次合并操作都需要申请额外的内存空间，但在合并完成之后，临时开辟的内存空间就被释放掉了
             在任意时刻，CPU只会执行一个函数，也就是只有一个临时的内存空间在使用
             临时内存空间最大也不会超过n个数据大小，所以空间复杂度时O(n)
             */
        }

        //归并排序稳不稳定看这里
        private static List<T> InternalMerge<T>(List<T> leftCollection, List<T> rightCollection, Comparer<T> comparer)
        {
            int left = 0;//游标
            int right = 0;//游标
            int index;

            //最终合并后的集合还是清楚的
            int length = leftCollection.Count + rightCollection.Count;

            //CPU每次执行一个函数，开辟一个临时存储空间，这里的空间复杂度时O(n)
            List<T> result = new List<T>(length);

            //因为index加完以后还要得到值，所以用++index
            for(index=0; index<length;++index)
            {
                //比较左右两边，哪个小就放在集合里，并更改游标位置
                //考虑游标的界限
                //这里考虑了值相同的情况
                if(right<rightCollection.Count&&comparer.Compare(rightCollection[right], leftCollection[left])<=0)
                {
                    result.Insert(index, rightCollection[right]);
                    right++;
                }
                else
                {
                    result.Insert(index, leftCollection[left]);
                    left++;

                    if (left == leftCollection.Count) break;
                }
            }

            //两边有可能会有剩下的
            int rIndex = index + 1;
            int lIndex = index + 1;
            while(right<rightCollection.Count)
            {
                result.Insert(rIndex, rightCollection[right]);
                rIndex++;
                right++;
            }

            while(left<leftCollection.Count)
            {
                result.Insert(lIndex, leftCollection[left]);
                lIndex++;
                left++;
            }


            return result;
        }
    }
}
