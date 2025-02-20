namespace Problem1980
{

  /// <summary>
  /// 1980. Find Unique Binary String
  /// https://leetcode.com/problems/find-unique-binary-string
  /// 
  /// Difficulty Medium
  /// Acceptance 77.1%
  /// 
  /// Array
  /// Hash Table
  /// String
  /// Backtracking
  /// </summary>
  public class Solution
  {
    public string FindDifferentBinaryString(string[] numbers)
    {
      var n = numbers.Length;
      var result = new char[n];
      var filter = new bool[n];
      for (var i = 0; i < n; i++)
      {
        var digits = new int[2];
        for (var j = 0; j < n; j++)
        {
          if (!filter[j])
            digits[numbers[j][i] - '0']++;
        }

        result[i] = digits[0] > digits[1] ? '1' : '0';

        for (var j = 0; j < n; j++)
          filter[j] |= numbers[j][i] != result[i];
      }

      return new string(result);
    }
  }
}
