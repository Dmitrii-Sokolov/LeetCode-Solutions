namespace Problem1140
{

  /// <summary>
  /// 1140. Stone Game II
  /// https://leetcode.com/problems/stone-game-ii
  /// 
  /// Difficulty Medium
  /// Acceptance 69.4%
  /// 
  /// Array
  /// Math
  /// Dynamic Programming
  /// Prefix Sum
  /// Game Theory
  /// </summary>
  public class Solution
  {
    public int StoneGameII(int[] piles)
      => Check([], piles, piles.Sum());

    private int Check(Dictionary<State, int> results, int[] piles, int stones, int pointer = 0, int m = 1)
    {
      if (!results.TryGetValue(new State(pointer, m), out var result))
      {
        result = 0;
        if (piles.Length - pointer <= 2 * m)
        {
          for (var i = pointer; i < piles.Length; i++)
            result += piles[i];
        }
        else
        {
          var count = 0;
          for (var i = 1; i <= 2 * m; i++)
          {
            count += piles[pointer + i - 1];
            result = Math.Max(result, stones - Check(results, piles, stones - count, pointer + i, Math.Max(i, m)));
          }
        }

        results.Add(new State(pointer, m), result);
      }

      return result;
    }

    private record struct State(int Pointer, int M) : IEquatable<State>
    {
      public override int GetHashCode() => HashCode.Combine(Pointer, M);
    }
  }
}
