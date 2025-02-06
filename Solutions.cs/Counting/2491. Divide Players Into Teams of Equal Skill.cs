namespace Problem2491
{

  /// <summary>
  /// 2491. Divide Players Into Teams of Equal Skill
  /// https://leetcode.com/problems/divide-players-into-teams-of-equal-skill
  /// 
  /// Difficulty Medium
  /// Acceptance 66.4 %
  /// 
  /// Array
  /// Hash Table
  /// Two Pointers
  /// Sorting
  /// </summary>
  public class Solution
  {
    public long DividePlayers(int[] skills)
    {
      var skillCounts = new int[1001];
      var sum = 0;
      var teamsCount = skills.Length / 2;
      foreach (var skill in skills)
      {
        skillCounts[skill]++;
        sum += skill;
      }

      if (sum % teamsCount != 0)
        return -1;

      var counted = skills.Length;
      var targetSkillSum = sum / teamsCount;
      var result = 0L;

      if (targetSkillSum % 2 == 0)
      {
        var half = targetSkillSum / 2;
        var count = skillCounts[half];
        if (count % 2 == 0)
        {
          result += (long)half * half * count / 2;
          counted -= count;
        }
        else
        {
          return -1;
        }
      }

      for (var skill = 1; skill < (targetSkillSum + 1) / 2; skill++)
      {
        if (skillCounts[skill] == 0)
          continue;

        var counterSkill = targetSkillSum - skill;
        if (skillCounts[skill] != skillCounts[counterSkill])
          return -1;

        result += (long)skill * counterSkill * skillCounts[skill];
        counted -= 2 * skillCounts[skill];

        skillCounts[skill] = 0;
        skillCounts[counterSkill] = 0;
      }

      return counted != 0 ? -1 : result;
    }
  }
}
