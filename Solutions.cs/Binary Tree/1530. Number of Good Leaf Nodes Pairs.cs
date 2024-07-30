namespace Problem1530
{

  /// <summary>
  /// 1530. Number of Good Leaf Nodes Pairs
  /// https://leetcode.com/problems/number-of-good-leaf-nodes-pairs
  /// 
  /// Difficulty Medium
  /// Acceptance 71.9%
  /// 
  /// Tree
  /// Depth-First Search
  /// Binary Tree
  /// </summary>
  public class Solution
  {
    public int CountPairs(TreeNode root, int distance)
    {
      Distance = distance;
      Check(root);

      return Result;
    }

    private int Result = 0;
    private int Distance = 0;

    private List<int> Check(TreeNode node)
    {
      List<int> result;
      if (node.left == null && node.right == null)
      {
        result = new List<int>();
        result.Add(0);
      }
      else if (node.left != null && node.right == null)
      {
        result = Check(node.left);
      }
      else if (node.left == null && node.right != null)
      {
        result = Check(node.right);
      }
      else
      {
        var left = Check(node.left);
        var right = Check(node.right);

        foreach (var l in left)
        {
          foreach (var r in right)
          {
            if (l + r <= Distance)
              Result++;
          }
        }

        if (left.Count > right.Count)
        {
          result = left;
          result.AddRange(right);
        }
        else
        {
          result = right;
          result.AddRange(left);
        }
      }

      for (var i = 0; i < result.Count; i++)
        result[i]++;

      return result;
    }
  }
}
