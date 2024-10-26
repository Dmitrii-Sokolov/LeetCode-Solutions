namespace Problem2458
{

  /// <summary>
  /// 2458. Height of Binary Tree After Subtree Removal Queries
  /// https://leetcode.com/problems/height-of-binary-tree-after-subtree-removal-queries
  /// 
  /// Difficulty Hard
  /// Acceptance 44.8%
  /// 
  /// Array
  /// Tree
  /// Depth-First Search
  /// Breadth-First Search
  /// Binary Tree
  /// </summary>
  public class Solution
  {
    public int[] TreeQueries(TreeNode root, int[] queries)
    {
      CheckHeights(root, out var heights, out var height);
      GoDepth(heights, height, root, out var answers);
      return queries.Select(q => answers.GetValueOrDefault(q, height)).ToArray();
    }

    private static void CheckHeights(TreeNode node, out Dictionary<int, int> heights, out int height)
    {
      heights = [];
      height = CheckHeights(node, heights);
    }

    private static int CheckHeights(TreeNode node, Dictionary<int, int> heights)
    {
      var height = 0;

      if (node.left != null)
        height = CheckHeights(node.left, heights) + 1;

      if (node.right != null)
      {
        var rightHeight = CheckHeights(node.right, heights) + 1;
        if (rightHeight > height)
          height = rightHeight;
      }

      heights[node.val] = height;
      return height;
    }

    private static void GoDepth(Dictionary<int, int> heights, int height, TreeNode root, out Dictionary<int, int> answers)
    {
      answers = [];
      GoDepth(answers, heights, height, root);
    }

    private static void GoDepth(
      Dictionary<int, int> answers,
      Dictionary<int, int> heights,
      int height,
      TreeNode node,
      int answer = 0)
    {
      answers[node.val] = answer;
      var difference = (node.left == null ? -1 : heights[node.left.val]) - (node.right == null ? -1 : heights[node.right.val]);
      if (difference == 0)
        return;

      (node, answer) = difference > 0
        ? (node.left, Math.Max(answer, height - difference))
        : (node.right, Math.Max(answer, height + difference));

      GoDepth(answers, heights, height, node, answer);
    }
  }
}
