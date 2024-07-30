namespace Problem442
{

  /// <summary>
  /// 442. Find All Duplicates in an Array
  /// https://leetcode.com/problems/find-all-duplicates-in-an-array
  /// 
  /// Difficulty Medium
  /// Acceptance 75.8%
  /// 
  /// Array
  /// Hash Table
  /// </summary>
  public class Solution
  {
    public IList<int> FindDuplicates(int[] nums)
    {
      var duplicates = new List<int>();

      for (var i = 0; i < nums.Length; i++)
      {
        var abs = Math.Abs(nums[i]);

        if (nums[abs - 1] < 0)
          duplicates.Add(abs);

        nums[abs - 1] *= -1;
      }

      return duplicates;
    }
  }
}
