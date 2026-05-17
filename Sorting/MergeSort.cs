namespace Algorithms_CS.Sorting
{
    public class MergeSort
    {

        public int[] Sort(int[] array)
        {
            return Sort(array, 0, array.Length - 1);
        }
        public int[] Sort(int[] array, int left, int right)
        {
            if (left - right == 0) return array;
            int mid = (right + left) / 2;

            Sort(array, left, mid);
            int leftL = left;
            int rightL = mid;
            Sort(array, mid + 1, right);
            int leftR = mid + 1;
            int rightR = right;

            array = Merge(array, leftL, rightL, leftR, rightR);
            return array;
        }

        public int[] Merge(int[] array, int leftL, int rightL, int leftR, int rightR)
        {
            int size = rightR - leftL + 1;
            int[] temp = new int[size];
            for (int i = 0; i < size; i++)
                temp[i] = array[leftL + i];

            int l = 0, r = rightL - leftL + 1;
            int index = leftL;

            while (l <= rightL - leftL && r < size)
            {
                if (temp[l] <= temp[r]) array[index++] = temp[l++];
                else array[index++] = temp[r++];
            }
            while (l <= rightL - leftL) array[index++] = temp[l++];
            while (r < size) array[index++] = temp[r++];

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
