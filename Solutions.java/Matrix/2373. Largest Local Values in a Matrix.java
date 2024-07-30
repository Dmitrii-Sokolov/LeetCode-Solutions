/// <summary>
/// 2373. Largest Local Values in a Matrix
/// https://leetcode.com/problems/largest-local-values-in-a-matrix
/// 
/// Difficulty Easy
/// Acceptance 88.0%
/// 
/// Array
/// Matrix
/// </summary>
class Solution {
    public int[][] largestLocal(int[][] grid) {
        var n = grid.length;
        var result = new int[n -2 ][n - 2];

        for (var y = 1; y < n - 1; y++) {
            var a0 = max(grid[0][y - 1], grid[0][y], grid[0][y + 1]);
            var a1 = max(grid[1][y - 1], grid[1][y], grid[1][y + 1]);
            for (var x = 1; x < n - 1; x++) {
                var a2 = max(grid[x + 1][y - 1], grid[x + 1][y], grid[x + 1][y + 1]);
                result[x - 1][y - 1] = max(a0, a1, a2);
                a0 = a1;
                a1 = a2;
            }
        }
        
        return result;
    }

    private int max(int a, int b, int c) {
        return Math.max(Math.max(a, b), c);
    }
}
