using Algorithms_CS.Trees.BST;
using System.Security;
using System.Xml;

namespace Algorithms_CS.Trees.BST
{
    public class BST
    {
        public Node root = new Node(null);
        public void Insert(int key)
        {
            if(root.key == null)
            {
                root.key = key;
                root.count++;
                return;
            }

            Node currentNode = root;

            while(currentNode != null)
            {
                if(key == currentNode.key)
                {
                    currentNode.count++;
                    return;
                }
                else if(key > currentNode.key)
                {
                    if(currentNode.right == null)
                    {
                        currentNode.right = new Node(key) { count = 1, parent = currentNode };
                        return;
                    }
                    currentNode = currentNode.right;
                }
                else if(key < currentNode.key)
                {
                    if (currentNode.left == null)
                    {
                        currentNode.left = new Node(key) { count = 1, parent = currentNode };
                        return;
                    }
                    currentNode =currentNode.left;
                }               
            }
        }

        public int Search(int key)
        {
            if (root.key == null)            
                return 0;
           
            Node currentNode = root;
            while (currentNode != null)
            {
                if (currentNode.key == key)                
                    return currentNode.count;                
                else if (key > currentNode.key)                
                    currentNode = currentNode.right;                
                else                
                    currentNode = currentNode.left;                
            }
            return 0;
        }

        public void Delete(int key)
        {
            Node deleteNode = GetNodeByKey(key);
            if (deleteNode == null)            
                return;
            

            if (deleteNode.right == null && deleteNode.left == null)
            {
                if(deleteNode.parent == null)
                {
                    root = null;
                    return;
                }

                if(deleteNode.parent.right == deleteNode)               
                    deleteNode.parent.right = null;                
                else                
                    deleteNode.parent.left = null;
                
            }
            else if(deleteNode.right == null)
            {
                if (deleteNode.parent == null)
                {
                    root = deleteNode;
                    root.parent = null;
                    return;
                }

                if(deleteNode.parent.right == deleteNode)                
                    deleteNode.parent.right = deleteNode.left;                
                else                
                    deleteNode.parent.left = deleteNode.left;
                
            }
            else if(deleteNode.left == null)
            {
                if (deleteNode.parent == null)
                {
                    root = deleteNode;
                    root.parent = null;
                    return;
                }

                if (deleteNode.parent.right == deleteNode)                
                    deleteNode.parent.right = deleteNode.right;                
                else               
                    deleteNode.parent.left = deleteNode.right;
                
            }
            else if(deleteNode.left != null && deleteNode.right != null)
            {
                Node currentNode = deleteNode.right;

                while(currentNode.left != null)                
                    currentNode = currentNode.left;

                int minKey = currentNode.key.Value;
                int count = currentNode.count;
                Delete(minKey);
                deleteNode.key = minKey;
                deleteNode.count = count;
            }
        }

        private Node GetNodeByKey(int key)
        {
            Node currentNode = root;

            while(currentNode != null)
            {
                if (key == currentNode.key)                
                    return currentNode;                
                else if (key > currentNode.key)                
                    currentNode = currentNode.right;                
                else if (key < currentNode.key)                
                    currentNode = currentNode.left;                
            }
            return null;
        }


        public void LNR(Node node)
        {
            if (node == null) return;

            LNR(node.left);
            Console.WriteLine(node.key);
            LNR(node.right);
        }

        public void NLR(Node node)
        {
            if (node == null) return;

            Console.WriteLine(node.key);
            NLR(node.left);
            NLR(node.right);
        }

        public void LRN(Node node)
        {
            if (node == null) return;

            LRN(node.left);
            LNR(node.right);
            Console.WriteLine(node.key);
        }


        public void NLRIter(Node root)
        {
            Stack<Node> stack = new Stack<Node>();

            stack.Push(root);

            while(stack.Count > 0)
            {
                Node currentNode = stack.Pop();

                Console.WriteLine(currentNode.key);

                if (currentNode.right != null)
                    stack.Push(currentNode.right);
                if(currentNode.left != null)
                    stack.Push(currentNode.left);
            }
        }

        public void LNRIter(Node node)
        {
            Stack<Node> stack = new Stack<Node>();

            while(stack.Count > 0 || node != null)
            {
                if(node != null)
                {
                    stack.Push(node);
                    node = node.left;
                }
                else
                {
                    node = stack.Pop();
                    Console.WriteLine(node.key);
                    node = node.right;
                }
            }
        }

        public void LRNIter(Node node)
        {
            Stack<Node> stack = new Stack<Node>();
            stack.Push(node);

            LinkedList<int> linkedList = new LinkedList<int>();

            while(stack.Count > 0)
            {
                Node currentNode = stack.Pop();

                linkedList.AddFirst(currentNode.key.Value);

                if (currentNode.left != null)
                    stack.Push(currentNode.left);
                if (currentNode.right != null)
                    stack.Push(currentNode.right);
            }                       
        }
    }
}
