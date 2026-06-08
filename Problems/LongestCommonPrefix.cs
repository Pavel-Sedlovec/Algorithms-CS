namespace Algorithms_CS.Problems
{
    // Find the longest common prefix string amongst an array of strings.
    // If there is no common prefix, return an empty string "".
    //
    // Example 1:
    // Input: strs = ["flower","flow","flight"]
    // Output: "fl"
    //
    // Example 2:
    // Input: strs = ["dog","racecar","car"]
    // Output: ""
    public class LongestCommonPrefix
    {
        public string LongestCommon(string[] strs)
        {
            int minLength = int.MaxValue;
            string resultStr1 = "";
            for (int i = 0; i < strs.Length; i++)
            {
                if (strs[i].Length < minLength) minLength = strs[i].Length;
            }

            for (int i = 0; i < minLength; i++)
            {
                for (int j = 1; j < strs.Length; j++)
                {
                    if (strs[j][i] != strs[j - 1][i])
                    {
                        return resultStr1;
                    }
                }
                resultStr1 += strs[0][i];
            }
            return resultStr1;

        }
    }
}

