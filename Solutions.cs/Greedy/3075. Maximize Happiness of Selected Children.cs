namespace Problem3075
{

  /// <summary>
  /// 3075. Maximize Happiness of Selected Children
  /// https://leetcode.com/problems/maximize-happiness-of-selected-children
  /// 
  /// Difficulty Medium
  /// Acceptance 55.0%
  /// 
  /// Array
  /// Greedy
  /// Sorting
  /// </summary>
  public class Solution
  {
    public long MaximumHappinessSum(int[] happiness, int k)
    {
      Array.Sort(happiness);
      long result = 0;

      for (var i = happiness.Length - 1; i > happiness.Length - 1 - k; i--)
      {
        var val = happiness[i] - (happiness.Length - 1 - i);
        if (val > 0)
          result += val;
        else
        {
          return result;
        }
      }

      return result;
    }
  }
}
