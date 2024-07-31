namespace Problem506
{

  /// <summary>
  /// 506. Relative Ranks
  /// https://leetcode.com/problems/relative-ranks
  /// 
  /// Difficulty Easy
  /// Acceptance 71.9%
  /// 
  /// Array
  /// Sorting
  /// Heap (Priority Queue)
  /// </summary>
  public class Solution
  {
    public string[] FindRelativeRanks(int[] score)
    {
      var places = new PriorityQueue<(int Score, int Number), int>();
      var result = new string[score.Length];

      for (var i = 0; i < score.Length; i++)
        places.Enqueue((score[i], i), -score[i]);

      for (var i = 0; i < score.Length; i++)
      {
        var number = places.Dequeue().Number;
        if (i == 0)
          result[number] = "Gold Medal";
        else if (i == 1)
        {
          result[number] = "Silver Medal";
        }
        else if (i == 2)
        {
          result[number] = "Bronze Medal";
        }
        else
        {
          result[number] = (i + 1).ToString();
        }
      }

      return result;
    }
  }
}
