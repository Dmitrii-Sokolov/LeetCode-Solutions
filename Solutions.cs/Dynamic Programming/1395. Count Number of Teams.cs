namespace Problem1395
{

  /// <summary>
  /// 1395. Count Number of Teams
  /// https://leetcode.com/problems/count-number-of-teams
  /// 
  /// Difficulty Medium
  /// Acceptance 67.0%
  /// 
  /// Array
  /// Dynamic Programming
  /// Binary Indexed Tree
  /// Brute Force
  /// </summary>
  public class Solution
  {
    public int NumTeams(int[] rating)
    {
      var n = rating.Length;
      var result = 0;

      for (var i = 0; i < n; i++)
      {
        var first = rating[i];
        for (var j = i + 1; j < n; j++)
        {
          var second = rating[j];
          if (first == second)
            continue;

          if (second > first)
          {
            for (var k = j + 1; k < n; k++)
            {
              if (rating[k] > second)
                result++;
            }
          }
          else
          {
            for (var k = j + 1; k < n; k++)
            {
              if (rating[k] < second)
                result++;
            }
          }
        }
      }

      return result;
    }
  }
}
