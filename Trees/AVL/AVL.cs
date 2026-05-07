using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms_CS.Trees.AVL
{
    public class AVL
    {
        Node root = null;
        private int Height(Node node)
        {
            if(node != null) return node.height;
            else return 0;
        }

        private int Bfactor(Node node)
        {
            if(node == null) return 0;
            return Height(node.right) - Height(node.left);
        }

        private void FixHeight(Node node)
        {
            int hl = Height(node.left);
            int hr = Height(node.right);

            node.height = (hl > hr ? hl : hr) + 1;
        }

        private Node RightRotate(Node x)
        {
            Node y = x.left;
            x.left = y.right;
            y.right = x;

            FixHeight(x);
            FixHeight(y);
            return y;
        }

        private Node LeftRotate(Node x)
        {
            Node y = x.right;
            x.right = y.left;
            y.left = x;
            FixHeight(x);
            FixHeight(y);
            return y;
        }

        private Node Balance(Node node)
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

        private Node Insert(Node node,int key)
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

        private Node FindMin(Node node)
        {
            return node.left != null ? FindMin(node.left) : node;
        }

        private Node RemoveMin(Node node)
        {
            if(node.left == null)
            {
                return node.right;
            }
            else
            {
                node.left = RemoveMin(node.left);
            }
            return Balance(node);
        }

        private Node Delete(Node node, int key)
        {
            if (node == null) return null;

            if (key > node.key)
            {
                node.right = Delete(node.right, key);
            }
            else if(key < node.key)
            {
                node.left = Delete(node.left, key);
            }
            else
            {
                Node left = node.left;
                Node right = node.right;

                node = null;

                if (right == null) return left;
                if (left == null) return right;

                Node min = FindMin(right);
                min.right = RemoveMin(right);
                min.left = left;
                return Balance(min);

            }
            return Balance(node);
        }

        public void Delete(int key)
        {
            root = Delete(root, key);
        }
    }
}
