namespace Problem567
{

  /// <summary>
  /// 567. Permutation in String
  /// https://leetcode.com/problems/permutation-in-string
  /// 
  /// Difficulty Medium
  /// Acceptance 45.1%
  /// 
  /// Hash Table
  /// Two Pointers
  /// String
  /// Sliding Window
  /// </summary>
  public class Solution
  {
    public bool CheckInclusion(string permutable, string sentence)
    {
      if (sentence.Length < permutable.Length)
        return false;

      var letters = new int[26];
      for (var i = 0; i < permutable.Length; i++)
      {
        var cp = permutable[i] - 'a';
        letters[cp]--;

        var cs = sentence[i] - 'a';
        letters[cs]++;
      }

      var difference = letters.Sum(Math.Abs);
      for (var i = permutable.Length; i < sentence.Length; i++)
      {
        if (difference == 0)
          return true;

        var cl = sentence[i - permutable.Length] - 'a';
        var cr = sentence[i] - 'a';

        difference -= Math.Abs(letters[cl]);
        difference -= Math.Abs(letters[cr]);

        letters[cl]--;
        letters[cr]++;

        difference += Math.Abs(letters[cl]);
        difference += Math.Abs(letters[cr]);
      }

      return difference == 0;
    }
  }
}
