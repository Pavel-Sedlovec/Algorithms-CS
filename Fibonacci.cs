using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms_CS
{
    public class Fibonacci
    {
        public int FibRec(int n)
        {            
            if (n == 0) return 0;
            if (n == 1) return 1;
            return FibRec(n - 1) + FibRec(n - 2);
        }

        public int FibMemo(int n, int[] memo)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;
            if (memo[n] != 0) return memo[n];

            int x = FibMemo(n-1, memo);
            int y = FibMemo(n - 2, memo);
            memo[n] = x + y;
            return memo[n];
        }
        public int FibMemo(int n)
        {
            int[] memo = new int[n+1];
            return FibMemo(n, memo);
        }

        public int FibIter(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;

            int ptr = 2;
            int x = 0; int y = 1;
            while(ptr <= n)
            {
                int temp = y;
                y = x + y;
                x = temp;
                ptr++;
            }
            return y;
        }
    }
}
