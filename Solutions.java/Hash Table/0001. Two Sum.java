/// <summary>
/// 1. Two Sum
/// https://leetcode.com/problems/two-sum
/// 
/// Difficulty Easy
/// Acceptance 53.2%
/// 
/// Array
/// Hash Table
/// </summary>
class Solution
{
  public int[] twoSum(int[] nums, int target)
  {
    var history = new HashMap<Integer, Integer>(nums.length);
    for (var i = 0; i < nums.length; i++)
    {
      if (history.containsKey(target - nums[i]))
      {
        return new int[] { history.get(target - nums[i]), i };
      }

      history.put(nums[i], i);
    }

    return new int[2];
  }
}
