namespace Problem1207
{

  /// <summary>
  /// 1207. Unique Number of Occurrences
  /// https://leetcode.com/problems/unique-number-of-occurrences 
  /// 
  /// Difficulty Easy
  /// Acceptance 77.8%
  /// 
  /// Array
  /// Hash Table
  /// </summary>
  public class Solution
  {
    public bool UniqueOccurrences(int[] numbers)
    {
      var counts = new Dictionary<int, int>();
      foreach (var number in numbers)
        counts[number] = counts.GetValueOrDefault(number, 0) + 1;

      var set = new HashSet<int>();
      foreach (var count in counts.Values)
      {
        if (!set.Add(count))
          return false;
      }

      return true;
    }
  }
}
