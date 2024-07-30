namespace Problem950
{

  /// <summary>
  /// 950. Reveal Cards In Increasing Order
  /// https://leetcode.com/problems/reveal-cards-in-increasing-order
  /// 
  /// Difficulty Medium
  /// Acceptance 83.0%
  /// 
  /// Array
  /// Queue
  /// Sorting
  /// Simulation
  /// </summary>
  public class Solution
  {
    public int[] DeckRevealedIncreasing(int[] deck)
    {
      var len = deck.Length;

      Array.Sort(deck);
      Array.Reverse(deck);

      var result = new Queue<int>(len);
      result.Enqueue(deck[0]);

      for (var i = 1; i < len; i++)
      {
        result.Enqueue(result.Dequeue());
        result.Enqueue(deck[i]);
      }

      deck = result.ToArray();
      Array.Reverse(deck);

      return deck;
    }
  }
}
