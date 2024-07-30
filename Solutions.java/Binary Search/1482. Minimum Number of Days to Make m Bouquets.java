/// <summary>
/// 1482. Minimum Number of Days to Make m Bouquets
/// https://leetcode.com/problems/minimum-number-of-days-to-make-m-bouquets
/// 
/// Difficulty Medium
/// Acceptance 56.0%
/// 
/// Array
/// Binary Search
/// </summary>
class Solution {
    public int minDays(int[] bloomDay, int m, int k) {
        if (m > bloomDay.length / k) {
            return -1;
        }

        var min = Integer.MAX_VALUE;
        var max = 0;

        for (var d : bloomDay) {
            if (d < min) {
                min = d;
            }

            if (d > max) {
                max = d;
            }
        }

        while (min < max) {
            var middle = (min + max) >> 1;

            if (check(bloomDay, m, k, middle)) {
                max = middle;
            } else {
                min = middle + 1;
            }
        }

        return max;
    }

    private boolean check(int[] bloomDay, int m, int k, int x) {
        int adj = 0;
        int n = bloomDay.length;
        int i = 0;
        
        while (true) {
            while (i < n && bloomDay[i] > x) {
                i++;
            }

            if (i >= n) {
                return false;
            }
            
            while (i < n && bloomDay[i] <= x) {
                adj++;
                i++;
            }
            m -= adj / k;
            adj = 0;

            if (m <= 0) {
                return true;
            }

            if (m > (n - i - 1) / k || i >= n) {
                return false;
            }
        }
    }
}
