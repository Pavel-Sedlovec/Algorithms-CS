namespace Algorithms_CS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            TestAVL();

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

        public static void TestAVL()
        {
            Trees.AVL.AVL avl = new Trees.AVL.AVL();

            for(int i = 1; i <= 10; i++)
            {
                avl.Insert(i);
            }
            Console.WriteLine();
        }
    }
}
