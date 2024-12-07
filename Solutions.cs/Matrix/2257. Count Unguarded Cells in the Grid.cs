namespace Problem2257
{

  /// <summary>
  /// 2257. Count Unguarded Cells in the Grid
  /// https://leetcode.com/problems/count-unguarded-cells-in-the-grid
  /// 
  /// Difficulty Medium
  /// Acceptance 59.2%
  /// 
  /// Array
  /// Matrix
  /// Simulation
  /// </summary>
  public class Solution
  {
    private const int WallGuard = 1;
    private const int Guarded = 2;

    public int CountUnguarded(int m, int n, int[][] guards, int[][] walls)
    {
      var area = new int[m, n];
      var result = m * n;
      for (var i = 0; i < walls.Length; i++)
      {
        var x = walls[i][0];
        var y = walls[i][1];
        area[x, y] = WallGuard;
        result--;
      }

      for (var i = 0; i < guards.Length; i++)
      {
        var x = guards[i][0];
        var y = guards[i][1];
        area[x, y] = WallGuard;
      }

      for (var i = 0; i < guards.Length; i++)
      {
        var x = guards[i][0];
        var y = guards[i][1];
        if (area[x, y] != Guarded)
          result--;

        Secure0(area, x, y, ref result);
        Secure1(area, x, y, ref result);
        Secure2(area, x, y, ref result);
        Secure3(area, x, y, ref result);
      }

      return result;
    }

    private static void Secure0(int[,] area, int x, int y, ref int result)
    {
      for (var x0 = x - 1; x0 >= 0; x0--)
      {
        if (area[x0, y] == WallGuard)
          return;

        if (area[x0, y] != Guarded)
          result--;

        area[x0, y] = Guarded;
      }
    }

    private static void Secure1(int[,] area, int x, int y, ref int result)
    {
      for (var x0 = x + 1; x0 < area.GetLength(0); x0++)
      {
        if (area[x0, y] == WallGuard)
          return;

        if (area[x0, y] != Guarded)
          result--;

        area[x0, y] = Guarded;
      }
    }

    private static void Secure2(int[,] area, int x, int y, ref int result)
    {
      for (var y0 = y - 1; y0 >= 0; y0--)
      {
        if (area[x, y0] == WallGuard)
          return;

        if (area[x, y0] != Guarded)
          result--;

        area[x, y0] = Guarded;
      }
    }

    private static void Secure3(int[,] area, int x, int y, ref int result)
    {
      for (var y0 = y + 1; y0 < area.GetLength(1); y0++)
      {
        if (area[x, y0] == WallGuard)
          return;

        if (area[x, y0] != Guarded)
          result--;

        area[x, y0] = Guarded;
      }
    }
  }
}
