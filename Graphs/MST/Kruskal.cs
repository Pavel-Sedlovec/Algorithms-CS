namespace Algorithms_CS.Graphs.MST
{
    public class Kruskal
    {
        public Edge[] GetEdge(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int edgeCount = 0;
            for (int i = 0; i < n; i++)            
                for (int j = i + 1; j < n; j++)                
                    if (matrix[i, j] != 0) edgeCount++;

            Edge[] edges = new Edge[edgeCount];
            int k = 0;
            for (int i = 0; i < n; i++)            
                for (int j = i + 1; j < n; j++)                
                    if (matrix[i, j] != 0)                    
                        edges[k++] = new Edge { u = i, v = j, weight = matrix[i, j] };
            return edges;                                               
        }

        public Edge[] SortEdges(Edge[] edges)
        {
            int n = edges.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (edges[j].weight > edges[j + 1].weight)
                    {
                        Edge temp = edges[j];
                        edges[j] = edges[j + 1];
                        edges[j + 1] = temp;
                    }
                }
            }
            return edges;
        }

        public void RunKruskal(int[,] matrix)
        {
            Trees.DSU dsu = new Trees.DSU(matrix.GetLength(0));
            Edge[] edges;
            edges = GetEdge(matrix);
            edges = SortEdges(edges);

            Edge[] mst = new Edge[matrix.GetLength(0) - 1];
            int mstCount = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                dsu.MakeSet(i);
            }

            for(int i = 0; i < edges.Length; i++)
            {
                if (dsu.Find(edges[i].u) != dsu.Find(edges[i].v))
                {
                    mst[mstCount++] = edges[i];
                    dsu.Union(edges[i].u, edges[i].v);
                }
            }

            for (int i = 0; i < mstCount; i++)
                Console.WriteLine($"{mst[i].u} - {mst[i].v} : {mst[i].weight}");
        }
    }

    public class Edge
    {
        public int u;
        public int v;
        public int weight;
    }
}
