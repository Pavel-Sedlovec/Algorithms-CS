using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms_CS.Graphs
{
    public class BelmanFord
    {
        public Edge[] GetEdge(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int edgeCount = 0;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    if (matrix[i, j] != 0) edgeCount++;

            Edge[] edges = new Edge[edgeCount];
            int k = 0;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    if (matrix[i, j] != 0)
                        edges[k++] = new Edge { u = i, v = j, weight = matrix[i, j] };
            return edges;
        }

        public bool RunBelmanFord(int[,] matrix, int start)
        {
            int n = matrix.GetLength(0);
            Edge[] edges;
            edges = GetEdge(matrix);

            int[] d = new int[n];
            int[] prev = new int[n];
            for (int i = 0; i < n; i++)
            {
                d[i] = int.MaxValue;
                prev[i] = -1;
            }
            d[start] = 0;

            for(int i = 0; i < n - 1; ++i)
            {
                foreach(Edge edge in edges)
                {
                    if (d[edge.u] != int.MaxValue && d[edge.v] > edge.weight + d[edge.u])
                    {
                        d[edge.v] = edge.weight + d[edge.u];
                        prev[edge.v] = edge.u;
                    }
                }
            }

            for (int i = 0; i < n - 1; i++)
            {
                foreach (Edge edge in edges)
                {
                    if(d[edge.v] > edge.weight + d[edge.u])
                    {
                        Console.WriteLine("Обнаружен цикл");
                        return false;
                    }
                }
            }
            PrintPath(prev, d);
            return true;
        }

        public void PrintPath(int[] prev, int[] d)
        {
            for (int i = 0; i < d.Length; i++)
            {
                if (d[i] >= 1000000)
                {
                    Console.WriteLine($"Вершина {i}: пути нет");
                    continue;
                }

                Console.Write($"Путь до {i} (вес {d[i]}): {i}");
                int curr = prev[i];
                while (curr != -1)
                {
                    Console.Write($" <- {curr}");
                    curr = prev[curr];
                }
                Console.WriteLine();
            }
        }
    }

    public class Edge
    {
        public int u;
        public int v;
        public int weight;
    }
}
