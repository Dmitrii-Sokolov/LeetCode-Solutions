namespace Problem214
{

  /// <summary>
  /// 214. Shortest Palindrome
  /// https://leetcode.com/problems/shortest-palindrome
  /// 
  /// Difficulty Hard
  /// Acceptance 35.0%
  /// 
  /// String
  /// Rolling Hash
  /// String Matching
  /// Hash Function
  /// </summary>
  public class Solution
  {
    private const long B = 29;
    private const long Modulo = 1000000009;

    public string ShortestPalindrome(string s)
    {
      var forwardHash = GetHash(s, true);
      var backwardHash = GetHash(s, false);
      var currentBase = 1L;
      var maxBase = 1L;
      for (var i = 0; i < s.Length - 1; i++)
        maxBase = Mod(maxBase * B);

      for (var i = 0; i < s.Length; i++)
      {
        if (forwardHash == backwardHash && IsSubPalindrome(s, s.Length - i))
        {
          var result = new System.Text.StringBuilder();
          for (var j = s.Length - 1; j >= s.Length - i; j--)
            result.Append(s[j]);

          result.Append(s);
          return result.ToString();
        }

        var charToRemove = s[s.Length - 1 - i];

        forwardHash = Mod(forwardHash - CharToDigit(charToRemove) * currentBase);
        backwardHash = Mod(B * (backwardHash - CharToDigit(charToRemove) * maxBase));
        currentBase = Mod(currentBase * B);
      }

      return "";
    }

    private static long GetHash(string s, bool forward)
    {
      var hash = 0L;
      if (forward)
      {
        for (var i = 0; i < s.Length; i++)
          hash = AddCharToHash(s[i], hash);
      }
      else
      {
        for (var i = s.Length - 1; i >= 0; i--)
          hash = AddCharToHash(s[i], hash);
      }

      return hash;
    }

    private static bool IsSubPalindrome(string s, int shift)
      => Enumerable.Range(0, shift / 2).All(i => s[i] == s[shift - 1 - i]);

    private static long AddCharToHash(char c, long hash) => (hash * B + CharToDigit(c)) % Modulo;
    private static int CharToDigit(char charToRemove) => charToRemove - 'a' + 1;

    private static long Mod(long x) => Mod(x, Modulo);
    private static long Mod(long x, long m) => (x % m + m) % m;
  }
}
