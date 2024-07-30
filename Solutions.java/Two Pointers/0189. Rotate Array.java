/// <summary>
/// 189. Rotate Array
/// https://leetcode.com/problems/rotate-array
/// 
/// Difficulty Medium
/// Acceptance 41.1%
/// 
/// Array
/// Math
/// Two Pointers
/// </summary>
class Solution {
public void rotate(int[] nums, int k) {
        int n=nums.length;
        k=k%n;
        reverse(nums,0,n-1);
        reverse(nums,0,k-1);
        reverse(nums,k,n-1);

    }

    // public void rotate(int[] nums, int k) {
    //     var n = nums.length;
    //     k = k % n;

    //     reverse(nums, 0, n - 1);
    //     reverse(nums, 0, k - 1);
    //     reverse(nums, k, n - 1);
    // }

    private static void reverse(int array[], int from, int to)
    {
        int temp;
        for (var i = 0; i < (to + 1 - from) / 2; i++) { 
            temp = array[from + i];
            array[from + i] = array[to - i];
            array[to - i] = temp;
        }
    }

    // public void rotate(int[] nums, int k) {
    //     if (k == 0) {
    //         return;
    //     }

    //     var gcd = getGCD(nums.length, k);

    //     for (var i = 0; i < gcd; i++) {
    //         var next = i;
    //         var temp = nums[next];
    //         for (var n = 0; n < nums.length / gcd - 1; n++) {
    //             var shift = Math.floorMod(next + nums.length - k, nums.length);
    //             nums[next] = nums[shift];
    //             next = shift;
    //         }
    //         nums[next] = temp;
    //     }
    // }

    // private int getGCD(int a, int b) {
    //     var temp = 0;
    //     if (a < b) {
    //         temp = a;
    //         a = b;
    //         b = temp;
    //     }

    //     while (a % b > 0) {
    //         a = a % b;
    //         temp = a;
    //         a = b;
    //         b = temp;
    //     }

    //     return b;
    // }
}
