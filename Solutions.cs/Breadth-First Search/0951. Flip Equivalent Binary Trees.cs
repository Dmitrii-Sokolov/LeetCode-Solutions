namespace Problem951
{

  /// <summary>
  /// 951. Flip Equivalent Binary Trees
  /// https://leetcode.com/problems/flip-equivalent-binary-trees
  /// 
  /// Difficulty Medium
  /// Acceptance 67.6%
  /// 
  /// Tree
  /// Depth - First Search
  /// Binary Tree
  /// </summary>
  public class Solution
  {
    public bool FlipEquiv(TreeNode rootA, TreeNode rootB)
    {
      if (rootA != null && rootB != null && rootA.val == rootB.val)
      {
        var levelA = new Queue<(TreeNode Left, TreeNode Right)>();
        Enqueue(levelA, rootA);

        var levelB = new Queue<(TreeNode Left, TreeNode Right)>();
        Enqueue(levelB, rootB);

        while (levelA.Count > 0 && levelB.Count > 0)
        {
          var pairA = levelA.Dequeue();
          var pairB = levelB.Dequeue();

          var valuesA = GetValuePair(pairA);
          var valuesB = GetValuePair(pairB);

          if (valuesA == valuesB)
          {
            Enqueue(levelA, pairA.Left);
            Enqueue(levelA, pairA.Right);
            Enqueue(levelB, pairB.Left);
            Enqueue(levelB, pairB.Right);
          }
          else if (Flip(valuesA) == valuesB)
          {
            Enqueue(levelA, pairA.Right);
            Enqueue(levelA, pairA.Left);
            Enqueue(levelB, pairB.Left);
            Enqueue(levelB, pairB.Right);
          }
          else
          {
            return false;
          }
        }

        return true;
      }
      else
      {
        return rootA == null && rootB == null;
      }
    }

    private static void Enqueue(Queue<(TreeNode Left, TreeNode Right)> levelA, TreeNode node)
    {
      if (node != null)
        levelA.Enqueue((node.left, node.right));
    }

    private static (int? LeftValue, int? RightValue) GetValuePair((TreeNode Left, TreeNode Right) pair)
      => (GetValue(pair.Left), GetValue(pair.Right));

    private static int? GetValue(TreeNode node) => node?.val;

    private static (int? LeftValue, int? RightValue) Flip((int? LeftValue, int? RightValue) pair)
      => (pair.RightValue, pair.LeftValue);
  }
}
