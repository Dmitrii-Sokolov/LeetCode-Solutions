namespace Problem380
{

  /// <summary>
  /// 380. Insert Delete GetRandom O(1)
  /// https://leetcode.com/problems/insert-delete-getrandom-o1
  /// 
  /// Difficulty Medium
  /// Acceptance 54.6%
  /// 
  /// Array
  /// Hash Table
  /// Math
  /// Design
  /// Randomized
  /// </summary>
  public class RandomizedSet
  {
    private HashSet<int> ValuesSet = new();
    private List<int> Values = new();
    private Random Random = new();

    public bool Insert(int value)
    {
      var added = ValuesSet.Add(value);
      if (ValuesSet.Add(value))
        Values.Add(value);

      return added;
    }

    public bool Remove(int value)
    {
      var removed = ValuesSet.Remove(value);
      if (removed)
        Values.Remove(value);

      return removed;
    }

    public int GetRandom() => Values[Random.Next(ValuesSet.Count)];
  }
}
