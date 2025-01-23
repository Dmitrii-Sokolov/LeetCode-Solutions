namespace Problem407
{

  /// <summary>
  /// 407. Trapping Rain Water II
  /// https://leetcode.com/problems/trapping-rain-water-ii
  /// 
  /// Difficulty Hard
  /// Acceptance 51.5%
  /// 
  /// Array
  /// Breadth-First Search
  /// Heap (Priority Queue)
  /// Matrix
  /// </summary>
  public class Solution
  {
    public int TrapRainWater(int[][] terrainMapRaw)
    {
      var width = terrainMapRaw.Length;
      var length = terrainMapRaw[0].Length;
      Span<int> waterMap = stackalloc int[width * length];
      Span<int> terrainMap = stackalloc int[width * length];

      for (var x = 0; x < width; x++)
      {
        for (var y = 0; y < length; y++)
          terrainMap[x * length + y] = terrainMapRaw[x][y];
      }

      for (var x = 1; x < width - 1; x++)
      {
        waterMap[x * length + 0] = terrainMap[x * length + 0];
        waterMap[x * length + length - 1] = terrainMap[x * length + length - 1];
      }

      for (var y = 1; y < length - 1; y++)
      {
        waterMap[0 * length + y] = terrainMap[0 * length + y];
        waterMap[(width - 1) * length + y] = terrainMap[(width - 1) * length + y];
      }

      for (var x = 1; x < width - 1; x++)
      {
        for (var y = 1; y < length - 1; y++)
          waterMap[x * length + y] = int.MaxValue;
      }

      var unstable = true;
      while (unstable)
      {
        unstable = false;

        for (var x = 1; x < width - 1; x++)
        {
          for (var y = 1; y < length - 1; y++)
          {
            if (waterMap[x * length + y] == terrainMap[x * length + y])
              continue;

            var min = Math.Max(Math.Min(waterMap[x * length + y - 1], waterMap[(x - 1) * length + y]), terrainMap[x * length + y]);
            if (min < waterMap[x * length + y])
            {
              waterMap[x * length + y] = min;
              unstable = true;
            }
          }
        }

        for (var x = width - 2; x > 0; x--)
        {
          for (var y = length - 2; y > 0; y--)
          {
            if (waterMap[x * length + y] == terrainMap[x * length + y])
              continue;

            var min = Math.Max(Math.Min(waterMap[x * length + y + 1], waterMap[(x + 1) * length + y]), terrainMap[x * length + y]);
            if (min < waterMap[x * length + y])
            {
              waterMap[x * length + y] = min;
              unstable = true;
            }
          }
        }
      }

      var result = 0;
      for (var x = 1; x < width - 1; x++)
      {
        for (var y = 1; y < length - 1; y++)
          result += waterMap[x * length + y] - terrainMap[x * length + y];
      }

      return result;
    }
  }
}
