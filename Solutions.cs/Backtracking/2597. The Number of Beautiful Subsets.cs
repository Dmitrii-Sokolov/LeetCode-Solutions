namespace Problem2597
{

  /// <summary>
  /// 2597. The Number of Beautiful Subsets
  /// https://leetcode.com/problems/the-number-of-beautiful-subsets
  /// 
  /// Difficulty Medium
  /// Acceptance 51.2%
  /// 
  /// Array
  /// Hash Table
  /// Math
  /// Dynamic Programming
  /// Backtracking
  /// Sorting
  /// Combinatorics
  /// </summary>
  public class Solution
  {
    public int BeautifulSubsets(int[] nums, int k)
    {
      Nums = nums;
      K = k;

      Array.Sort(Nums);
      Check(0);

      return Result;
    }

    private int[] Nums;
    private int K;

    private int[] Counts = new int[1001];
    private int Result;

    private void Check(int p)
    {
      if (p == Nums.Length)
        return;

      var n = Nums[p];
      var shift1 = n - K;
      var shift2 = n + K;

      if ((shift1 < 0 || shift1 >= 1001 ||
          Counts[shift1] == 0) &&
          (shift2 < 0 || shift2 >= 1001 ||
          Counts[shift2] == 0))
      {
        Counts[n]++;
        Check(p + 1);
        Counts[n]--;
        Result++;
      }

      Check(p + 1);
    }
  }
}
