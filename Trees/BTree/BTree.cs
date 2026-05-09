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

        public void Insert(int key)
        {
            BNode r = root;
            if (root.Count == T * 2 - 1)
            {
                BNode s = new BNode(false);
                root = s;
                s.Count = 0;
                s.Kids[0] = r;
                SplitChild(s, 0, r);
                InsertNotfull(s, key);
            }
            else
            {
                InsertNotfull(r, key);
            }
        }

        public void InsertNotfull(BNode x, int k)
        {
            int i = x.Count - 1;

            if (x.IsLeaf)
            {
                while (i >= 0 && k < x.Keys[i])
                {
                    x.Keys[i + 1] = x.Keys[i];
                    i--;
                }
                x.Keys[i + 1] = k;
                x.Count++;
            }
            else
            {                
                while (i >= 0 && k < x.Keys[i])                
                    i--;                
                i++;

                if (x.Kids[i].Count == 2 * T - 1)                
                    SplitChild(x, i, x.Kids[i]);
                    if (k > x.Keys[i])
                        i++;
                
                InsertNotfull(x.Kids[i], k);
            }
        }
    }
}
