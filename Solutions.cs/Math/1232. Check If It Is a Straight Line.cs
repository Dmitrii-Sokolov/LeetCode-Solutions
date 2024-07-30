namespace Problem1232
{

  /// <summary>
  /// 1232. Check If It Is a Straight Line
  /// https://leetcode.com/problems/check-if-it-is-a-straight-line
  /// 
  /// Difficulty Easy
  /// Acceptance 39.5%
  /// 
  /// Array
  /// Math
  /// Geometry
  /// </summary>
  public class Solution
  {
    public bool CheckStraightLine(int[][] points)
    {
      if (points.Length == 2)
        return true;

      var deltaX = points[1][0] - points[0][0];
      var deltaY = points[1][1] - points[0][1];

      for (var i = 2; i < points.Length; i++)
      {
        if (deltaX * (points[i][1] - points[0][1]) != (points[i][0] - points[0][0]) * deltaY)
          return false;
      }

      return true;
    }
  }
}
