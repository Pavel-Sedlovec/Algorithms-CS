namespace Algorithms_CS.Problems
{
    // Given the root of a binary tree, return its maximum depth.
    // A binary tree's maximum depth is the number of nodes along the longest path
    // from the root node down to the farthest leaf node.
    //
    // Example 1:
    // Input: root = [3,9,20,null,null,15,7]
    // Output: 3
    //
    // Example 2:
    // Input: root = [1,null,2]
    // Output: 2
    public class MaximumDepthofBinaryTree
    {
        public int currDepth = 0;
        public int maxDepth = int.MinValue;
        public int MaxDepth(TreeNode root)
        {
            if(root == null)
            {                
                if (currDepth>maxDepth) maxDepth = currDepth;
                currDepth--;
                return maxDepth;
            }
            currDepth++;
            MaxDepth(root.left);
            currDepth++;
            MaxDepth(root.right);
            currDepth--;
            return maxDepth;
        }
    }
}
