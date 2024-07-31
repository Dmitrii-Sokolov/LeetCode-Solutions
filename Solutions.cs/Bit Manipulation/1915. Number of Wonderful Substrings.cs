namespace Problem1915
{

  /// <summary>
  /// 1915. Number of Wonderful Substrings
  /// https://leetcode.com/problems/number-of-wonderful-substrings
  /// 
  /// Difficulty Medium
  /// Acceptance 67.0%
  /// 
  /// Hash Table
  /// String
  /// Bit Manipulation
  /// Prefix Sum
  /// </summary>
  public class Solution
  {
    public long WonderfulSubstrings(string word)
    {
      var bitsDictionary = new int[1 << 10];
      long result = 0;
      var current = 0;

      for (var i = 0; i < word.Length; i++)
      {
        bitsDictionary[current]++;

        var w = word[i];
        current ^= 1 << (w - 'a');

        result += bitsDictionary[current];
        for (var k = 0; k < 10; k++)
        {
          result += bitsDictionary[current ^ (1 << k)];
        }
      }

      return result;
    }
  }
}
