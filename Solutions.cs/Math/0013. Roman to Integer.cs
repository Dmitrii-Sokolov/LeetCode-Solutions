namespace Problem13
{

  /// <summary>
  /// 13. Roman to Integer
  /// https://leetcode.com/problems/roman-to-integer
  /// 
  /// Difficulty Easy
  /// Acceptance 62.1%
  /// 
  /// Hash Table
  /// Math
  /// String
  /// </summary>
  public class Solution
  {
    public int RomanToInt(string s)
    {
      var map = new Dictionary<char, int>();

      map.Add('I', 1);
      map.Add('V', 5);
      map.Add('X', 10);
      map.Add('L', 50);
      map.Add('C', 100);
      map.Add('D', 500);
      map.Add('M', 1000);

      var result = 0;
      var max = 0;

      for (var i = s.Length - 1; i >= 0; i--)
      {
        var val = map[s[i]];
        max = Math.Max(max, val);
        if (max > val)
          result -= val;
        else
        {
          result += val;
        }
      }

      return result;
    }
  }
}
