namespace Problem2096
{

  /// <summary>
  /// 2096. Step-By-Step Directions From a Binary Tree Node to Another
  /// https://leetcode.com/problems/step-by-step-directions-from-a-binary-tree-node-to-another
  /// 
  /// Difficulty Medium
  /// Acceptance 56.4%
  /// 
  /// String
  /// Tree
  /// Depth-First Search
  /// Binary Tree
  /// </summary>
  public class Solution
  {
    public string GetDirections(TreeNode root, int startValue, int endValue)
    {
      Start = startValue;
      End = endValue;

      Proceed(root);

      var result = new System.Text.StringBuilder();

      foreach (var c in StartPath)
        result.Append(c);

      foreach (var c in EndPath)
        result.Append(c);

      return result.ToString();
    }

    private int Start;
    private int End;
    private LinkedList<char> StartPath = new();
    private LinkedList<char> EndPath = new();

    //0 Nothing
    //1 Start
    //2 End
    //3 Nothing

    private int Proceed(TreeNode node)
    {
      if (node == null)
      {
        return 0;
      }
      else
      {
        var current = node.val == Start
          ? 1
          : node.val == End
            ? 2
            : 0;

        var left = Proceed(node.left);
        var right = Proceed(node.right);

        if (left == 1)
        {
          StartPath.AddFirst('U');
        }
        else if (left == 2)
        {
          EndPath.AddFirst('L');
        }

        if (right == 1)
        {
          StartPath.AddFirst('U');
        }
        else if (right == 2)
        {
          EndPath.AddFirst('R');
        }

        return current + left + right;
      }
    }
  }
}
