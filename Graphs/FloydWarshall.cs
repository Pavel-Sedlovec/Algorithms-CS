namespace Algorithms_CS.Graphs
{
    public class FloydWarshall
    {
        public void RunWarshall(int[,] matrix)
        {
            int n = matrix.GetLength(0);

            int[,] d = new int[n, n];

            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    if (i == j)
                        d[i, j] = 0;
                    else if (matrix[i, j] != 0)
                        d[i, j] = matrix[i, j];
                    else
                        d[i, j] = 1000000;
                }
            }

            for(int k = 0; k < n; k++)
            {
                for(int i = 0; i < n; i++)
                {
                    for(int j = 0; j < n; j++)
                    {
                        if (d[i,j] > d[i,k] + d[k, j])
                        {
                            d[i, j] = d[i, k] + d[k, j];
                        }
                    }
                }
            }
        }
    }
}
