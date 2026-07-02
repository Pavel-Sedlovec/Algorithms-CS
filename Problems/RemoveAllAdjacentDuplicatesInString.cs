namespace Algorithms_CS.Problems
{
    // You are given a string s consisting of lowercase English letters.
    // A duplicate removal consists of choosing two adjacent and equal letters
    // and removing them. We repeatedly make duplicate removals on s until we no longer can.
    // Return the final string after all such duplicate removals have been made.
    // It can be proven that the answer is unique.
    //
    // Example 1:
    // Input: s = "abbaca"
    // Output: "ca"
    // Explanation: "abbaca" -> "aaca" (remove "bb") -> "ca" (remove "aa")
    //
    // Example 2:
    // Input: s = "azxxzy"
    // Output: "ay"
    // Explanation: "azxxzy" -> "azzy" (remove "xx") -> "ay" (remove "zz")
    public class RemoveAllAdjacentDuplicatesInString
    {
        public string RemoveDuplicates(string s)
        {
            int ptr = s.Length - 1;
            Stack<char> stack = new Stack<char>();
            stack.Push(s[ptr--]);
            while(ptr >= 0)
            {
                if(stack.Count == 0)               
                    stack.Push(s[ptr]);                
                else if (s[ptr] == stack.Peek())                
                    stack.Pop();                
                else                
                    stack.Push(s[ptr]);
                
                ptr--;
            }
            return new string(stack.ToArray());
        }
    }
}
