namespace Problem208
{

  /// <summary>
  /// 208. Implement Trie (Prefix Tree)
  /// https://leetcode.com/problems/implement-trie-prefix-tree
  /// 
  /// Difficulty Medium
  /// Acceptance 65.9%
  /// 
  /// Hash Table
  /// String
  /// Design
  /// Trie
  /// </summary>
  public class Trie
  {
    private TrieNode root = null;
    public class TrieNode()
    {
      //address to connections
      public TrieNode[] connections = new TrieNode[26];
      public bool IsLastLetter = false;
    }

    public Trie()
    {
      root = new TrieNode();
    }

    public void Insert(string word)
    {

      // traverse the word
      var prev = root;
      foreach (var ch in word)
      {
        TrieNode t;
        // root connection not created for the char
        if (prev.connections[ch - 'a'] == null)
        {
          // create a new TrieNode for the char
          t = new TrieNode();
          prev.connections[ch - 'a'] = t;
        }
        else
        {
          t = prev.connections[ch - 'a'];
        }

        prev = t;
      }
      prev.IsLastLetter = true;
    }

    public bool Search(string word)
    {
      var prev = root;
      for (var i = 0; i < word.Length; i++)
      {
        if (prev != null && prev.connections[word[i] - 'a'] == null)
        {
          return false;
        }
        prev = prev.connections[word[i] - 'a'];
      }
      return prev.IsLastLetter;
    }

    public bool StartsWith(string prefix)
    {
      var prev = root;
      foreach (var ch in prefix)
      {
        if (prev.connections[ch - 'a'] == null)
          return false;
        prev = prev.connections[ch - 'a'];
      }
      return true;
    }
  }
}
