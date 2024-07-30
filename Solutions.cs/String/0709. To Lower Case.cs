namespace Problem709
{

  /// <summary>
  /// 709. To Lower Case
  /// https://leetcode.com/problems/to-lower-case
  /// 
  /// Difficulty Easy
  /// Acceptance 83.5%
  /// 
  /// String
  /// </summary>
  public class Solution
  {
    public string ToLowerCase(string s)
    {
      var result = new System.Text.StringBuilder();
      for (var i = 0; i < s.Length; i++)
      {
        var c = s[i];
        result.Append(char.ToLower(c));
      }

      return result.ToString();
    }
  }
}
