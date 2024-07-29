/// <summary>
/// 1002. Find Common Characters
/// https://leetcode.com/problems/find-common-characters
/// 
/// Difficulty Easy
/// Acceptance 74.6%
/// 
/// Array
/// Hash Table
/// String
/// </summary>
class Solution
{
  public List<String> commonChars(String[] words)
  {
    var letters = new int[26];
    for (var i = 0; i < words[0].length(); i++)
    {
      letters[words[0].charAt(i) - 'a']++;
    }

    for (var w : words)
    {
      var temp = new int[26];
      for (var i = 0; i < w.length(); i++)
      {
        temp[w.charAt(i) - 'a']++;
      }

      for (var i = 0; i < 26; i++)
      {
        letters[i] = Math.min(letters[i], temp[i]);
      }
    }

    var result = new ArrayList<String>();
    for (var i = 0; i < 26; i++)
    {
      while (letters[i]-- > 0)
      {
        result.add(Character.toString((char)(i + 'a')));
      }
    }
    return result;
  }
}
