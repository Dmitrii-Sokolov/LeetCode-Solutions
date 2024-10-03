namespace Problem1590
{

  /// <summary>
  /// 1590. Make Sum Divisible by P
  /// https://leetcode.com/problems/make-sum-divisible-by-p
  /// 
  /// Difficulty Medium
  /// Acceptance 36.3%
  /// 
  /// Array
  /// Hash Table
  /// Prefix Sum
  /// </summary>
  public class Solution
  {
    public int MinSubarray(int[] numbers, int p)
    {
      numbers[0] %= p;
      for (var i = 1; i < numbers.Length; i++)
        numbers[i] = (numbers[i] + numbers[i - 1]) % p;

      var fullSum = numbers[^1];
      if (fullSum == 0)
        return 0;

      var minSubarray = numbers.Length;
      var lastPrefixIndex = new Dictionary<int, int>
      {
        [fullSum] = -1
      };

      for (var i = 0; i < numbers.Length; i++)
      {
        if (lastPrefixIndex.TryGetValue(numbers[i], out var index))
        {
          var length = i - index;
          if (length < minSubarray)
            minSubarray = length;

          if (length == 1)
            return 1;
        }

        lastPrefixIndex[(fullSum + numbers[i]) % p] = i;
      }

      return minSubarray == numbers.Length ? -1 : minSubarray;
    }

    private static int Mod(int x, int m) => (x % m + m) % m;
  }
}
