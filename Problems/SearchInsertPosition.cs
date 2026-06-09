namespace Algorithms_CS.Problems
{
    // Given a sorted array of distinct integers and a target value,
    // return the index if the target is found.
    // If not, return the index where it would be if inserted in order.
    // Must run in O(log n) time.
    //
    // Example 1:
    // Input: nums = [1,3,5,6], target = 5
    // Output: 2
    //
    // Example 2:
    // Input: nums = [1,3,5,6], target = 2
    // Output: 1
    //
    // Example 3:
    // Input: nums = [1,3,5,6], target = 7
    // Output: 4
    public class SearchInsertPosition
    {
        public int SearchInsert(int[] nums, int target)
        {
            int l = 0, r = nums.Length;
            while (l < r)
            {
                int m = (l + r) / 2;
                if (nums[m] < target) l = m + 1;
                else r = m;
            }
            return l;
        }
    }
}
