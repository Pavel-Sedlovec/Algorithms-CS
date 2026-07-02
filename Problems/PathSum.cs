namespace Algorithms_CS.Problems
{
    // Given the root of a binary tree and an integer targetSum,
    // return true if the tree has a root-to-leaf path such that
    // adding up all the values along the path equals targetSum.
    // A leaf is a node with no children.
    //
    // Example 1:
    // Input: root = [5,4,8,11,null,13,4,7,2,null,null,null,1], targetSum = 22
    // Output: true
    // Explanation: The root-to-leaf path with the target sum is shown.
    //
    // Example 2:
    // Input: root = [1,2,3], targetSum = 5
    // Output: false
    // Explanation: There are two root-to-leaf paths: (1-->2) sum = 3, (1-->3) sum = 4.
    // No path with sum = 5.
    //
    // Example 3:
    // Input: root = [], targetSum = 0
    // Output: false
    // Explanation: Since the tree is empty, there are no root-to-leaf paths.
    public class PathSum
    {
        public bool HasPathSum(TreeNode root, int targetSum)
        {
            if (root == null) return false;

            targetSum -= root.val;

            if (root.left == null && root.right == null)
            {
                if (targetSum == 0)
                {
                    return true;
                }
                return false;
            }
            if (root.left != null && HasPathSum(root.left, targetSum))
            {
                return true;
            }
            if(root.right != null && HasPathSum(root.right, targetSum))
            {
                return true;
            }
            return false;
        }
    }
}
