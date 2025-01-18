namespace Problem649
{

  /// <summary>
  /// 649. Dota2 Senate
  /// https://leetcode.com/problems/dota2-senate
  /// 
  /// Difficulty Medium
  /// Acceptance 48.3%
  /// 
  /// String
  /// Greedy
  /// Queue
  /// </summary>
  public class Solution
  {
    private const char Radiant = 'R';
    private const char Dire = 'D';

    public string PredictPartyVictory(string senate)
    {
      var queue = new Queue<char>();
      var radiantRemain = 0;
      var direRemain = 0;
      foreach (var member in senate)
      {
        queue.Enqueue(member);
        if (member == Radiant)
        {
          radiantRemain++;
        }
        else
        {
          direRemain++;
        }
      }

      var balance = 0;
      while (radiantRemain > 0 && direRemain > 0)
      {
        if (queue.Dequeue() == Radiant)
        {
          if (balance > 0)
          {
            radiantRemain--;
          }
          else
          {
            queue.Enqueue(Radiant);
          }

          balance--;
        }
        else
        {
          if (balance < 0)
          {
            direRemain--;
          }
          else
          {
            queue.Enqueue(Dire);
          }

          balance++;
        }
      }

      return radiantRemain > 0 ? nameof(Radiant) : nameof(Dire);
    }
  }
}
