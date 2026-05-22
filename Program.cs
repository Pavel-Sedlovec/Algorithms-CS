namespace Algorithms_CS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            TestLL();

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

        public static void TestQuickSort()
        {
            int[] array = { 3, 8, 5, 7, 6, 0, 10 };
            int[] array2 = { 3};
            int[] array3 = { 0 };
            int[] array4 = { 5,8 };
            int[] array5 = { 3, 2, 1 };
            Sorting.QuickSort qs = new Sorting.QuickSort();

            Sorting.MergeSort ms = new Sorting.MergeSort();

            array = ms.Sort(array5);
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
        }

        public static void TestMergeSort()
        {
            int[] array = { 7,3,2,6,0,1,5,4};
            int[] array2 = { 3 };
            int[] array3 = { 0 };
            int[] array4 = { 5, 8 };
            int[] array5 = { 3, 2, 1 };

            Sorting.MergeSort ms = new Sorting.MergeSort();

            array = ms.Sort(array5);
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
        }

        public static void TestFibonacci()
        {
            int n = 40;
            Fibonacci fib = new Fibonacci();
            Console.WriteLine(fib.FibMemo(n));
        }

        public static void TestLL()
        {
            BasicStructures.MyLinkedList ll = new BasicStructures.MyLinkedList();
            ll.AddLast(1);
            ll.AddLast(2);
            ll.AddLast(3);
            ll.AddLast(4);
            ll.AddLast(5);
            ll.Reverse();

        }
    }
}
