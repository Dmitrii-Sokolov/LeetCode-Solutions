/// <summary>
/// 1137. N-th Tribonacci Number
/// https://leetcode.com/problems/n-th-tribonacci-number
/// 
/// Difficulty Easy
/// Acceptance 63.8%
/// 
/// Math
/// Dynamic Programming
/// Memoization
/// </summary>
class Solution {
    public int tribonacci(int n){
        if (n == 0)
            return 0;

        if (n == 1 || n == 2)
            return 1;

        var numbers = new int[n + 1];
        numbers[0] = 0;
        numbers[1] = 1;
        numbers[2] = 1;

        for (var i = 3; i < n + 1; i++){
            numbers[i] = numbers[i - 1] + numbers[i - 2] + numbers[i - 3];
        }
        
        return numbers[n];
    }
}
