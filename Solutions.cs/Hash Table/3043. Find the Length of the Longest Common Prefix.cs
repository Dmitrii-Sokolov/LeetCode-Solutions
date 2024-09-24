namespace Problem3043
{

  /// <summary>
  /// 3043. Find the Length of the Longest Common Prefix
  /// https://leetcode.com/problems/find-the-length-of-the-longest-common-prefix
  /// 
  /// Difficulty Medium
  /// Acceptance 45.2%
  /// 
  /// Array
  /// Hash Table
  /// String
  /// Trie
  /// </summary>
  public class Solution
  {
    public int LongestCommonPrefix(int[] arr1, int[] arr2)
    {
      var numbers = new HashSet<int>();
      for (var i = 0; i < arr1.Length; i++)
      {
        var item = arr1[i];
        while (item > 0)
        {
          numbers.Add(item);
          item /= 10;
        }
      }

      var prefix = 0;
      for (var i = 0; i < arr2.Length; i++)
      {
        var item = arr2[i];
        while (item > prefix)
        {
          if (numbers.Contains(item))
            prefix = item;

          item /= 10;
        }
      }

      var result = 0;
      while (prefix > 0)
      {
        result++;
        prefix /= 10;
      }

      return result;
    }
  }
}
