/// <summary>
/// 140. Word Break II
/// https://leetcode.com/problems/word-break-ii
/// 
/// Difficulty Hard
/// Acceptance 51.3%
/// 
/// Array
/// Hash Table
/// String
/// Dynamic Programming
/// Backtracking
/// Trie
/// Memoization
/// </summary>
class Solution
{
  public List<String> wordBreak(String s, List<String> wordDict)
  {
    string = s;
    dictionary = wordDict;

    check(0);
    return result;
  }

  private String string;
  private List<String> dictionary;

  private ArrayList<String> result = new ArrayList<String>();
  private Stack<String> words = new Stack<String>();

  private void check(int p)
  {
    if (p == string.length())
    {
      var sb = new StringBuilder();

      for (var i = 0; i < words.size() - 1; i++)
      {
        sb.append(words.get(i));
        sb.append(' ');
      }
      sb.append(words.get(words.size() - 1));

      result.add(sb.toString());
      return;
    }

    for (var word : dictionary)
    {
      if (correct(p, word))
      {
        words.push(word);
        check(p + word.length());
        words.pop();
      }
    }
  }

  private boolean correct(int p, String word)
  {
    if (string.length() - p < word.length())
    {
      return false;
    }

    for (var i = 0; i < word.length(); i++)
    {
      if (word.charAt(i) != string.charAt(p + i))
      {
        return false;
      }
    }

    return true;
  }
}
