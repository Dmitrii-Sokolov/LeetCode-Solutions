namespace Problem1639
{

  /// <summary>
  /// 1639. Number of Ways to Form a Target String Given a Dictionary
  /// https://leetcode.com/problems/number-of-ways-to-form-a-target-string-given-a-dictionary
  /// 
  /// Difficulty Hard
  /// Acceptance 53.1%
  /// 
  /// Array
  /// String
  /// Dynamic Programming
  /// </summary>
  public class Solution
  {
    private const long Modulo = 1000_000_007L;

    public int NumWays(string[] words, string target)
    {
      if (target.Length > words[0].Length)
        return 0;

      var counts = new int[words[0].Length, 26];
      foreach (var word in words)
      {
        for (var i = 0; i < word.Length; i++)
          counts[i, word[i] - 'a']++;
      }

      var results = new long[words[0].Length - target.Length + 2];
      for (var j = 0; j < results.Length - 1; j++)
        results[j] = 1;

      for (var i = target.Length - 1; i >= 0; i--)
      {
        for (var j = results.Length - 2; j >= 0; j--)
          results[j] = (counts[i + j, target[i] - 'a'] * results[j] + results[j + 1]) % Modulo;
      }

      return (int)results[0];
    }
  }
}
