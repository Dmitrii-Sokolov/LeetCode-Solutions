namespace Problem1313
{

  /// <summary>
  /// 1313. Decompress Run-Length Encoded List
  /// https://leetcode.com/problems/decompress-run-length-encoded-list
  /// 
  /// Difficulty Easy
  /// Acceptance 85.9%
  /// 
  /// Array
  /// </summary>
  public class Solution
  {
    public int[] DecompressRLElist(int[] codes)
    {
      var result = new List<int>();
      var pointer = 0;
      while (pointer < codes.Length)
      {
        var repeats = codes[pointer++];
        var number = codes[pointer++];
        while (repeats-- > 0)
          result.Add(number);
      }

      return result.ToArray();
    }
  }
}
