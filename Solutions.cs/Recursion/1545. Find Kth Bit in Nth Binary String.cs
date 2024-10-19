namespace Problem1545
{

  /// <summary>
  /// 1545. Find Kth Bit in Nth Binary String
  /// https://leetcode.com/problems/find-kth-bit-in-nth-binary-string
  /// 
  /// Difficulty Medium
  /// Acceptance 62.2%
  /// 
  /// String
  /// Recursion
  /// Simulation
  /// </summary>
  public class Solution
  {
    public char FindKthBit(int n, int k)
    {
      n--;
      k--;

      var lengths = new int[n];
      if (n > 0)
      {
        lengths[0] = 1;
        for (var i = 1; i < n; i++)
          lengths[i] = 2 * lengths[i - 1] + 1;
      }

      return GetChar(n, k, lengths);
    }

    private static char GetChar(int depth, int position, int[] lengths)
      => depth == 0
        ? '0'
        : position < lengths[depth - 1]
          ? GetChar(depth - 1, position, lengths)
          : position == lengths[depth - 1]
            ? '1'
            : Invert(GetChar(depth - 1, 2 * lengths[depth - 1] - position, lengths));

    private static char Invert(char c) => (char)('0' + ('1' - c));
  }
}
