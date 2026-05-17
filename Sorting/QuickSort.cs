using System;
using System.Collections.Generic;
using System.Linq;
namespace Algorithms_CS.Sorting
{
    public class QuickSort
    {
        public int[] Sort(int[] array)
        {
            return Sort(array, 0, 0, array.Length - 1);
        }
        public int[] Sort(int[] array, int pivotIndex, int left, int right)
        {
            int l = left; int r = right;
            if (l - r >= 0)
                return array;            

            Swap(ref array, pivotIndex, r);
            pivotIndex = r; r--;
            int pivotVal = array[pivotIndex];

            while ( l - r != 1)
            {
                if (array[l] >= pivotVal)
                {
                    while (l - r != 1 && array[r] >= pivotVal)
                    {
                        r--;
                    }
                    if (l - r != 1)
                        Swap(ref array, r, l);
                }
                else
                {
                    l++;
                }                                   
            }
            Swap(ref array, pivotIndex, l);
            pivotIndex = l;

            Sort(array, left,left, pivotIndex - 1);
            Sort(array, pivotIndex + 1, pivotIndex + 1, right);
            return array;
        }

        public void Swap(ref int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}
