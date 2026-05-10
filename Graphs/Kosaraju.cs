using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms_CS.Graphs
{
    public class Kosaraju
    {
        int[,] matrix;
        int[,] tMatrix;
        Stack<int> f = new Stack<int> ();
        color[] colorArray;

        public Kosaraju(int[,] m)
        {
            matrix = m;
            colorArray = new color[m.GetLength(0)];                       
        }
        public void Dfs(int u)
        {
            colorArray[u] = color.Gray;
            for(int v = matrix.GetLength(0) - 1; v >= 0; v--)            
                if (matrix[u, v] != 0 && colorArray[v] == color.White)                
                    Dfs(v);
            colorArray[u] = color.Black;
            f.Push(u);
        }

        public void Dfs2(int u)
        {
            colorArray[u] = color.Gray;
            Console.Write(u + " ");
            for (int v = tMatrix.GetLength(0) - 1; v >= 0; v--)
                if (tMatrix[u, v] != 0 && colorArray[v] == color.White)                
                    Dfs2(v);
            colorArray[u] = color.Black;
        }

        public void TransposeMatrix()
        {
            int n = matrix.GetLength(0);
            tMatrix = new int[n, n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    tMatrix[j, i] = matrix[i, j];
        }

        public void RunKosaraju()
        {
            for (int i = 0; i < colorArray.Length; i++)
                colorArray[i] = color.White;
            for(int u = 0; u < matrix.GetLength(0); u++)
            {
                if (colorArray[u] == color.White)
                {
                    Dfs(u);
                }
            }

            TransposeMatrix();

            for (int i = 0; i < colorArray.Length; i++)
                colorArray[i] = color.White;

            while(f.Count > 0)
            {
                int u = f.Pop();

                if (colorArray[u] == color.White)
                {
                    Console.WriteLine("cc: ");
                    Dfs2(u);
                    Console.WriteLine();
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
