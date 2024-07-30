namespace Problem28
{

  /// <summary>
  /// 28. Find the Index of the First Occurrence in a String
  /// https://leetcode.com/problems/find-the-index-of-the-first-occurrence-in-a-string
  /// 
  /// Difficulty Easy
  /// Acceptance 43.0%
  /// 
  /// Two Pointers
  /// String
  /// String Matching
  /// </summary>
  public class Solution
  {
    public int StrStr(string haystack, string needle)
    {
      for (var i = 0; i < haystack.Length - needle.Length + 1; i++)
      {
        if (haystack[i] == needle[0])
        {
          if (Check(i, haystack, needle))
            return i;
        }
      }

      return -1;
    }

    private bool Check(int i, string haystack, string needle)
    {
      for (var k = 1; k < needle.Length; k++)
      {
        if (haystack[i + k] != needle[k])
          return false;
      }

      return true;
    }
  }
}
