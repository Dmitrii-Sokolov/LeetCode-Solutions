/// <summary>
/// 846. Hand of Straights
/// https://leetcode.com/problems/hand-of-straights
/// 
/// Difficulty Medium
/// Acceptance 56.7%
/// 
/// Array
/// Hash Table
/// Greedy
/// Sorting
/// </summary>
class Solution {
    public boolean isNStraightHand(int[] nums, int groupSize) {
        if (nums.length % groupSize > 0) {
            return false;
        } else if (groupSize == 1) {
            return true;
        }

        Arrays.sort(nums);
        var i = 0;
        while (i < nums.length) {
            while (i < nums.length && nums[i] == -1) {
                i++;
            }

            if (i == nums.length) {
                return true;
            }

            var start = nums[i];
            var shift = i;
            for (var n = 0; n < groupSize; n++) {
                while (shift < nums.length && nums[shift] != start + n) {
                    shift++;
                }
                
                if (shift == nums.length) {
                    return false;
                }

                nums[shift] = -1;
            }
        }

        return true;

        // var len = nums.length;
        // var map = new HashMap<Integer, Integer>();
        // for (var c : hand) {
        //     map.put(c, map.getOrDefault(c, 0) + 1);
        // }

        // while (!map.isEmpty()) {
        //     var c = Collections.min(map.keySet());;
        //     for (var i = 0; i < groupSize; i++) {
        //         if (map.containsKey(c + i)) {
        //             var count = map.get(c + i);
        //             if (count > 1) {
        //                 map.put(c + i, count - 1);
        //             } else {
        //                 map.remove(c + i);
        //             }
        //         } else {
        //             return false;
        //         }
        //     }
        // }

        // return true;
    }
}
