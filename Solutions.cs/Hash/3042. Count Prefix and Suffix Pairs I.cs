namespace Problem3042
{

  /// <summary>
  /// 3042. Count Prefix and Suffix Pairs I
  /// https://leetcode.com/problems/count-prefix-and-suffix-pairs-i
  /// 
  /// Difficulty Easy
  /// Acceptance 72.5%
  /// 
  /// Array
  /// String
  /// Trie
  /// Rolling Hash
  /// String Matching
  /// Hash Function
  /// </summary>
  public class Solution
  {
    public int CountPrefixSuffixPairs(string[] words)
    {
      var hashesForward = new int[words.Length][];
      var hashesBackward = new int[words.Length][];
      for (var i = 0; i < words.Length; i++)
      {
        hashesForward[i] = new int[words[i].Length + 1];
        hashesBackward[i] = new int[words[i].Length + 1];
        for (var j = 0; j < words[i].Length; j++)
        {
          hashesForward[i][j + 1] = hashesForward[i][j] * 7 + words[i][j];
          hashesBackward[i][j + 1] = hashesBackward[i][j] * 7 + words[i][^(1 + j)];
        }
      }

      var result = 0;
      for (var i = 0; i < words.Length; i++)
      {
        for (var j = i + 1; j < words.Length; j++)
        {
          if (words[j].Length >= words[i].Length &&
            hashesForward[j][words[i].Length] == hashesForward[i][words[i].Length] &&
            hashesBackward[j][words[i].Length] == hashesBackward[i][words[i].Length])
            result++;
        }
      }

      return result;
    }
  }
}
