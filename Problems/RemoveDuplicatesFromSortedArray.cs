namespace Algorithms_CS.Problems
{
    // Given an integer array nums sorted in non-decreasing order, remove the duplicates in-place such that each unique element appears only once.
    // Return the number of unique elements k. The first k elements of nums should contain the unique numbers in sorted order.

    // Example 1:
    // Input: nums = [1,1,2]
    // Output: 2, nums = [1,2,_]

    // Example 2:
    // Input: nums = [0,0,1,1,1,2,2,3,3,4]
    // Output: 5, nums = [0,1,2,3,4,_,_,_,_,_]
    public class RemoveDuplicatesFromSortedArray
    {
        public int RemoveDuplicates(int[] nums)
        {
            int k = 1;
            for(int i = 1; i < nums.Length; i++)
            {
                if (nums[i] != nums[k - 1])
                {
                    nums[k] = nums[i];
                    k++;
                }
            }
            return k;
        }
    }
}
