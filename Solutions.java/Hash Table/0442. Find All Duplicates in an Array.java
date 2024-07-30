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
class Solution
{
    public List<Integer> findDuplicates(int[] nums)
    {
        var duplicates = new ArrayList<Integer>();

        for(var i = 0; i < nums.length; i++)
        {
            var abs = Math.abs(nums[i]);

            if(nums[abs - 1] < 0)
                duplicates.add(abs);

            nums[abs - 1] *= -1;
        }

        return duplicates;
    }
}
