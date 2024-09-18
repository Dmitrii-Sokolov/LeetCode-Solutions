namespace Problem179
{

  /// <summary>
  /// 179. Largest Number
  /// https://leetcode.com/problems/largest-number
  /// 
  /// Difficulty Medium
  /// Acceptance 37.5%
  /// 
  /// Array
  /// String
  /// Greedy
  /// Sorting
  /// </summary>
  public class Solution
  {
    public string LargestNumber(int[] numbers)
    {
      if (numbers.All(number => number == 0))
        return "0";

      Array.Sort(numbers, Compare);
      return numbers.
        Aggregate(
          new System.Text.StringBuilder(),
          (sb, a) => sb.Append(a),
          sb => sb.ToString());
    }

    private int Compare(int b, int a)
    {
      return a == b
        ? 0
        : long.Parse($"{a}{b}").CompareTo(long.Parse($"{b}{a}"));
    }
  }
}
