namespace Problem2678
{

  /// <summary>
  /// 2678. Number of Senior Citizens
  /// https://leetcode.com/problems/number-of-senior-citizens
  /// 
  /// Difficulty Easy
  /// Acceptance 80.5 %
  /// 
  /// Array
  /// String
  /// </summary>
  public class Solution
  {
    private int ThresholdAge = 60;

    public int CountSeniors(string[] details)
      => details.Count(s => int.Parse(s.Substring(11, 2)) > ThresholdAge);
    //=> details.Count(s => s[11] > '6' || (s[11] == '6' && s[12] > '0'));
  }
}
