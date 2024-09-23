namespace Problem2707
{

  /// <summary>
  /// 2707. Extra Characters in a String
  /// https://leetcode.com/problems/extra-characters-in-a-string
  /// 
  /// Difficulty Medium
  /// Acceptance 54.1%
  /// 
  /// Array
  /// Hash Table
  /// String
  /// Dynamic Programming
  /// Trie
  /// </summary>
  public class Solution
  {
    public int MinExtraChar(string s, string[] words)
      => GetResult(
        0,
        s,
        Enumerable
          .Range(0, s.Length)
          .Select(_ => -1).ToArray(),
        new Trie(words));

    private int GetResult(int from, string s, int[] memory, Trie dictionary)
    {
      if (from == s.Length)
        return 0;

      if (memory[from] > 0)
        return memory[from];

      var result = GetResult(from + 1, s, memory, dictionary) + 1;
      foreach (var shift in dictionary.GetAllWordLengths(s, from).Reverse())
      {
        if (from + shift > s.Length)
          break;

        var anotherResult = GetResult(from + shift, s, memory, dictionary);
        if (anotherResult < result)
          result = anotherResult;

        if (result == 0)
          break;
      }

      memory[from] = result;
      return result;
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
        }

        node.Finish = true;
      }

      public IEnumerable<int> GetAllWordLengths(string sentence, int from = 0)
      {
        var node = Root;
        var depth = 0;
        for (var i = from; i < sentence.Length; i++)
        {
          var letter = sentence[i];
          var c = letter - 'a';
          if (node.Nodes == null || node.Nodes[c] == null)
            break;

          node = node.Nodes[c];
          depth++;

          if (node.Finish)
            yield return depth;
        }
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
}
