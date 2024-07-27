namespace Drafts
{
  public class BinaryTree
  {
    private class Node
    {
      private Node Left { get; set; } = null;
      private Node Right { get; set; } = null;
      private string Value { get; }

      private int CountLeft => Left?.Count ?? 0;
      private int CountRight => Right?.Count ?? 0;
      private int Count => CountLeft + CountRight + 1;

      public Node(string value) => Value = value;

      public void Insert(string word)
      {
        var c = Value.CompareTo(word);
        if (c < 0)
        {
          if (Left == null)
            Left = new Node(word);
          else
            Left.Insert(word);
        }
        else if (c > 0)
        {
          if (Right == null)
            Right = new Node(word);
          else
            Right.Insert(word);
        }

        if (Math.Abs(CountRight - CountLeft) > 1)
        {
          //Rebalance
        }
      }

      public bool Search(string word)
      {
        var c = Value.CompareTo(word);
        return c > 0
          ? Right?.Search(word) ?? false
          : c == 0 || (Left?.Search(word) ?? false);
      }

      public bool StartsWith(string prefix)
      {
        var length = Math.Min(prefix.Length, Value.Length);

        for (var i = 0; i < length; i++)
        {
          var c = Value[i].CompareTo(prefix[i]);

          if (c > 0)
            return Right?.StartsWith(prefix) ?? false;
          else if (c < 0)
          {
            return Left?.StartsWith(prefix) ?? false;
          }
        }

        return Value.StartsWith(prefix);
      }
    }

    private Node Root { get; set; } = null;

    public void Insert(string word)
    {
      if (Root == null)
        Root = new Node(word);
      else
      {
        Root.Insert(word);
      }
    }

    public bool Search(string word)
      => Root != null && Root.Search(word);

    public bool StartsWith(string prefix)
      => Root != null && Root.StartsWith(prefix);
  }
}
