/// <summary>
/// 1552. Magnetic Force Between Two Balls
/// https://leetcode.com/problems/magnetic-force-between-two-balls
/// 
/// Difficulty Medium
/// Acceptance 71.1%
/// 
/// Array
/// Binary Search
/// Sorting
/// </summary>
class Solution {
    public int maxDistance(int[] position, int m) {
        Arrays.sort(position);
        var min = 1;
        var max = (position[position.length - 1] - position[0]) / (m - 1);
        var result = max;

        while (min <= max) {
            var middle = min + (max - min) / 2;

            if (check(position, m, middle)) {
                min = middle + 1;
                result = middle;
            } else {
                max = middle - 1;
            }
        }

        return result;
    }

    private boolean check(int[] position, int m, int x) {
        var last = position[0];
        m--;

        for (var i = 1; i < position.length; i++) {
            if (position[i] - last >= x) {
                last = position[i];
                m--;
                if (m == 0) {
                    return true;
                }
            }
        }

        return false;
    }
}
