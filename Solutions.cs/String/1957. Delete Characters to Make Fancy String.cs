namespace Problem1957
{

  /// <summary>
  /// 1957. Delete Characters to Make Fancy String
  /// https://leetcode.com/problems/delete-characters-to-make-fancy-string
  /// 
  /// Difficulty Easy
  /// Acceptance 69.7%
  /// 
  /// String
  /// </summary>
  public class Solution
  {
    public string MakeFancyString(string initialString)
    {
      var last = ' ';
      var repeats = 0;
      var result = new System.Text.StringBuilder();
      foreach (var ch in initialString)
      {
        if (last == ch)
        {
          repeats++;

          if (repeats > 1)
            continue;
        }
        else
        {
          repeats = 0;
          last = ch;
        }

        result.Append(ch);
      }

      return result.ToString();
    }
  }
}
