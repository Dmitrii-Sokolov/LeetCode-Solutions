namespace Problem877
{

  /// <summary>
  /// 877. Stone Game
  /// https://leetcode.com/problems/stone-game
  /// 
  /// Difficulty Medium
  /// Acceptance 70.8%
  /// 
  /// Array
  /// Math
  /// Dynamic Programming
  /// Game Theory
  /// </summary>
  public class Solution
  {
    private int[,] Results;

    public bool StoneGame(int[] piles) => true;

    public bool StoneGameCorrect(int[] piles)
    {
      Results = new int[piles.Length, piles.Length];
      for (var i = 0; i < piles.Length; i++)
        Results[i, i] = piles[i];

      var sum = piles.Sum();
      var aliceScore = Check(piles, 0, piles.Length - 1, sum);

      return aliceScore > sum >> 1;
    }

    private int Check(int[] piles, int left, int right, int stones)
    {
      if (Results[left, right] == 0)
      {
        Results[left, right] = Math.Max(
          stones - Check(piles, left + 1, right, stones - piles[left]),
          stones - Check(piles, left, right - 1, stones - piles[right]));
      }

      return Results[left, right];
    }
  }
}
