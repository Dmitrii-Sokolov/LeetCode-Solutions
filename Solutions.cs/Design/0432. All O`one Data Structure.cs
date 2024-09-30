namespace Problem432
{

  /// <summary>
  /// 432. All O`one Data Structure
  /// https://leetcode.com/problems/all-oone-data-structure
  /// 
  /// Difficulty Hard
  /// Acceptance 38.6%
  /// 
  /// Hash Table
  /// Linked List
  /// Design
  /// Doubly-Linked List
  /// </summary>
  public class AllOne
  {
    private readonly Dictionary<string, int> Scores = [];
    private readonly SortedDictionary<int, List<string>> Keys = [];

    public void Inc(string key)
    {
      if (Scores.TryGetValue(key, out var score))
      {
        Keys[score].Remove(key);

        if (Keys[score].Count == 0)
          Keys.Remove(score);
      }
      else
      {
        score = 0;
      }

      Scores[key] = score + 1;

      if (Keys.TryGetValue(score + 1, out var list))
        list.Add(key);
      else
      {
        Keys.Add(score + 1, [key]);
      }
    }

    public void Dec(string key)
    {
      var score = Scores[key];
      Scores[key]--;

      if (Scores[key] == 0)
        Scores.Remove(key);

      Keys[score].Remove(key);

      if (Keys[score].Count == 0)
        Keys.Remove(score);

      if (score - 1 > 0)
      {
        if (Keys.TryGetValue(score - 1, out var list))
          list.Add(key);
        else
        {
          Keys.Add(score - 1, [key]);
        }
      }
    }

    public string GetMaxKey() => Keys.Count > 0 ? Keys.Last().Value.First() : "";

    public string GetMinKey() => Keys.Count > 0 ? Keys.First().Value.First() : "";
  }
}
