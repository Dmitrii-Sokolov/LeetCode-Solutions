namespace Problem916
{

  /// <summary>
  /// 916. Word Subsets
  /// https://leetcode.com/problems/word-subsets
  /// 
  /// Difficulty Medium
  /// Acceptance 52.6%
  /// 
  /// Array
  /// Hash Table
  /// String
  /// </summary>
  public class Solution
  {
    public IList<string> WordSubsets(string[] words1, string[] words2)
    {
      var counts = new int[26];
      var total = 0;
      foreach (var word in words2)
      {
        var wordCounts = new int[26];
        foreach (var c in word)
        {
          var index = c - 'a';
          wordCounts[index]++;

          if (counts[index] < wordCounts[index])
          {
            total++;
            counts[index]++;
          }
        }
      }

      var result = new List<string>();
      foreach (var word in words1)
      {
        if (word.Length < total)
          continue;

        var wordCounts = new int[26];
        foreach (var c in word)
          wordCounts[c - 'a']++;

        if (Check(counts, wordCounts))
          result.Add(word);
      }

      return result;
    }

    private static bool Check(int[] counts, int[] wordCounts)
    {
      for (var i = 0; i < 26; i++)
      {
        if (counts[i] > wordCounts[i])
          return false;
      }

      return true;
    }
  }
}
