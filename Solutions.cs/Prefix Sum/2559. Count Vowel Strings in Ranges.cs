namespace Problem2559
{

  /// <summary>
  /// 2559. Count Vowel Strings in Ranges
  /// https://leetcode.com/problems/count-vowel-strings-in-ranges
  /// 
  /// Difficulty Medium
  /// Acceptance 62.3%
  /// 
  /// Array
  /// String
  /// Prefix Sum
  /// </summary>
  public class Solution
  {
    private static HashSet<char> Vowels = ['e', 'u', 'i', 'o', 'a'];

    public int[] VowelStrings(string[] words, int[][] queries)
    {
      var sums = new int[words.Length + 1];
      for (var i = 0; i < words.Length; i++)
      {
        sums[i + 1] = sums[i];
        if (Vowels.Contains(words[i][0]) && Vowels.Contains(words[i][^1]))
          sums[i + 1]++;
      }

      var result = new int[queries.Length];
      for (var i = 0; i < result.Length; i++)
        result[i] = sums[queries[i][1] + 1] - sums[queries[i][0]];

      return result;
    }
  }
}
