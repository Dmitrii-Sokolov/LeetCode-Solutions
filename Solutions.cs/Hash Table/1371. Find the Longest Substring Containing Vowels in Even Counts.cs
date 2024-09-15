namespace Problem1371
{

  /// <summary>
  /// 1371. Find the Longest Substring Containing Vowels in Even Counts
  /// https://leetcode.com/problems/find-the-longest-substring-containing-vowels-in-even-counts
  /// 
  /// Difficulty Medium
  /// Acceptance 69.3%
  /// 
  /// Hash Table
  /// String
  /// Bit Manipulation
  /// Prefix Sum
  /// </summary>
  public class Solution
  {
    public int FindTheLongestSubstring(string s)
    {
      var vowels = new char[] { 'a', 'e', 'i', 'o', 'u' };
      var prefixes = new bool[vowels.Length];
      var firstEvent = Enumerable.Range(0, 1 << vowels.Length).Select(_ => -2).ToArray();
      var result = 0;
      var key = 0;
      firstEvent[0] = -1;

      for (var i = 0; i < s.Length; i++)
      {
        for (var j = 0; j < vowels.Length; j++)
        {
          if (vowels[j] == s[i])
          {
            prefixes[j] = !prefixes[j];
            key ^= 1 << j;
            break;
          }
        }

        if (firstEvent[key] == -2)
          firstEvent[key] = i;
        else
        {
          var substringLength = i - firstEvent[key];
          if (substringLength > result)
            result = substringLength;
        }
      }

      return result;
    }
  }
}
