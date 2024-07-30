namespace Problem657
{

  /// <summary>
  /// 657. Robot Return to Origin
  /// https://leetcode.com/problems/robot-return-to-origin
  /// 
  /// Difficulty Easy
  /// Acceptance 75.9%
  /// 
  /// String
  /// Simulation
  /// </summary>
  public class Solution
  {
    public bool JudgeCircle(string moves)
    {
      var x = 0;
      var y = 0;

      for (var i = 0; i < moves.Length; i++)
      {
        switch (moves[i])
        {
          case 'U':
            y++;
            break;

          case 'D':
            y--;
            break;

          case 'R':
            x++;
            break;

          case 'L':
            x--;
            break;
        }
      }

      return x == 0 && y == 0;
    }
  }
}
