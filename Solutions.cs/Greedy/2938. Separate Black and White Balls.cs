namespace Problem2938
{

  /// <summary>
  /// 2938. Separate Black and White Balls
  /// https://leetcode.com/problems/separate-black-and-white-balls
  /// 
  /// Difficulty Medium
  /// Acceptance 60.8%
  /// 
  /// Two Pointers
  /// String
  /// Greedy
  /// </summary>
  public class Solution
  {
    public long MinimumSteps(string s)
    {
      var pointer = 0;
      var result = 0L;
      var blackCount = 0L;

      while (pointer < s.Length)
      {
        var whiteCount = 0;
        while (pointer < s.Length && s[pointer] == '1')
        {
          blackCount++;
          pointer++;
        }

        while (pointer < s.Length && s[pointer] == '0')
        {
          whiteCount++;
          pointer++;
        }

        result += blackCount * whiteCount;
      }

      return result;
    }
  }
}
