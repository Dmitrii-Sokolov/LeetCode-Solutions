namespace Problem1002
{

  /// <summary>
  /// 1002. Find Common Characters
  /// https://leetcode.com/problems/find-common-characters
  /// 
  /// Difficulty Easy
  /// Acceptance 74.6%
  /// 
  /// Array
  /// Hash Table
  /// String
  /// </summary>
  public class Solution
  {
    public IList<string> CommonChars(string[] words)
    {
      var letters = new int[26];
      for (var i = 0; i < words[0].Length; i++)
      {
        letters[words[0][i] - 'a']++;
      }

      foreach (var w in words)
      {
        var temp = new int[26];
        for (var i = 0; i < w.Length; i++)
        {
          temp[w[i] - 'a']++;
        }

        for (var i = 0; i < 26; i++)
        {
          letters[i] = Math.Min(letters[i], temp[i]);
        }
      }

      var result = new List<string>();
      for (var i = 0; i < 26; i++)
      {
        while (letters[i]-- > 0)
        {
          result.Add(new string((char)(i + 'a'), 1));
        }
      }

      return result;
    }
  }
}
