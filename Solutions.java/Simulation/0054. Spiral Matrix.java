/// <summary>
/// 54. Spiral Matrix
/// https://leetcode.com/problems/spiral-matrix
/// 
/// Difficulty Medium
/// Acceptance 50.5%
/// 
/// Array
/// Matrix
/// Simulation
/// </summary>
class Solution {
    public List<Integer> spiralOrder(int[][] matrix) {
        var m = matrix.length;
        var n = matrix[0].length;
        var result = new ArrayList<Integer>(m * n);
        var i = 0;
        var x = 0;
        var y = 0;
        var stepX = 1;
        var stepY = 0;
        while (i < m * n) {
            i++;
            result.add(matrix[y][x]);
            matrix[y][x] = -200;
            var nextX = x + stepX;
            var nextY = y + stepY;
            if (nextX < 0 || nextX >= n ||
                nextY < 0 || nextY >= m || 
                matrix[nextY][nextX] == -200) {
                var temp = stepY;
                stepY = stepX;
                stepX = -temp;
            }

            x += stepX;
            y += stepY;
        }

        return result;
    }
}
