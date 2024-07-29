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
class Solution
{
  public String addBinary(String a, String b)
  {
    var result = new StringBuilder();
    var n = Math.max(a.length(), b.length());
    var sum = 0;

    for (var i = 0; i < n; i++)
    {
      if (i < a.length() && a.charAt(a.length() - 1 - i) == '1')
      {
        sum++;
      }
      if (i < b.length() && b.charAt(b.length() - 1 - i) == '1')
      {
        sum++;
      }

      var c = ((sum % 2) == 0) ? '0' : '1';
      result.append(c);
      sum /= 2;
    }

    if (sum == 1)
    {
      result.append('1');
    }

    return result.reverse().toString();
  }
}
