namespace Problem1331
{

  /// <summary>
  /// 1331. Rank Transform of an Array
  /// https://leetcode.com/problems/rank-transform-of-an-array
  /// 
  /// Difficulty Easy
  /// Acceptance 70.4%
  /// 
  /// Array
  /// Hash Table
  /// Sorting
  /// </summary>
  public class Solution
  {
    public int[] ArrayRankTransform(int[] array)
    {
      var temp = array.ToArray();
      Array.Sort(temp);

      var rank = 0;
      var ranks = new Dictionary<int, int>();
      var previous = int.MaxValue;
      for (var i = 0; i < temp.Length; i++)
      {
        if (temp[i] != previous)
        {
          previous = temp[i];
          rank++;
          ranks.Add(previous, rank);
        }
      }

      for (var i = 0; i < array.Length; i++)
        array[i] = ranks[array[i]];

      return array;
    }
  }
}
