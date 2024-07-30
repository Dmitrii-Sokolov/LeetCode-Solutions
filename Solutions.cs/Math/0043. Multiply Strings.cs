namespace Problem43
{

  /// <summary>
  /// 43. Multiply Strings
  /// https://leetcode.com/problems/multiply-strings
  /// 
  /// Difficulty Medium
  /// Acceptance 40.7%
  /// 
  /// Math
  /// String
  /// Simulation
  /// </summary>
  public class Solution
  {
    public string Multiply(string num1, string num2)
    {
      if (num1.Equals("0") || num2.Equals("0"))
        return "0";

      var result = new int[num1.Length + num2.Length];
      for (var i1 = 0; i1 < num1.Length; i1++)
      {
        for (var i2 = 0; i2 < num2.Length; i2++)
        {
          var shift = i1 + i2;

          result[i1 + i2] += (num1[num1.Length - i1 - 1] - '0') * (num2[num2.Length - i2 - 1] - '0');
        }
      }

      for (var i = 0; i < result.Length - 1; i++)
      {
        result[i + 1] += result[i] / 10;
        result[i] %= 10;
      }

      var end = result.Length - 1;
      while (end >= 1 && result[end] == 0)
      {
        end--;
      }

      var sb = new System.Text.StringBuilder();
      for (; end >= 0; end--)
      {
        sb.Append(result[end]);
      }

      return sb.ToString();
    }
  }
}
