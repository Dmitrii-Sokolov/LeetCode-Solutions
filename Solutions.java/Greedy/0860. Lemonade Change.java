/// <summary>
/// 860. Lemonade Change
/// https://leetcode.com/problems/lemonade-change
/// 
/// Difficulty Easy
/// Acceptance 53.8%
/// 
/// Array
/// Greedy
/// </summary>
class Solution {
    public boolean lemonadeChange(int[] bills) {
        var count5 = 0;
        var count10 = 0;
        var count20 = 0;

        for (var b : bills) {
            if (b == 5) {
                count5++;
            } else if (b == 10) {
                if (count5 >= 1) {
                    count5--;
                    count10++;
                } else {
                    return false; 
                }
            } else if (b == 20) {
                if (count5 >= 1 && count10 >= 1) {
                    count5--;
                    count10--;
                    count20++;
                } else if (count5 >= 3) {
                    count5 -= 3;
                    count20++;
                } else {
                    return false; 
                }
            }
        }

        return true;
        
    }
}
