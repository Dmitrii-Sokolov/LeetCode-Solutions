namespace Problem682
{

  /// <summary>
  /// 682. Baseball Game
  /// https://leetcode.com/problems/baseball-game
  /// 
  /// Difficulty Easy
  /// Acceptance 76.9%
  /// 
  /// Array
  /// Stack
  /// Simulation
  /// </summary>
  public class Solution
  {
    public int CalPoints(string[] operations)
    {
      var scores = new int[operations.Length];
      var i = 0;

      foreach (var op in operations)
      {
        switch (op)
        {
          case "+":
            scores[i] = scores[i - 1] + scores[i - 2];
            i++;
            break;
          case "D":
            scores[i] = 2 * scores[i - 1];
            i++;
            break;
          case "C":
            i--;
            scores[i] = 0;
            break;
          default:
            scores[i] = int.Parse(op);
            i++;
            break;
        }
      }

      var result = 0;
      foreach (var s in scores)
      {
        result += s;
      }

      return result;
    }
  }
}
