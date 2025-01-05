namespace Problem2381
{

  /// <summary>
  /// 2381. Shifting Letters II
  /// https://leetcode.com/problems/shifting-letters-ii
  /// 
  /// Difficulty Medium
  /// Acceptance 43.4%
  /// 
  /// Array
  /// String
  /// Prefix Sum
  /// </summary>
  public class Solution
  {
    public string ShiftingLetters(string s, int[][] shiftsRaw)
    {
      var shifts = new int[s.Length];
      foreach (var shift in shiftsRaw)
      {
        var from = shift[0];
        var to = shift[1];
        var direction = shift[2] == 1 ? 1 : 25;
        shifts[from] += direction;
        if (to + 1 != s.Length)
          shifts[to + 1] -= direction;
      }

      var result = new char[s.Length];
      var currentShift = 0;
      for (var i = 0; i < s.Length; i++)
      {
        currentShift += shifts[i];
        result[i] = (char)((s[i] - 'a' + currentShift) % 26 + 'a');
      }

      return string.Concat(result);
    }
  }
}
