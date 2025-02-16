namespace Problem1718
{

  /// <summary>
  /// 1718. Construct the Lexicographically Largest Valid Sequence
  /// https://leetcode.com/problems/construct-the-lexicographically-largest-valid-sequence
  /// 
  /// Difficulty Medium
  /// Acceptance 64.5%
  /// 
  /// Array
  /// Backtracking
  /// </summary>
  public class Solution
  {
    public int[] ConstructDistancedSequence(int n)
    {
      var result = new int[2 * n - 1];
      Proceed(new bool[n + 1], result, 0);

      return result;
    }

    private static bool Proceed(bool[] usedNumbers, int[] result, int freePosition)
    {
      while (freePosition < result.Length && result[freePosition] != 0)
        freePosition++;

      if (freePosition == result.Length)
        return true;

      for (var number = usedNumbers.Length - 1; number > 0; number--)
      {
        if (!usedNumbers[number] &&
          (number == 1 ||
          freePosition + number < result.Length && result[freePosition + number] == 0))
        {
          usedNumbers[number] = true;
          result[freePosition] = number;
          if (number != 1)
            result[freePosition + number] = number;

          if (Proceed(usedNumbers, result, freePosition + 1))
            return true;

          usedNumbers[number] = false;
          result[freePosition] = 0;
          if (number != 1)
            result[freePosition + number] = 0;
        }
      }

      return false;
    }
  }
}
