/// <summary>
/// 551. Student Attendance Record I
/// https://leetcode.com/problems/student-attendance-record-i
/// 
/// Difficulty Easy
/// Acceptance 49.2%
/// 
/// String
/// </summary>
class Solution
{
  public boolean checkRecord(String s)
  {
    var countA = 0;
    var countL = 0;

    for (var i = 0; i < s.length(); i++)
    {
      var c = s.charAt(i);

      if (c == 'L')
      {
        countL++;
        if (countL == 3)
        {
          return false;
        }
      }
      else
      {
        countL = 0;
      }

      if (c == 'A')
      {
        countA++;
        if (countA == 2)
        {
          return false;
        }
      }
    }

    return true;
  }
}
