namespace Problem1823
{

  /// <summary>
  /// 1823. Find the Winner of the Circular Game
  /// https://leetcode.com/problems/find-the-winner-of-the-circular-game
  /// 
  /// Difficulty Medium
  /// Acceptance 81.7%
  /// 
  /// Array
  /// Math
  /// Recursion
  /// Queue
  /// Simulation
  /// </summary>
  public class Solution
  {
    public int FindTheWinner(int n, int k)
    {
      k--;

      var x = 0;

      var a = new List<int>();

      for (var i = 1; i <= n; i++)
      {
        a.Add(i);
      }

      A(a, k, x);

      return a.FirstOrDefault();
    }

    private void A(List<int> arr, int k, int x)
    {
      if (arr.Count == 1)
      {
        return;
      }

      x = (x + k) % arr.Count;

      arr.RemoveAt(x);

      A(arr, k, x);
    }
  }
}
