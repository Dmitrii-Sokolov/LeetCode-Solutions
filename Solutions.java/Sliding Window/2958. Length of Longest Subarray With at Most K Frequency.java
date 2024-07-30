/// <summary>
/// 2958. Length of Longest Subarray With at Most K Frequency
/// https://leetcode.com/problems/length-of-longest-subarray-with-at-most-k-frequency
/// 
/// Difficulty Medium
/// Acceptance 55.8%
/// 
/// Array
/// Hash Table
/// Sliding Window
/// </summary>
import java.util.Dictionary;
import java.util.Enumeration;
import java.util.Hashtable;

class Solution
{
    public int maxSubarrayLength(int[] nums, int k)
    {
        var left = 0;
        var right = 0;
        var max = 0;
        Dictionary<Integer, Integer> freq = new Hashtable<>();
        //var freq = new Dictionary<int, int>();

        while(right < nums.length)
        {
            var f = freq.get(nums[right]);
            if (f == null)
                freq.put(nums[right], 1);
            else
                freq.put(nums[right], f + 1);

            while (freq.get(nums[right]) > k)
            {
                freq.put(nums[left], freq.get(nums[left]) - 1);
                left++;
            }

            right++;
            max = Math.max(max, right - left);
        }

        return max;        
    }
}
