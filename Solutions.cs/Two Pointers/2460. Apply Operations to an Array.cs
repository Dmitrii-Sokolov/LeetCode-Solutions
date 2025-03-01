namespace Problem2460
{

  /// <summary>
  /// 2460. Apply Operations to an Array
  /// https://leetcode.com/problems/apply-operations-to-an-array
  /// 
  /// Difficulty Easy
  /// Acceptance 71.6%
  /// 
  /// Array
  /// Two Pointers
  /// Simulation
  /// </summary>
  public class Solution
  {
    public int[] ApplyOperations(int[] numbers)
    {
      var writePosition = 0;
      for (var i = 0; i < numbers.Length - 1; i++)
      {
        if (numbers[i] > 0)
        {
          if (numbers[i] == numbers[i + 1])
          {
            numbers[writePosition++] = 2 * numbers[i];
            numbers[i + 1] = 0;
          }
          else
          {
            numbers[writePosition++] = numbers[i];
          }
        }
      }

      numbers[writePosition++] = numbers[^1];
      while (writePosition < numbers.Length)
        numbers[writePosition++] = 0;

      return numbers;
    }
  }
}
