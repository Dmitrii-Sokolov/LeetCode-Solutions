namespace Problem881
{

  /// <summary>
  /// 881. Boats to Save People
  /// https://leetcode.com/problems/boats-to-save-people
  /// 
  /// Difficulty Medium
  /// Acceptance 59.5%
  /// 
  /// Array
  /// Two Pointers
  /// Greedy
  /// Sorting
  /// </summary>
  public class Solution
  {
    public int NumRescueBoats(int[] people, int limit)
    {
      var weights = new int[limit + 1];

      for (var i = 0; i < people.Length; i++)
      {
        weights[people[i]]++;
      }

      var first = 0;
      var last = weights.Length - 1;
      var result = 0;

      while (first <= last)
      {
        while (first <= last && weights[first] <= 0)
          first++;

        while (first <= last && weights[last] <= 0)
          last--;

        if (weights[first] <= 0 && weights[last] <= 0)
          break;

        if (first + last <= limit)
        {
          var count = Math.Min(weights[first], weights[last]);

          if (first == last)
            count = (count + 1) / 2;

          result += count;
          weights[first] -= count;
          weights[last] -= count;
        }
        else
        {
          result += weights[last];
          weights[last] = 0;
        }
      }

      return result;
    }
  }
}
