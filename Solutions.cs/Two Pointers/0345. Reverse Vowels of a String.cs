namespace Problem345
{

  /// <summary>
  /// 345. Reverse Vowels of a String
  /// https://leetcode.com/problems/reverse-vowels-of-a-string/description/?envType=study-plan-v2&envId=leetcode-75
  /// 
  /// Difficulty Easy
  /// Acceptance 56.0%
  /// 
  /// Two Pointers
  /// String
  /// </summary>
  public class Solution
  {
    public string ReverseVowels(string s)
    {
      var result = s.ToArray();
      var left = -1;
      var right = s.Length;
      while (left < right)
      {
        left++;
        while (left < right && !IsVowel(s[left]))
          left++;

        right--;
        while (left < right && !IsVowel(s[right]))
          right--;

        if (left >= right)
          break;

        (result[left], result[right]) = (result[right], result[left]);
      }

      return string.Concat(result);
    }

    private static bool IsVowel(char symbol)
      => symbol is 'e' or 'u' or 'i' or 'o' or 'a' or 'E' or 'U' or 'I' or 'O' or 'A';
  }
}
