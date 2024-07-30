/// <summary>
/// 861. Score After Flipping Matrix
/// https://leetcode.com/problems/score-after-flipping-matrix
/// 
/// Difficulty Medium
/// Acceptance 80.4%
/// 
/// Array
/// Greedy
/// Bit Manipulation
/// Matrix
/// </summary>
class Solution {
    public int matrixScore(int[][] grid) {
        var height = grid.length;
        var width = grid[0].length;

        var maxRowValue = (1 << width) - 1;
        var rowValues = new int[height];

        for (var k = 0; k < height; k++) {
            for (var i = 0; i < width; i++) {
                rowValues[k] = 2 * rowValues[k] + grid[k][i];
            }
        }

        var columnValues = new int[width];
        for (var k = 0; k < height; k++){
            rowValues[k] = Math.max(rowValues[k], maxRowValue - rowValues[k]);
            var value = rowValues[k];

            for (var i = width - 1; i >= 0; i--) {
                columnValues[i] += (value % 2);
                value /= 2;
            }
        }

        var result = 0;
        for (var i = 0; i < width; i++) {
            columnValues[i] = Math.max(columnValues[i], height - columnValues[i]);
            result += (1 << (width - 1 - i)) * columnValues[i];
        }
        
        return result;
    }
}
