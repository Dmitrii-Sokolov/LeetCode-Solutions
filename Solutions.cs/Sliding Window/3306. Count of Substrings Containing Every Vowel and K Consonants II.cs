namespace Problem3306
{

  /// <summary>
  /// 3306. Count of Substrings Containing Every Vowel and K Consonants II
  /// https://leetcode.com/problems/count-of-substrings-containing-every-vowel-and-k-consonants-ii
  /// 
  /// Difficulty Medium
  /// Acceptance 30.2%
  /// 
  /// Hash Table
  /// String
  /// Sliding Window
  /// </summary>
  public class Solution
  {
    public long CountOfSubstrings(string word, int k)
    {
      Span<bool> isVowel = stackalloc bool[26];
      isVowel['e' - 'a'] = true;
      isVowel['u' - 'a'] = true;
      isVowel['i' - 'a'] = true;
      isVowel['o' - 'a'] = true;
      isVowel['a' - 'a'] = true;

      Span<int> indexes = stackalloc int[26];
      indexes['e' - 'a'] = 1;
      indexes['u' - 'a'] = 2;
      indexes['i' - 'a'] = 3;
      indexes['o' - 'a'] = 4;
      indexes['a' - 'a'] = 5;

      Span<int> lastOccurrences = [int.MaxValue, -1, -1, -1, -1, -1];

      var result = 0L;
      var min = -1;
      var consonantCount = 0;
      var from = 0;
      for (var i = 0; i < word.Length; i++)
      {
        var c = word[i] - 'a';
        if (isVowel[c])
        {
          var index = indexes[c];
          var position = i;
          if (lastOccurrences[index] == min)
          {
            lastOccurrences[index] = position;
            min = Math.Min(lastOccurrences[0],
                  Math.Min(lastOccurrences[1],
                  Math.Min(lastOccurrences[2],
                  Math.Min(lastOccurrences[3],
                  Math.Min(lastOccurrences[4],
                           lastOccurrences[5])))));
          }
          else
          {
            lastOccurrences[index] = position;
          }
        }
        else if (k == 0)
        {
          from = i + 1;
        }
        else
        {
          consonantCount++;
          while (consonantCount > k)
          {
            if (!isVowel[word[from++] - 'a'])
              consonantCount--;
          }

          var position = from;
          while (isVowel[word[position] - 'a'])
            position++;

          var index = 0;
          if (lastOccurrences[index] == min)
          {
            lastOccurrences[index] = position;
            min = Math.Min(lastOccurrences[0],
                  Math.Min(lastOccurrences[1],
                  Math.Min(lastOccurrences[2],
                  Math.Min(lastOccurrences[3],
                  Math.Min(lastOccurrences[4],
                            lastOccurrences[5])))));
          }
          else
          {
            lastOccurrences[index] = position;
          }
        }

        if (consonantCount == k && from <= min)
          result += min - from + 1;
      }

      return result;
    }
  }
}
