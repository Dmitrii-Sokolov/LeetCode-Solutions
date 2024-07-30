/// <summary>
/// 1296. Divide Array in Sets of K Consecutive Numbers
/// https://leetcode.com/problems/divide-array-in-sets-of-k-consecutive-numbers
/// 
/// Difficulty Medium
/// Acceptance 58.5%
/// 
/// Array
/// Hash Table
/// Greedy
/// Sorting
/// </summary>
class Solution {
    public boolean isPossibleDivide(int[] hand, int groupSize) {
        var len = hand.length;
        if (len % groupSize > 0) {
            return false;
        } else if (groupSize == 1) {
            return true;
        }
        
        var map = new HashMap<Integer, Integer>();
        for (var c : hand) {
            map.put(c, map.getOrDefault(c, 0) + 1);
        }

        while (!map.isEmpty()) {
            var c = Collections.min(map.keySet());;
            for (var i = 0; i < groupSize; i++) {
                if (map.containsKey(c + i)) {
                    var count = map.get(c + i);
                    if (count > 1) {
                        map.put(c + i, count - 1);
                    } else {
                        map.remove(c + i);
                    }
                } else {
                    return false;
                }
            }
        }

        return true;        
    }
}
