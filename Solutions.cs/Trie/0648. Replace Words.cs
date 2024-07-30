namespace Problem648
{

  /// <summary>
  /// 648. Replace Words
  /// https://leetcode.com/problems/replace-words
  /// 
  /// Difficulty Medium
  /// Acceptance 68.1%
  /// 
  /// Array
  /// Hash Table
  /// String
  /// Trie
  /// </summary>
  public class Solution
  {
    public string ReplaceWords(IList<string> dictionary, string sentence)
    {
      var words = sentence.Split(' ');
      var result = new System.Text.StringBuilder();
      var isFirst = true;
      var trie = new Trie();

      foreach (var prefix in dictionary)
        trie.Insert(prefix);

      foreach (var word in words)
      {
        if (!isFirst)
          result.Append(' ');


        if (trie.TryFindPrefix(word, out var count))
          result.Append(word, 0, count);
        else
          result.Append(word);

        isFirst = false;
      }

      return result.ToString();
    }
  }


  public class Trie
  {
    private class Node
    {
      public Node[] Nodes { get; set; }
      public bool Finish { get; set; }
    }

    private Node Root { get; }

    public Trie()
    {
      Root = new Node();
    }

    public void Insert(string word)
    {
      var node = Root;

      foreach (var letter in word)
      {
        var c = letter - 'a';

        if (node.Nodes == null)
          node.Nodes = new Node[26];

        if (node.Nodes[c] == null)
          node.Nodes[c] = new Node();

        node = node.Nodes[c];
      }

      node.Finish = true;
    }

    public bool Search(string word)
      => TryGetNode(word, out var node) && node.Finish;

    public bool StartsWith(string prefix)
      => TryGetNode(prefix, out var _);

    public bool TryFindPrefix(string word, out int count)
    {
      var node = Root;
      count = 0;
      foreach (var letter in word)
      {
        if (node.Finish)
          return true;

        var c = letter - 'a';
        if (node.Nodes == null || node.Nodes[c] == null)
          return false;

        node = node.Nodes[c];
        count++;
      }

      return false;
    }

    private bool TryGetNode(string word, out Node node)
    {
      node = Root;
      foreach (var letter in word)
      {
        var c = letter - 'a';

        if (node.Nodes == null || node.Nodes[c] == null)
          return false;

        node = node.Nodes[c];
      }
      return true;
    }
  }
}
