namespace Problem2116
{

  /// <summary>
  /// 2116. Check if a Parentheses String Can Be Valid
  /// https://leetcode.com/problems/check-if-a-parentheses-string-can-be-valid
  /// 
  /// Difficulty Medium
  /// Acceptance 37.4%
  /// 
  /// String
  /// Stack
  /// Greedy
  /// </summary>
  public class Solution
  {
    public bool CanBeValid(string s, string locked)
    {
      if ((s.Length & 1) != 0)
        return false;

      var max = 0;
      var min = 0;
      var estimatedMin = 0;
      for (var i = 0; i < s.Length; i++)
      {
        if (locked[i] == '1')
        {
          if (s[i] == '(')
          {
            max++;
            min++;
          }
          else
          {
            max--;
            min--;

            if (estimatedMin > min)
              estimatedMin = min;
          }
        }
        else
        {
          max++;
          min--;

          if (estimatedMin > min)
            estimatedMin = min;
        }

        if (max < 0)
          return false;
      }

      return min == estimatedMin;
    }
  }
}
