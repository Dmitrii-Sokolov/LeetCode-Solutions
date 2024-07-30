/// <summary>
/// 786. K-th Smallest Prime Fraction
/// https://leetcode.com/problems/k-th-smallest-prime-fraction
/// 
/// Difficulty Medium
/// Acceptance 68.1%
/// 
/// Array
/// Two Pointers
/// Binary Search
/// Sorting
/// Heap (Priority Queue)
/// </summary>
class Solution {
    public int[] kthSmallestPrimeFraction(int[] arr, int k) {
        int len = arr.length;
        double left = 0;
        double right = 1;
        int[] result = new int[2];
        int total = (len - 1) * len / 2;

        while (left <= right) {
            double middle = (right + left) / 2;
            double fraction = 0;
            int j = 1;
            int count = 0;

            for (var i = 0; i < len - 1; i++) {
                while (j < len && arr[i] > middle * arr[j]) {
                    j++;
                }

                count += j - i - 1;

                if (j < len && fraction < arr[i] * 1.0 / arr[j]) {
                    result = new int[] {arr[i], arr[j]};
                    fraction = arr[i] * 1.0 / arr[j];
                }
            }

            // if (right - left < 0.3){
                // return new int[] { (int)Math.round(middle * 1000), count};
            // }

            if (count == (total - k)) {
                return result;
            } else if (count < (total - k)) {
                // return new int[] {-2, count};
                right = middle;
            } else if (count > (total - k)) {
                // return new int[] {-3, count};
                left = middle;
            }
        }

        return result;
    }
}
