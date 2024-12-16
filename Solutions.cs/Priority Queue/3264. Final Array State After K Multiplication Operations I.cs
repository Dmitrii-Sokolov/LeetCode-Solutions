namespace Problem3264
{

  /// <summary>
  /// 3264. Final Array State After K Multiplication Operations I
  /// https://leetcode.com/problems/final-array-state-after-k-multiplication-operations-i
  /// 
  /// Difficulty Easy
  /// Acceptance 85.0%
  /// 
  /// Array
  /// Math
  /// Heap(Priority Queue)
  /// Simulation
  /// </summary>
  public class Solution
  {
    public int[] GetFinalState(int[] numbers, int k, int multiplier)
    {
      while (k-- > 0)
      {
        var minIndex = 0;
        for (var j = 0; j < numbers.Length; j++)
        {
          if (numbers[minIndex] > numbers[j])
            minIndex = j;
        }

        numbers[minIndex] *= multiplier;
      }

      return numbers;
    }
  }
}
