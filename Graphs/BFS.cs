using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms_CS.Graphs
{
    public class BFS
    {
        public void StartBFS(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int[] d = new int[n];
            int[] prev = new int[n];
            Color[] color = new Color[n];

            for(int i = 0; i < n; i++)
            {
                d[i] = -1;
                prev[i] = -1;
                color[i] = Color.White;
            }

            for (int i = 0; i < n; i++)
            {
                if (color[i] != Color.White) { continue; }

                Queue<int> queue = new Queue<int>();
                color[i] = Color.Gray;
                d[i] = 0;
                queue.Enqueue(i);

                while (queue.Count > 0)
                {
                    int u = queue.Dequeue();

                    for (int v = 0; v < n; v++)
                    {
                        if (matrix[u, v] == 1 && color[v] == Color.White)
                        {
                            color[v] = Color.Gray;                           
                            d[v] = d[u] + 1;
                            prev[v] = u;
                            queue.Enqueue(v);
                        }
                    }
                    color[u] = Color.Black;
                }                
            }
            PrintPathForEachNode(prev);
        }

        public void PrintPathForEachNode(int[] prev)
        {
            for (int i = 0; i < prev.Length; i++)
            {
                List<int> p = new();
                for (int c = i; c != -1; c = prev[c]) p.Insert(0, c);
                Console.WriteLine($"{i}: {(p.Count > 1 ? string.Join(" -> ", p) : "Root")}");
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
