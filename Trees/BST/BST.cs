using Algorithms_CS.Trees.BST;

namespace Algorithms_C_.Trees.BST
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
    }
}
