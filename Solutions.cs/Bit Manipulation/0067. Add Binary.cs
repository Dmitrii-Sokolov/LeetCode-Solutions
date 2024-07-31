namespace Problem67
{

  /// <summary>
  /// 67. Add Binary
  /// https://leetcode.com/problems/add-binary
  /// 
  /// Difficulty Easy
  /// Acceptance 54.0%
  /// 
  /// Math
  /// String
  /// Bit Manipulation
  /// Simulation
  /// </summary>
  public class Solution
  {
    public string AddBinary(string a, string b)
    {
      var result = new List<char>();
      var n = Math.Max(a.Length, b.Length);
      var sum = 0;

      for (var i = 0; i < n; i++)
      {
        if (i < a.Length && a[a.Length - 1 - i] == '1')
          sum++;

        if (i < b.Length && b[b.Length - 1 - i] == '1')
          sum++;

        var c = sum % 2 == 0 ? '0' : '1';
        result.Add(c);
        sum /= 2;
      }

      if (sum == 1)
        result.Add('1');

      return result.Reverse<char>().Aggregate(new System.Text.StringBuilder(), (sb, c) => sb.Append(c), sb => sb.ToString());
    }
  }
}
