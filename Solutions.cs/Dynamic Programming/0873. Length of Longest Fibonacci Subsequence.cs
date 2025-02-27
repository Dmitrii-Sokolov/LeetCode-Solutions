namespace Problem873
{

  /// <summary>
  /// 873. Length of Longest Fibonacci Subsequence
  /// https://leetcode.com/problems/length-of-longest-fibonacci-subsequence
  /// 
  /// Difficulty Medium
  /// Acceptance 50.9%
  /// 
  /// Array
  /// Hash Table
  /// Dynamic Programming
  /// </summary>
  public class Solution
  {
    public int LenLongestFibSubseq(int[] array)
    {
      var result = 0;
      var numbers = new Dictionary<int, int>(array.Length);
      foreach (var item in array)
        numbers[item] = item;

      var tails = new Dictionary<(int, int), int>();
      for (var i = 0; i < array.Length; i++)
      {
        for (var j = i + 1; j < array.Length; j++)
        {
          var number0 = array[i];
          var number1 = array[j];
          var previous = number1 - number0;
          if (previous < number0 && numbers.ContainsKey(previous))
          {
            var tail = tails.GetValueOrDefault((previous, number0), 2) + 1;
            tails[(number0, number1)] = tail;

            if (result < tail)
              result = tail;
          }
        }
      }

      return result;
    }
  }
}
