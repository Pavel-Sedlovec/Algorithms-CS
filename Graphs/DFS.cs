using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms_CS.Graphs
{
    public class DFS
    {
        public void StartDFS(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int time = 0;
            int[] d = new int[n];
            int[] f = new int[n];
            int?[] parent = new int?[n];
            color[] colorArray = new color[n];

            for(int i = 0; i < n; i++)
            {
                colorArray[i] = color.White;
                parent[i] = null;
            }

            for(int i = 0; i < n; i++)
            {                
                if (colorArray[i] != color.White) { continue; }

                Stack<int> stack = new Stack<int>();
                stack.Push(i);

                while(stack.Count != 0)
                {
                    int u = stack.Peek();                    

                    if (colorArray[u] == color.White)
                    {
                        colorArray[u] = color.Gray;
                        d[u] = ++time;
                        for (int v = n-1; v >=0; v--)
                        {
                            if (matrix[u,v] != 0 && colorArray[v] == color.White)
                            {
                                stack.Push(v);
                                parent[v] = u;
                            }
                        }
                        Console.Write($"({u}");
                    }
                    else if (colorArray[u] == color.Gray)
                    {
                        stack.Pop();
                        colorArray[u] = color.Black;
                        f[u] = ++time;
                        Console.Write($"{u})");
                    }
                    else
                    {
                        stack.Pop();
                    }
                }
            }
        }

        enum color
        {
            White,
            Gray,
            Black
        }
    }   
}
