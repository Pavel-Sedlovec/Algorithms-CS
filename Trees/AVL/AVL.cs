using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms_CS.Trees.AVL
{
    public class AVL
    {
        Node root = null;
        public int Height(Node node)
        {
            if(node != null) return node.height;
            else return 0;
        }

        public int Bfactor(Node node)
        {
            if(node == null) return 0;
            return Height(node.right) - Height(node.left);
        }

        public void FixHeight(Node node)
        {
            int hl = Height(node.left);
            int hr = Height(node.right);

            node.height = (hl > hr ? hl : hr) + 1;
        }

        public Node RightRotate(Node x)
        {
            Node y = x.left;
            x.left = y.right;
            y.right = x;

            FixHeight(x);
            FixHeight(y);
            return y;
        }

        public Node LeftRotate(Node x)
        {
            Node y = x.right;
            x.right = y.left;
            y.left = x;
            FixHeight(x);
            FixHeight(y);
            return y;
        }

        public Node Balance(Node node)
        {
            FixHeight(node);

            if(Bfactor(node) == 2)
            {
                if(Bfactor(node.right) < 0)
                {
                    node.right = RightRotate(node.right);
                }
                return LeftRotate(node);
            }
            else if(Bfactor(node) == -2)
            {
                if(Bfactor(node.left) > 0)
                {
                    node.left = LeftRotate(node.left);
                }
                return RightRotate(node);
            }
            return node;
        }

        public Node Insert(Node node,int key)
        {
            if (node == null) return new Node(key);

            if (key > node.key)
            {
                node.right = Insert(node.right, key);
            }
            else if(key < node.key)
            {
                node.left = Insert(node.left, key);
            }
            else if(key == node.key)
            {
                node.count++;
                return node;
            }
            return Balance(node);
        }

        public void Insert(int key)
        {
            root = Insert(root, key);
        }
    }
}
