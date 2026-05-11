using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms_CS.Graphs.MST
{
    public class Prim
    {
        public void StartPrim(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int[] key = new int[n];
            int[] parent = new int[n];
            bool[] inMST= new bool[n];

            for (int i = 0; i < n; i++) key[i] = int.MaxValue;
            
            key[0] = 0;
            parent[0] = -1;

            for (int count = 0; count < n - 1; count++)
            {
                int u = -1;
                for (int i = 0; i < n; i++)
                {
                    if (!inMST[i] && (u == -1 || key[i] < key[u]))
                        u = i;
                }

                inMST[u] = true;

                for (int v = 0; v < n; v++)
                {
                    if (matrix[u, v] != 0 && !inMST[v] && matrix[u, v] < key[v])
                    {
                        parent[v] = u;
                        key[v] = matrix[u, v];
                    }
                }
            }
        }

        public void RunPrim(int[,] matrix, int r)
        {
            int n = matrix.GetLength(0);
            int[] key = new int[n];
            int[] parent = new int[n];
            bool[] vizited = new bool[n];
            Trees.MinHeap minHeap = new Trees.MinHeap();


            for(int i = 0; i < n; i++)
            {
                key[i] = int.MaxValue;
                parent[i] = -1;
            }
            key[r] = 0;
            minHeap.Push(key[r], r);

            while(minHeap.Count > 0)
            {
                int u = minHeap.Pop();
                if (vizited[u]) continue;
                vizited[u] = true;
                for(int v = 0; v < n; v++)
                {
                    if (!vizited[v] && matrix[u,v] != 0 && key[v] > matrix[u, v])
                    {
                        key[v] = matrix[u, v];
                        minHeap.Push(matrix[u, v], v);
                        parent[v] = u;
                    }
                }
            }

        }
    }
}
