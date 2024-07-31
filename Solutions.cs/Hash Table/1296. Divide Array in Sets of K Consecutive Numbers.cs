namespace Problem1296
{

  /// <summary>
  /// 1296. Divide Array in Sets of K Consecutive Numbers
  /// https://leetcode.com/problems/divide-array-in-sets-of-k-consecutive-numbers
  /// 
  /// Difficulty Medium
  /// Acceptance 58.5%
  /// 
  /// Array
  /// Hash Table
  /// Greedy
  /// Sorting
  /// </summary>
  public class Solution
  {
    public bool IsPossibleDivide(int[] hand, int groupSize)
    {
      if (hand.Length % groupSize > 0)
        return false;
      else if (groupSize == 1)
      {
        return true;
      }

      var map = new Dictionary<int, int>();
      foreach (var c in hand)
        map[c] = map.GetValueOrDefault(c, 0) + 1;

      while (map.Count > 0)
      {
        var c = map.Keys.Min();

        for (var i = 0; i < groupSize; i++)
        {
          if (map.ContainsKey(c + i))
          {
            var count = map[c + i];
            if (count > 1)
              map[c + i] = count - 1;
            else
            {
              map.Remove(c + i);
            }
          }
          else
          {
            return false;
          }
        }
      }

      return true;
    }
  }
}
