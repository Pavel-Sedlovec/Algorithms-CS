namespace Algorithms_CS.Problems
{
    // Given two binary strings a and b, return their sum as a binary string.
    //
    // Example 1:
    // Input: a = "11", b = "1"
    // Output: "100"
    //
    // Example 2:
    // Input: a = "1010", b = "1011"
    // Output: "10101"
    public class AddBinary
    {
        public string AddBin(string a, string b)
        {
            if(a.Length > b.Length)
            {
                while(b.Length != a.Length)                
                    b = "0" + b;                
            }
            else if(b.Length > a.Length)
            {
                while(a.Length != b.Length)                
                    a = "0" + a;                
            }

            int bitP = 0;
            int bitNP = 0;
            int xor = 0;
            string res = "";

            for(int i = a.Length-1; i >= 0; i--)
            {
                int a1 = a[i] - '0';
                int b1 = b[i] - '0';
                if (a1 == 1 && b1 == 1)                
                    bitNP++;
                
                xor = a1 ^ b1;
                if(xor == 1 && bitP == 1)                
                    bitNP++;
                
                res = (xor ^ bitP).ToString() + res;
                bitP = bitNP;
                bitNP = 0;
            }
            if(bitP == 1)            
                res = "1" + res;
            
            return res;
        }
    }
}
