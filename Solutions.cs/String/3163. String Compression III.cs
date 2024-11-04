namespace Problem3163
{

  /// <summary>
  /// 3163. String Compression III
  /// https://leetcode.com/problems/string-compression-iii
  /// 
  /// Difficulty Medium
  /// Acceptance 63.3%
  /// 
  /// String
  /// </summary>
  public class Solution
  {
    public string CompressedString(string word)
    {
      var result = new System.Text.StringBuilder();
      var last = word[0];
      var repeats = 1;
      for (var i = 1; i < word.Length; i++)
      {
        var ch = word[i];
        if (last == ch && repeats < 9)
          repeats++;
        else
        {
          result.Append(repeats);
          result.Append(last);

          repeats = 1;
          last = ch;
        }
      }

      if (repeats > 0)
      {
        result.Append(repeats);
        result.Append(last);
      }

      return result.ToString();
    }
  }
}
