/// <summary>
/// 43. Multiply Strings
/// https://leetcode.com/problems/multiply-strings
/// 
/// Difficulty Medium
/// Acceptance 40.7%
/// 
/// Math
/// String
/// Simulation
/// </summary>
class Solution {
    public String multiply(String num1, String num2) {
        if (num1.equals("0") || num2.equals("0")) {
            return "0";
        }

        var result = new int[num1.length() + num2.length()];
        for (var i1 = 0; i1 < num1.length(); i1++) {
            for (var i2 = 0; i2 < num2.length(); i2++) {
                var shift = i1 + i2;

                result[i1 + i2] += (num1.charAt(num1.length() - i1 - 1) - '0') * (num2.charAt(num2.length() - i2 - 1) - '0');
            }
        }

        for (var i = 0; i < result.length - 1; i++) {
            result[i + 1] += result[i] / 10;
            result[i] %= 10;
        }

        var end = result.length - 1;
        while (end >= 1 && result[end] == 0) {
            end--;
        }

        var sb = new StringBuilder();
        for (; end >= 0; end--) {
            sb.append(String.valueOf(result[end]));
        }
        
        return sb.toString();
    }
}
