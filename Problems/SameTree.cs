namespace Algorithms_CS.Problems
{
    // Given the roots of two binary trees p and q, check if they are the same or not.
    // Two binary trees are considered the same if they are structurally identical
    // and the nodes have the same value.
    //
    // Example 1:
    // Input: p = [1,2,3], q = [1,2,3]
    // Output: true
    //
    // Example 2:
    // Input: p = [1,2], q = [1,null,2]
    // Output: false
    //
    // Example 3:
    // Input: p = [1,2,1], q = [1,1,2]
    // Output: false    
    public class SameTree
    {
        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null && q == null)
                return true;
            else if (p == null || q == null || p.val != q.val)
                return false;

            bool flag = IsSameTree(p.left, q.left);
            if (!flag) return false;

            flag = IsSameTree(p.right, q.right);
            if (!flag) return false;
            return true;
        }       
    }
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
}
