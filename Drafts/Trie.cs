namespace Drafts
{
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
