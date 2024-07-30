namespace Problem78
{

  /// <summary>
  /// 78. Subsets
  /// https://leetcode.com/problems/subsets
  /// 
  /// Difficulty Medium
  /// Acceptance 78.8%
  /// 
  /// Array
  /// Backtracking
  /// Bit Manipulation
  /// </summary>
  public class Solution
  {
    public IList<IList<int>> Subsets(int[] nums)
    {
      var result = new List<IList<int>>(1 << nums.Length);

      for (var i = 0; i < 1 << nums.Length; i++)
      {
        var row = new List<int>();
        var key = i;
        var index = 0;
        while (key > 0)
        {
          if (key % 2 == 1)
            row.Add(nums[index]);
          key /= 2;
          index++;
        }
        result.Add(row);
      }

      return result;
    }
  }
}
