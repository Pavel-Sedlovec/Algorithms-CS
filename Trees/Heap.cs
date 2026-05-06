using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms_CS.Trees
{
    public class Heap
    {
        private int[] array = new int[1000];

        private int pointer = 0;

        public void Push(int element)
        {
            array[pointer] = element;
            Up(pointer);
            pointer++;
        }

        public int Pop()
        {
            if (pointer == 0) return -1;

            int result = array[0];
            pointer--;
            if (pointer > 0)
            {
                array[0] = array[pointer];
                Down(0);
            }
            return result;
        }

        private void Up(int index)
        {
            while(index != 0 && array[(index - 1)/2] < array[index])
            {
                Swap((index - 1) / 2, index);
                index = (index - 1) / 2;
            }
        }

        private void Down(int index)
        {
            while(index*2+1 < pointer)
            {
                int maxChild = index * 2 + 1;

                if (maxChild + 1 < pointer && array[maxChild + 1] > array[maxChild])
                    maxChild = maxChild + 1;

                if (array[index] > array[maxChild]) break;

                Swap(index, maxChild);
                index = maxChild;
            }
        }

        private void Swap(int i, int j)
        {
            if (i == j) return;
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}
