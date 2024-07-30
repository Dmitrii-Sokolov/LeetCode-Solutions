/// <summary>
/// 15. 3Sum
/// https://leetcode.com/problems/3sum
/// 
/// Difficulty Medium
/// Acceptance 35.0%
/// 
/// Array
/// Two Pointers
/// Sorting
/// </summary>
class Solution {
    public List<List<Integer>> threeSum(int[] nums) {
        Arrays.sort(nums);
        Set<List<Integer>> result = new HashSet<>();

        for (var i = 0; i < nums.length - 2; i++) {
            while (i > 0 && nums[i] == nums[i - 1]) {
                i++;
                if (i == nums.length - 2) {
                    return new ArrayList<List<Integer>>(result);
                }
            }
            
            var n = nums[i];
            var a = i + 1;
            var b = i + 2;

            while (b < nums.length &&
                nums[a] + nums[b] + n < 0) {
                a++;
                b++;
            }

            while (i < a && b < nums.length) {
                if (nums[a] + nums[b] + n == 0) {
                    add(n, nums[a], nums[b], result);
                }

                if (nums[a] + nums[b] + n < 0) {
                    do {
                        b++;
                    } while (b < nums.length && nums[b] == nums[b - 1]);
                } else {
                    do {
                        a--;
                    } while (a > i && nums[a] == nums[a + 1]);
                }
            }
        }
        
        return new ArrayList<List<Integer>>(result);
    }

    private void add(int a, int b, int c, Set<List<Integer>> result) {
        var tri = new ArrayList<Integer>();
        
        tri.add(a);
        tri.add(b);
        tri.add(c);
        result.add(tri);
    }
}
