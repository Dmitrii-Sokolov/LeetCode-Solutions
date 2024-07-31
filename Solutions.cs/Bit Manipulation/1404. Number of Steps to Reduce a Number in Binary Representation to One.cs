namespace Problem1404
{

  /// <summary>
  /// 1404. Number of Steps to Reduce a Number in Binary Representation to One
  /// https://leetcode.com/problems/number-of-steps-to-reduce-a-number-in-binary-representation-to-one
  /// 
  /// Difficulty Medium
  /// Acceptance 61.5%
  /// 
  /// String
  /// Bit Manipulation
  /// </summary>
  public class Solution
  {
    public int NumSteps(string s)
    {
      var result = 0;
      var addition = 0;

      for (var p = s.Length - 1; p > 0; p--)
      {
        var digit = s[p] - '0';
        if (digit + addition == 1)
        {
          addition = 1;
          result++;
        }

        result++;
      }

      return result + addition;
    }
  }
}
