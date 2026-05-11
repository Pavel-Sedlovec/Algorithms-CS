using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms_CS.Graphs
{
    public class Dijkstra
    {
        public void RunDijkstra(int[,] matrix, int start)
        {
            int n = matrix.GetLength(0);
            int[] prev = new int[n];
            Color[] collorArray = new Color[n];
            int[] distance = new int[n];
            Trees.MinHeap minHeap = new Trees.MinHeap();
            
            for (int i = 0; i < n; i++)
            {                
                distance[i] = int.MaxValue;
                collorArray[i] = Color.White;
                prev[i] = -1;
            }
            distance[start] = 0;

            minHeap.Push(distance[start], start);

            while(minHeap.Count > 0)
            {
                int u = minHeap.Pop();
                if (collorArray[u] == Color.Black) continue;
                collorArray[u] = Color.Gray;
                for(int v = 0; v < n; v++)
                {
                    if (matrix[u, v] != 0 && collorArray[v] != Color.Black)
                    {
                        if (distance[v] > distance[u] + matrix[u, v])
                        {
                            distance[v] = distance[u] + matrix[u, v];
                            prev[v] = u;
                            minHeap.Push(distance[v], v);
                        }
                    }
                }
                collorArray[u] = Color.Black;
            }

        }
        enum Color
        {
            White,
            Gray,
            Black
        }
    }
}
