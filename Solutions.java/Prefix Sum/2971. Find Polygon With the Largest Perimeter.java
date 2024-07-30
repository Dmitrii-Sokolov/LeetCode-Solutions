/// <summary>
/// 2971. Find Polygon With the Largest Perimeter
/// https://leetcode.com/problems/find-polygon-with-the-largest-perimeter
/// 
/// Difficulty Medium
/// Acceptance 66.1%
/// 
/// Array
/// Greedy
/// Sorting
/// Prefix Sum
/// </summary>
class Solution
{
    public long largestPerimeter(int[] nums)
    {
        Arrays.sort(nums);

        var len = nums.length;
        long result = 0;
        long sum = 0;

        for(var i = len - 1; i >= 0; i--)
            sum += nums[i];

        for(var i = len - 1; i >= 0; i--)
        {
            var num = nums[i];

            if (sum - num > num)
                return sum;

            sum -= num;
        }

        return -1;        
    }
}
