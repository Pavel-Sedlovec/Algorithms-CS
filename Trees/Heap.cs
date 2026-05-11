using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms_CS.Trees
{
    public class MinHeap
    {
        private int[] arrayKey = new int[1000];
        private int[] arrayIndex = new int[1000];

        private int pointer = 0;

        public int Count
        {
            get { return pointer; }
        }

        public void Push(int key, int indexElement)
        {
            arrayKey[pointer] = key;
            arrayIndex[pointer] = indexElement;
            Up(pointer);
            pointer++;
        }

        public int Pop()
        {
            if (pointer == 0) return -1;

            int result = arrayIndex[0];
            pointer--;
            if (pointer > 0)
            {
                arrayKey[0] = arrayKey[pointer];
                arrayIndex[0] = arrayIndex[pointer];
                Down(0);
            }
            return result;
        }

        private void Up(int index)
        {
            while(index != 0 && arrayKey[(index - 1)/2] > arrayKey[index])
            {
                Swap((index - 1) / 2, index);
                index = (index - 1) / 2;
            }
        }

        private void Down(int index)
        {
            while(index*2+1 < pointer)
            {
                int minChild = index * 2 + 1;

                if (minChild + 1 < pointer && arrayKey[minChild + 1] < arrayKey[minChild])
                    minChild = minChild + 1;

                if (arrayKey[index] <= arrayKey[minChild]) break;

                Swap(index, minChild);
                index = minChild;
            }
        }

        private void Swap(int i, int j)
        {
            if (i == j) return;
            int tempKey = arrayKey[i];
            arrayKey[i] = arrayKey[j];
            arrayKey[j] = tempKey;

            int tempIndex = arrayIndex[i];
            arrayIndex[i] = arrayIndex[j];
            arrayIndex[j] = tempIndex;
        }
    }
}
