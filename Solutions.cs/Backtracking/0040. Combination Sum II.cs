namespace Problem40
{

  /// <summary>
  /// 40. Combination Sum II
  /// https://leetcode.com/problems/combination-sum-ii
  /// 
  /// Difficulty Medium
  /// Acceptance 55.3%
  /// 
  /// Array
  /// Backtracking
  /// </summary>
  public class Solution
  {
    private int[] Candidates;

    private IList<IList<int>> Result = new List<IList<int>>();

    public IList<IList<int>> CombinationSum2(int[] candidates, int target)
    {
      Candidates = new int[target + 1];
      foreach (var number in candidates)
      {
        if (number <= target)
          Candidates[number]++;
      }

      Check(target, 0, new int[target + 1], target);

      return Result;
    }

    private void Check(int number, int sum, int[] picks, int target)
    {
      if (sum == target)
      {
        var combination = new List<int>();
        for (var n = 0; n < picks.Length; n++)
        {
          for (var k = 0; k < picks[n]; k++)
            combination.Add(n);
        }

        Result.Add(combination);
        return;
      }
      else if (sum > target)
      {
        return;
      }
      else
      {
        if (number == 0)
          return;

        for (var count = Candidates[number]; count >= 0; count--)
        {
          picks[number] = count;
          Check(number - 1, sum + number * count, picks, target);
        }
      }
    }
  }
}
