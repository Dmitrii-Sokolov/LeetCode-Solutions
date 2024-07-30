/// <summary>
/// 1219. Path with Maximum Gold
/// https://leetcode.com/problems/path-with-maximum-gold
/// 
/// Difficulty Medium
/// Acceptance 68.0%
/// 
/// Array
/// Backtracking
/// Matrix
/// </summary>
class Solution {
    public int getMaximumGold(int[][] grid) {
        height = grid.length;
        width = grid[0].length;
        mine = grid;

        for (var x = 0; x < width; x++) {
            for (var y = 0; y < height; y++) {
                Try(x, y, 0);
            }
        }

        return result;
    }

    int width = 0;
    int height = 0;
    int result = 0;
    int[][] mine;

    private void Try(int x, int y, int initial) {
        if (x < 0 || width <= x ||
            y < 0 || height <= y ||
            mine[y][x] <= 0) {
            result = Math.max(result, initial);
            return;
            }

        initial += mine[y][x];
        mine[y][x] *= -1;

        Try(x + 1, y, initial);
        Try(x - 1, y, initial);
        Try(x, y + 1, initial);
        Try(x, y - 1, initial);

        mine[y][x] *= -1;
    }
}
