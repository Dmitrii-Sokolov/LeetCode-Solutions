namespace Problem1079
{

  /// <summary>
  /// 1079. Letter Tile Possibilities
  /// https://leetcode.com/problems/letter-tile-possibilities
  /// 
  /// Difficulty Medium
  /// Acceptance 78.9%
  /// 
  /// Hash Table
  /// String
  /// Backtracking
  /// Counting
  /// </summary>
  public class Solution
  {
    public int NumTilePossibilities(string tilesRaw)
    {
      var counts = new Dictionary<char, int>();
      foreach (var tile in tilesRaw)
        counts[tile] = counts.GetValueOrDefault(tile) + 1;

      var tiles = counts.Values.ToArray();
      return Proceed(tiles) - 1;
    }

    private static int Proceed(int[] tiles)
    {
      var result = 1;
      for (var i = 0; i < tiles.Length; i++)
      {
        if (tiles[i] > 0)
        {
          tiles[i]--;
          result += Proceed(tiles);
          tiles[i]++;
        }
      }

      return result;
    }
  }
}
