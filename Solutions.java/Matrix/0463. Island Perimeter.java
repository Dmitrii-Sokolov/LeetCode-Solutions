/// <summary>
/// 463. Island Perimeter
/// https://leetcode.com/problems/island-perimeter
/// 
/// Difficulty Easy
/// Acceptance 73.0%
/// 
/// Array
/// Depth-First Search
/// Breadth-First Search
/// Matrix
/// </summary>
class Solution
{
  public int islandPerimeter(int[][] grid)
  {
    var len0 = grid.length;
    var len1 = grid[0].length;
    var result = 0;

    for (var i = 0; i < len0; i++)
    {
      result += grid[i][0];
      result += grid[i][len1 - 1];
    }

    for (var i = 0; i < len1; i++)
    {
      result += grid[0][i];
      result += grid[len0 - 1][i];
    }

    for (var i = 0; i < len0 - 1; i++)
    {
      for (var n = 0; n < len1; n++)
      {
        if (grid[i][n] != grid[i + 1][n])
          result++;
      }
    }

    for (var i = 0; i < len0; i++)
    {
      for (var n = 0; n < len1 - 1; n++)
      {
        if (grid[i][n] != grid[i][n + 1])
          result++;
      }
    }

    return result;
  }
}
