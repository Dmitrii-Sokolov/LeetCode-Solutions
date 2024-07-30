/// <summary>
/// 50. Pow(x, n)
/// https://leetcode.com/problems/powx-n
/// 
/// Difficulty Medium
/// Acceptance 35.2%
/// 
/// Math
/// Recursion
/// </summary>
class Solution {
    public double myPow(double x, int p) {
        var sign = p > 0;
        long n = p;
        n = sign ? n : -n;
        double result = 1;
        double pow = x;

        while (n > 0) {
            if (n % 2 > 0) {
                result *= pow;
            }

            pow *= pow;
            n /= 2;
        }


        return sign ? result : 1 / result;
    }
}
