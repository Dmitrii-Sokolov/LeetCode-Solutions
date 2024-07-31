namespace Problem151
{

  /// <summary>
  /// 151. Reverse Words in a String
  /// https://leetcode.com/problems/reverse-words-in-a-string
  /// 
  /// Difficulty Medium
  /// Acceptance 44.7%
  /// 
  /// Two Pointers
  /// String
  /// </summary>
  public class Solution
  {
    public string ReverseWords(string s)
    {
      var result = new System.Text.StringBuilder();
      var end = s.Length;
      var start = s.Length - 1;

      while (start >= 0 && end > 0)
      {
        while (end > 0 && s[end - 1] == ' ')
        {
          end--;
        }

        start = end;
        while (start > 0 && s[start - 1] != ' ')
        {
          start--;
        }

        if (start != end)
        {
          if (result.Length > 0)
            result.Append(' ');

          result.Append(s.Substring(start, end - start));
        }

        end = start;
      }

      return result.ToString();
    }
  }
}
