namespace Problem664
{

  /// <summary>
  /// 664. Strange Printer
  /// https://leetcode.com/problems/strange-printer
  /// 
  /// Difficulty Hard
  /// Acceptance 56.9%
  /// 
  /// String
  /// Dynamic Programming
  /// </summary>
  public class Solution
  {
    public int StrangePrinter(string s)
    {
      var sb = new System.Text.StringBuilder();
      var previous = ' ';
      foreach (var c in s)
      {
        if (c != previous)
        {
          previous = c;
          sb.Append(c);
        }
      }

      s = sb.ToString();

      var results = new int[s.Length, s.Length];
      for (var offset = 0; offset < s.Length; offset++)
      {
        for (var from = s.Length - offset - 1; from >= 0; from--)
        {
          if (offset <= 1)
          {
            results[from, offset] = offset + 1;
          }
          else
          {
            results[from, offset] = 1 + results[from + 1, offset - 1];
            for (var i = 2; i <= offset; i++)
            {
              if (s[from] == s[from + i])
              {
                var candidate = results[from, i - 1] + results[from + i, offset - i] - 1;
                if (results[from, offset] > candidate)
                  results[from, offset] = candidate;
              }
            }
          }
        }
      }

      return results[0, s.Length - 1];
    }
  }
}
