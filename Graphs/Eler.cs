namespace Algorithms_CS.Graphs
{
    public class Eler
    {
        public int[] st;
        public int pos;
        public void RunEler(int[,] matrix, int start)
        {
            int n = matrix.GetLength(0);
            int mainCountEdge = 0;
            for (int i = 0; i < n; i++)
            {
                int countEdge = 0;
                for (int j = i; j < n; j++)
                {
                    if (matrix[i, j] != 0)
                        countEdge++;
                }
                if (countEdge == 0 || countEdge % 2 != 0)
                {
                    Console.WriteLine("Цикла нет");
                    return;
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = i; j < n; j++)
                {
                    if (matrix[i, j] != 0)
                    {
                        mainCountEdge++;
                    }
                }
            }

            st = new int[mainCountEdge];
            st[0] = start;
            pos = 1;
            if (ElerCircle(matrix, start))
            {
                Console.Write(start + " - ");
                pos--;
                while (pos >= 0)
                {
                    Console.Write($"{st[pos]} - ");
                    pos--;
                }
            }
        }

        public bool ElerCircle(int[,] matrix, int seach)
        {
            int n = matrix.GetLength(0);
            if (pos > 0)
            {
                int u = st[pos - 1];
                for (int v = 0; v < n; v++)
                {
                    if (matrix[u, v] != 0)
                    {
                        if (pos == st.Length && v == seach)
                        {
                            return true;
                        }
                        else if (pos != st.Length)
                        {
                            int edge = matrix[u, v];
                            st[pos] = v;
                            pos++;
                            matrix[u, v] = 0;
                            matrix[v, u] = 0;
                            bool flag = ElerCircle(matrix, seach);
                            if (flag) return true;
                            matrix[u, v] = edge;
                            matrix[v, u] = edge;
                            pos--;
                        }
                    }
                }
            }
            return false;
        }
    }
}
