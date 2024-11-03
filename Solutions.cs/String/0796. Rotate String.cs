namespace Problem796
{

  /// <summary>
  /// 796. Rotate String
  /// https://leetcode.com/problems/rotate-string
  /// 
  /// Difficulty Easy
  /// Acceptance 60.5%
  /// 
  /// String
  /// String Matching
  /// </summary>
  public class Solution
  {
    public bool RotateString(string source, string target)
    {
      if (source.Length != target.Length)
        return false;

      var counts = new int[26];
      for (var i = 0; i < target.Length; i++)
      {
        counts[source[i] - 'a']++;
        counts[target[i] - 'a']--;
      }

      if (Enumerable.Range(0, counts.Length).Any(i => counts[i] != 0))
        return false;

      for (var shift = 0; shift < target.Length; shift++)
      {
        if (Check(source, target, shift))
          return true;
      }

      return false;
    }

    private static bool Check(string source, string target, int shift)
    {
      for (var i = 0; i < target.Length; i++)
      {
        if (source[i] != target[(i + shift) % target.Length])
          return false;
      }

      return true;
    }
  }
}
