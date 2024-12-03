namespace Problem2109
{

  /// <summary>
  /// 2109. Adding Spaces to a String
  /// https://leetcode.com/problems/adding-spaces-to-a-string
  /// 
  /// Difficulty Medium
  /// Acceptance 66.1%
  /// 
  /// Array
  /// Two Pointers
  /// String
  /// Simulation
  /// </summary>
  public class Solution
  {
    public string AddSpaces(string s, int[] spaces)
    {
      var result = new char[s.Length + spaces.Length];
      var p = -1;

      for (var i = 0; i < spaces[0]; i++)
        result[++p] = s[i];

      for (var y = 1; y < spaces.Length; y++)
      {
        result[++p] = ' ';

        for (var i = spaces[y - 1]; i < spaces[y]; i++)
          result[++p] = s[i];
      }

      result[++p] = ' ';

      for (var i = spaces[^1]; i < s.Length; i++)
        result[++p] = s[i];

      return new string(result);
    }
  }
}
