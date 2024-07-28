namespace Problem1588
{

  /// <summary>
  /// 1588. Sum of All Odd Length Subarrays
  /// https://leetcode.com/problems/sum-of-all-odd-length-subarrays/description/
  /// 
  /// Difficulty Easy 83.1%
  /// 
  /// Array
  /// Math
  /// Prefix Sum
  /// </summary>
  class Solution {
    public int sumOddLengthSubarrays(int[] arr) {
        var result = 0;

        for (var i = 0; i < arr.length / 2; i++) {
            var multiplier = calcMultiplier(i, arr.length - i - 1); ;
            result += arr[i] * multiplier;
            result += arr[arr.length - i - 1] * multiplier;
        }

        if (arr.length % 2 > 0) {
            var multiplier = calcMultiplier(arr.length / 2, arr.length / 2); ;
            result += arr[arr.length / 2] * multiplier;
        }

        return result;
    }

    private int calcMultiplier(int left, int right) {
        return ((left + 1) * (right + 1) + 1) / 2;
    }
}
}
