namespace Algorithms_CS.Trees.BTree
{
    public class BTree
    {
        BNode root = null;
        public const int T = 2;

        public (BNode resNode, int positionKey) ?Search(BNode node, int key)
        {
            int i = 0;
            while(i <= node.Count && key > node.Keys[i])                         
                i++;
                           
            if (i <= node.Count && key == node.Keys[i])
                return (node, i);

            if (node.IsLeaf)
                return null;
            else
                return Search(node.Kids[i], key);
        }

        public void SplitChild(BNode x, int i, BNode y)
        {
            BNode z = new BNode(y.IsLeaf);

            z.Count = T - 1;
            for (int j = 0; j < z.Count; j++)
            {
                z.Keys[j] = y.Keys[T + j];
            }

            if (!z.IsLeaf)
            {
                for(int j = 0; j < T; j++)
                {
                    z.Kids[j] = y.Kids[j + T];
                }
            }
            y.Count = T - 1;

            for(int j = x.Count; j >= i+1; j--)
            {
                x.Kids[j+1] = x.Kids[j];
            }
            x.Kids[i + 1] = z;
            
            for(int j = x.Count-1; j >= i; j--)
            {
                x.Keys[j + 1] = x.Keys[j];
            }
            x.Keys[i] = y.Keys[T];
            x.Count++;
        }
    }
}
