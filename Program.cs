namespace Algorithms_CS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            TestBelmanFord();

        }

        public static void TestBFS()
        {
            int[,] maze = new int[,]
            {
                { 0, 0, 0, 1, 0 },
                { 1, 1, 0, 1, 0 },
                { 0, 0, 0, 0, 0 },
                { 0, 1, 1, 1, 0 },
                { 0, 0, 0, 0, 0 }
            };

            Graphs.BFS bfs = new Graphs.BFS();
            bfs.StartBFS(maze);
        }

        public static void TestDFS()
        {
            int[,] maze = new int[,]
            {
                { 0, 0, 0, 1, 0 },
                { 1, 1, 0, 1, 0 },
                { 0, 0, 0, 0, 0 },
                { 0, 1, 1, 1, 0 },
                { 0, 0, 0, 0, 0 }
            };

            Graphs.DFS dfs = new Graphs.DFS();
            dfs.StartDFS(maze);
        }

        public static void TestKosaraju()
        {
            int[,] matrix1 = 
            {
                {0, 1, 1, 0}, // 0 -> 1 и 0 -> 2
                {1, 0, 0, 0}, // 1 -> 0
                {0, 0, 0, 1}, // 2 -> 3
                {0, 0, 1, 0}  // 3 -> 2
            };

            Graphs.Kosaraju kos = new Graphs.Kosaraju(matrix1);
            kos.RunKosaraju();
        }

        public static void TestAVL()
        {
            Trees.AVL.AVL avl = new Trees.AVL.AVL();

            for(int i = 1; i <= 10; i++)
            {
                avl.Insert(i);
            }
            Console.WriteLine();
        }

        public static void TestDijkstra()
        {
            int[,] matrix =
            {
                {0, 3, 5, 60}, // 0 -> 1 и 0 -> 2
                {3, 0, 1, 0}, // 1 -> 0
                {5, 1, 0, 30}, // 2 -> 3
                {60, 0, 30, 0}  // 3 -> 2
            };
            Graphs.Dijkstra d = new Graphs.Dijkstra();
            d.RunDijkstra(matrix, 0);
        }

        public static void TestBelmanFord()
        {
            int[,] matrix = 
            {
                { 0,  5, 10 }, // Из 0 в 1 (5), из 0 в 2 (10)
                { 0,  0,  2 }, // Из 1 в 2 (2)
                { 0, -1,  0 }  // Из 2 в 1 (-1)
            };

            Graphs.BelmanFord bf = new Graphs.BelmanFord();
            bf.RunBelmanFord(matrix, 0);
        }
    }
}
