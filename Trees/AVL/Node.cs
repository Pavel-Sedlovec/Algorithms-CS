using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms_CS.Trees.AVL
{
    public class Node
    {
        public int key;
        public int count = 0;

        public Node left = null;
        public Node right = null;
        public int height;

        public Node(int key)
        {
            this.key = key;
            height = 1;
        }
    }
}
