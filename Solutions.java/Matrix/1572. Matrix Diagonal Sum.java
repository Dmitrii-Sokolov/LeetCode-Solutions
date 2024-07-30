/// <summary>
/// 1572. Matrix Diagonal Sum
/// https://leetcode.com/problems/matrix-diagonal-sum
/// 
/// Difficulty Easy
/// Acceptance 83.1%
/// 
/// Array
/// Matrix
/// </summary>
class Solution {
    public int diagonalSum(int[][] mat) {
        var n = mat.length;
        var result = n % 2 > 0 ? -mat[n / 2][n / 2] : 0;

        for (var i = 0; i < mat.length; i++) {
            result += mat[i][i];
        }
        
        for (var i = 0; i < mat.length; i++) {
            result += mat[i][mat.length - 1 - i];
        }

        return result;
    }
}
