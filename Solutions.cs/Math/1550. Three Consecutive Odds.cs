namespace Problem1550
{

  /// <summary>
  /// 1550. Three Consecutive Odds
  /// https://leetcode.com/problems/three-consecutive-odds
  /// 
  /// Difficulty Easy
  /// Acceptance 68.4%
  /// 
  /// Array
  /// </summary>
  public class Solution
  {
    public bool ThreeConsecutiveOdds(int[] arr)
    {
      var count = 0;
      foreach (var a in arr)
      {
        if (a % 2 == 1)
        {
          count++;
          if (count == 3)
            return true;
        }
        else
        {
          count = 0;
        }
      }

      return false;
    }
  }
}
