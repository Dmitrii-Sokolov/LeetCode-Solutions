namespace Problem2416
{

  /// <summary>
  /// 2416. Sum of Prefix Scores of Strings
  /// https://leetcode.com/problems/sum-of-prefix-scores-of-strings
  /// 
  /// Difficulty Hard
  /// Acceptance 53.3%
  /// 
  /// Array
  /// String
  /// Trie
  /// Counting
  /// </summary>
  public class Solution
  {
    public int[] SumPrefixScores(string[] words)
    {
      var trie = new Trie(words);
      return words.Select(word => trie.CountAllPrefixes(word).Sum()).ToArray();
    }

    public class Trie
    {
      private class Node
      {
        public Node[] Nodes { get; set; }
        public int Count { get; set; }
      }

      private Node Root { get; }

      public Trie()
      {
        Root = new Node();
      }

      public Trie(string[] words) : this()
      {
        foreach (var word in words)
          Insert(word);
      }

      public void Insert(string word)
      {
        var node = Root;

        foreach (var letter in word)
        {
          var c = letter - 'a';
          node.Nodes ??= new Node[26];
          node.Nodes[c] ??= new Node();
          node = node.Nodes[c];
          node.Count++;
        }
      }

      public IEnumerable<int> CountAllPrefixes(string word)
      {
        var node = Root;
        for (var i = 0; i < word.Length; i++)
        {
          var letter = word[i];
          var c = letter - 'a';
          if (node.Nodes == null || node.Nodes[c] == null)
            break;

          node = node.Nodes[c];
          yield return node.Count;
        }
      }

      public bool StartsWith(string prefix)
        => TryGetNode(prefix, out var _);

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
}
