using System;
using System.Collections.Generic;
namespace Algorithms_CS.Trees.BTree
{
    public class BNode
    {
        public const int T = 2;

        public int Count; 
        public int[] Keys;
        public BNode[] Kids;
        public bool IsLeaf;

        public BNode(bool isLeaf)
        {
            this.IsLeaf = isLeaf;
            this.Keys = new int[2 * T];
            this.Kids = new BNode[2 * T + 1];
            this.Count = 0;
        }
    }
}
