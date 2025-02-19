namespace Problem1415
{

  /// <summary>
  /// 1415. The k-th Lexicographical String of All Happy Strings of Length n
  /// https://leetcode.com/problems/the-k-th-lexicographical-string-of-all-happy-strings-of-length-n
  /// 
  /// Difficulty Medium
  /// Acceptance 81.3%
  /// 
  /// String
  /// Backtracking
  /// </summary>
  public class Solution
  {
    public string GetHappyString(int n, int k)
    {
      var suffixesCount = 1 << n - 1;
      if (k > 3 * suffixesCount)
        return string.Empty;

      k--;
      var result = new char[n];
      result[0] = (char)(k / suffixesCount + 'a');

      for (var position = 1; position < n; position++)
      {
        k %= 1 << n - position;
        result[position] = k / (1 << n - 1 - position) == 0
          ? result[position - 1] == 'a' ? 'b' : 'a'
          : result[position - 1] == 'c' ? 'b' : 'c';
      }

      return new string(result);
    }

    //public string GetHappyString(int n, int k)
    //{
    //  var result = new char[n];

    //  return Proceed(result, ref k, '0', 0) ? new string(result) : string.Empty;
    //}

    //private static bool Proceed(char[] result, ref int k, int previous, int position)
    //{
    //  if (position == result.Length)
    //  {
    //    k--;
    //    return k == 0;
    //  }

    //  for (var i = 0; i < 3; i++)
    //  {
    //    if (i == previous)
    //      continue;

    //    result[position] = (char)('a' + i);
    //    if (Proceed(result, ref k, i, position + 1))
    //      return true;
    //  }

    //  return false;
    //}
  }
}
