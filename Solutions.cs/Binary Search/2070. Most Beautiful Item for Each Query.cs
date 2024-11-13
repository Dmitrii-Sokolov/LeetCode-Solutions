namespace Problem2070
{

  /// <summary>
  /// 2070. Most Beautiful Item for Each Query
  /// https://leetcode.com/problems/most-beautiful-item-for-each-query
  /// 
  /// Difficulty Medium
  /// Acceptance 57.7%
  /// 
  /// Array
  /// Binary Search
  /// Sorting
  /// </summary>
  public class Solution
  {
    public int[] MaximumBeauty(int[][] itemsRaw, int[] queries)
    {
      Array.Sort(itemsRaw, (a, b) => a[0].CompareTo(b[0]));
      var items = new List<(int Price, int Beauty)>(itemsRaw.Length);
      items.Add((0, 0));
      var max = 0;
      foreach (var item in itemsRaw)
      {
        if (item[1] > max)
        {
          max = item[1];
          items.Add((item[0], item[1]));
        }
      }

      return queries.Select(q => FindBest(items, q)).ToArray();
    }

    private static int FindBest(List<(int Price, int Beauty)> items, int price)
    {
      var min = 0;
      var max = items.Count - 1;
      while (min < max)
      {
        var middle = 1 + (max + min >> 1);
        if (items[middle].Price > price)
        {
          max = middle - 1;
        }
        else
        {
          min = middle;
        }
      }

      return items[max].Beauty;
    }
  }
}
