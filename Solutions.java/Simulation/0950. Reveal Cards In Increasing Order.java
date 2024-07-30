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
class Solution
{
  public int[] deckRevealedIncreasing(int[] deck)
  {
    var len = deck.length;

    Arrays.sort(deck);
    reverse(deck);

    var result = new LinkedList<Integer>();
    result.add(deck[0]);

    for(var i = 1; i < len; i++)
    {
      result.add(result.poll());
      result.add(deck[i]);
    }

    for(var i = 0; i < len; i++)
      deck[i] = result.get(i);
      
    reverse(deck);

    return deck;
  }

  private void reverse(int[] data)
  {
    for(int i = 0; i < data.length / 2; i++)
    {
      var temp = data[i];
      data[i] = data[data.length - i - 1];
      data[data.length - i - 1] = temp;
    }
  }
}
