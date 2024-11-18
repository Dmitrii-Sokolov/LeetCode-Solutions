namespace Problem1652
{

  /// <summary>
  /// 1652. Defuse the Bomb
  /// https://leetcode.com/problems/defuse-the-bomb
  /// 
  /// Difficulty Easy
  /// Acceptance 72.7%
  /// 
  /// Array
  /// Sliding Window
  /// </summary>
  public class Solution
  {
    public int[] Decrypt(int[] code, int k)
    {
      var n = code.Length;
      var result = new int[n];
      if (k == 0)
        return result;

      var from = k > 0 ? 1 : n + k;
      var to = k > 0 ? k : n - 1;
      var sum = 0;
      for (var i = from; i <= to; i++)
        sum += code[i];

      for (var i = 0; i < n; i++)
      {
        result[i] = sum;
        sum -= code[from];
        from = (from + 1) % n;
        to = (to + 1) % n;
        sum += code[to];
      }

      return result;
    }
  }
}
