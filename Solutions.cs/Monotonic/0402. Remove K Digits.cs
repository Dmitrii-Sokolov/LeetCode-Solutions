namespace Problem402
{

  /// <summary>
  /// 402. Remove K Digits
  /// https://leetcode.com/problems/remove-k-digits
  /// 
  /// Difficulty Medium
  /// Acceptance 33.7%
  /// 
  /// String
  /// Stack
  /// Greedy
  /// Monotonic Stack
  /// </summary>
  public class Solution
  {
    public string RemoveKdigits(string num, int k)
    {
      var len = num.Length;
      if (k == len)
        return "0";

      var result = new LinkedList<char>();

      for (var i = 0; i < len; i++)
      {
        var digit = num[i];

        while (k > 0 && result.Count > 0 && result.Last.Value > digit)
        {
          k--;
          result.RemoveLast();
        }

        result.AddLast(digit);
      }

      while (k-- > 0)
        result.RemoveLast();

      while (result.Count > 1 && result.First.Value == '0')
        result.RemoveFirst();

      return string.Concat(result);
    }
  }
}
