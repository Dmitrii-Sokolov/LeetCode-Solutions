namespace Problem624
{

  /// <summary>
  /// 624. Maximum Distance in Arrays
  /// https://leetcode.com/problems/maximum-distance-in-arrays
  /// 
  /// Difficulty Medium
  /// Acceptance 43.8 %
  /// 
  /// Array
  /// Greedy
  /// </summary>
  public class Solution
  {
    public int MaxDistance(IList<IList<int>> arrays)
    {
      var first = arrays[0];
      var second = arrays[1];
      var firstMin = first[0];
      var secondMin = second[0];
      var firstMax = first[^1];
      var secondMax = second[^1];

      var (min0, min1) = firstMin < secondMin
        ? (new KeyValuePair<int, int>(0, firstMin), secondMin)
        : (new KeyValuePair<int, int>(1, secondMin), firstMin);

      var (max0, max1) = firstMax > secondMax
        ? (new KeyValuePair<int, int>(0, firstMax), secondMax)
        : (new KeyValuePair<int, int>(1, secondMax), firstMax);

      for (var i = 2; i < arrays.Count; i++)
      {
        var min = arrays[i][0];
        if (min < min0.Value)
        {
          min1 = min0.Value;
          min0 = new KeyValuePair<int, int>(i, min);
        }
        else if (min < min1)
        {
          min1 = min;
        }

        var max = arrays[i][^1];
        if (max > max0.Value)
        {
          max1 = max0.Value;
          max0 = new KeyValuePair<int, int>(i, max);
        }
        else if (max > max1)
        {
          max1 = max;
        }
      }

      return min0.Key != max0.Key
        ? max0.Value - min0.Value
        : Math.Max(max1 - min0.Value, max0.Value - min1);
    }
  }
}
