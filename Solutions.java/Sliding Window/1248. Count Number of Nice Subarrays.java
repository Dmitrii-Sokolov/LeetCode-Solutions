/// <summary>
/// 1248. Count Number of Nice Subarrays
/// https://leetcode.com/problems/count-number-of-nice-subarrays
/// 
/// Difficulty Medium
/// Acceptance 71.2%
/// 
/// Array
/// Hash Table
/// Math
/// Sliding Window
/// </summary>
class Solution {
    public int numberOfSubarrays(int[] nums, int k) {
        Queue<Integer> queue = new LinkedList<>();
        var last = -1;
        var i = 0;
        while (k > 0 && i < nums.length) {
            if (nums[i] % 2 > 0) {
                queue.add(i - last);
                last = i;
                k--;
            }

            i++;
        }
        
        if (k > 0) {
            return 0;
        }

        var result = 0;
        while (i <= nums.length) {
            var value = 0;
            while (i < nums.length && nums[i] % 2 == 0) {
                i++;
            }

            result += queue.poll() * (i - last);
            queue.add(i - last);

            last = i;
            i++;
        }

        return result;
    }
}
