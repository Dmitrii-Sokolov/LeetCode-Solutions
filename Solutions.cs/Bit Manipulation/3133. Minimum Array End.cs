namespace Problem3133
{

  /// <summary>
  /// 3133. Minimum Array End
  /// https://leetcode.com/problems/minimum-array-end
  /// 
  /// Difficulty Medium
  /// Acceptance 48.2%
  /// 
  /// Bit Manipulation
  /// </summary>
  public class Solution
  {
    public long MinEnd(int n, int x)
    {
      n--;
      var bitN = 0;
      var bitX = 0;
      long result = x;
      while (n > 0 || x > 0)
      {
        var maskX = 1L << bitX;
        if ((x & maskX) == 0)
        {
          var maskN = 1 << bitN;
          if ((n & maskN) > 0)
          {
            result |= maskX;
            n ^= maskN;
          }

          bitN++;
        }
        else if (x > 0)
        {
          x ^= (int)maskX;
        }

        bitX++;
      }

      return result;
    }
  }
}
