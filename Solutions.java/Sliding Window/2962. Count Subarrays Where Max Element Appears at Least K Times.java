/// <summary>
/// 2962. Count Subarrays Where Max Element Appears at Least K Times
/// https://leetcode.com/problems/count-subarrays-where-max-element-appears-at-least-k-times
/// 
/// Difficulty Medium
/// Acceptance 59.0%
/// 
/// Array
/// Sliding Window
/// </summary>
class Solution
{
    public long countSubarrays(int[] nums, int k)
    {
        var len = nums.length;
        if (k > len)
            return 0;

        long result = 0;
        int left = 0;
        int right = -1;
        int max = 0;

        for(var i = 0; i < len; i++)
            max = Math.max(nums[i], max);

        while(k > 0 && right < len - 1)
        {
            if (nums[++right] == max)
                k--;
        }

        if (k > 0)
            return 0;

        while(right < len)
        {
            var r = 1;
            while(right + r < len && nums[right + r] != max)
                r++;

            while(nums[left] != max)
                left++;

            result += (long)(left + 1) * (long)r;

            left++;
            right += r;
        }

        return result;
    }
}
