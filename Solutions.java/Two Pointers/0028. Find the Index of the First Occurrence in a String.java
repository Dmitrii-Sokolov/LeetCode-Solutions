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
class Solution
{
  public int strStr(String haystack, String needle)
  {
    for (var i = 0; i < haystack.length() - needle.length() + 1; i++)
    {
      if (haystack.charAt(i) == needle.charAt(0))
      {
        if (Check(i, haystack, needle))
          return i;
      }
    }

    return -1;
  }

  private Boolean Check(int i, String haystack, String needle)
  {
    for (var k = 1; k < needle.length(); k++)
    {
      if (haystack.charAt(i + k) != needle.charAt(k))
        return false;
    }

    return true;
  }
}
