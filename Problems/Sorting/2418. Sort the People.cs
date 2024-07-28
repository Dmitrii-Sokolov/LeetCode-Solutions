namespace Problem2418
{

  /// <summary>
  /// 2418. Sort the People
  /// https://leetcode.com/problems/sort-the-people/description/
  /// 
  /// Difficulty Easy 85.1%
  /// 
  /// Array
  /// Hash Table
  /// String
  /// Sorting
  /// </summary>
  public class Solution
  {
    public string[] SortPeople(string[] names, int[] heights)
    {
      var array = Enumerable.Range(0, names.Length).Select(i => (names[i], heights[i])).ToArray();
      Array.Sort(array, (a, b) => b.Item2.CompareTo(a.Item2));
      return array.Select(a => a.Item1).ToArray();
    }
  }
}
