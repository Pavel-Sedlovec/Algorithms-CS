namespace Algorithms_CS.Trees.BST
{
    public class Node
    {
        public int? key = null;

        public int count = 0;

        public Node left = null;
        public Node right = null;
        public Node parent = null;

        public Node(int? key)
        {
            this.key = key;
        }
    }
}
