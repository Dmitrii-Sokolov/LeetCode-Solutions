namespace Problem443
{

  /// <summary>
  /// 443. String Compression
  /// https://leetcode.com/problems/string-compression
  /// 
  /// Difficulty Medium
  /// Acceptance 56.6%
  /// 
  /// Two Pointers
  /// String
  /// </summary>
  public class Solution
  {
    public int Compress(char[] chars)
    {
      var repeats = 1;
      var pointer = 0;
      for (var i = 1; i < chars.Length; i++)
      {
        if (chars[i - 1] == chars[i])
        {
          repeats++;
        }
        else
        {
          chars[pointer++] = chars[i - 1];
          if (repeats != 1)
          {
            foreach (var digit in repeats.ToString())
              chars[pointer++] = digit;
          }

          repeats = 1;
        }
      }

      chars[pointer++] = chars[^1];
      if (repeats != 1)
      {
        foreach (var digit in repeats.ToString())
          chars[pointer++] = digit;
      }

      return pointer;
    }
  }
}
