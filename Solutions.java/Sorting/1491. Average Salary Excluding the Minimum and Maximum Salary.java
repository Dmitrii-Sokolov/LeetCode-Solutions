/// <summary>
/// 1491. Average Salary Excluding the Minimum and Maximum Salary
/// https://leetcode.com/problems/average-salary-excluding-the-minimum-and-maximum-salary
/// 
/// Difficulty Easy
/// Acceptance 63.5%
/// 
/// Array
/// Sorting
/// </summary>
class Solution {
    public double average(int[] salary) {
        var min = 1000000;
        var max = 1000;
        var sum = 0;
        var count = salary.length;
        for (var s : salary) {
            min = Math.min(min, s);
            max = Math.max(max, s);
            sum += s;
        }

        return (sum - min - max) * 1.0 / (count - 2);
    }
}
