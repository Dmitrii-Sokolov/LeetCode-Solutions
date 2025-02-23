namespace Problem889
{

  /// <summary>
  /// 889. Construct Binary Tree from Preorder and Postorder Traversal
  /// https://leetcode.com/problems/construct-binary-tree-from-preorder-and-postorder-traversal/description/?envType=daily-question&envId=2025-02-23
  /// 
  /// Difficulty Medium
  /// Acceptance 73.9%
  /// 
  /// Array
  /// Hash Table
  /// Divide and Conquer
  /// Tree
  /// Binary Tree
  /// </summary>
  public class Solution
  {
    public TreeNode ConstructFromPrePost(int[] preorder, int[] postorder)
      => ConstructSubree(preorder, postorder, 0, 0, preorder.Length);

    private static TreeNode ConstructSubree(int[] preorder, int[] postorder, int preorderFrom, int postorderFrom, int nodesCount)
    {
      if (nodesCount == 0)
        return null;

      var root = new TreeNode(preorder[preorderFrom]);
      if (nodesCount > 1)
      {
        var leftChildValue = preorder[preorderFrom + 1];
        var leftChildPostOrderIndex = GetIndex(postorder, leftChildValue, postorderFrom);
        var leftSubtreeNodesCount = leftChildPostOrderIndex - postorderFrom + 1;
        var rightSubtreeNodesCount = nodesCount - leftSubtreeNodesCount - 1;
        var rightChildPreorderIndex = preorderFrom + leftSubtreeNodesCount + 1;
        root.left = ConstructSubree(preorder, postorder, preorderFrom + 1, postorderFrom, leftSubtreeNodesCount);
        root.right = ConstructSubree(preorder, postorder, rightChildPreorderIndex, leftChildPostOrderIndex + 1, rightSubtreeNodesCount);
      }

      return root;
    }

    private static int GetIndex(int[] postorder, int value, int postorderFrom)
    {
      for (var i = postorderFrom; i < postorder.Length; i++)
      {
        if (postorder[i] == value)
          return i;
      }

      throw new ArgumentException();
    }

    //public TreeNode ConstructFromPrePost(int[] preorder, int[] postorder)
    //{
    //  var n = preorder.Length;
    //  Span<int> preorderIndexes = stackalloc int[n + 1];
    //  for (var i = 0; i < preorder.Length; i++)
    //    preorderIndexes[preorder[i]] = i;

    //  var nodes = new TreeNode[n + 1];
    //  Span<int> parentPreorderIndexes = stackalloc int[n + 1];

    //  var currentNodeValue = preorder[0];
    //  var root = new TreeNode(currentNodeValue);
    //  nodes[currentNodeValue] = root;
    //  for (var postorderPosition = 0; postorderPosition < n; postorderPosition++)
    //  {
    //    var value = postorder[postorderPosition];
    //    var from = parentPreorderIndexes[currentNodeValue];
    //    var to = preorderIndexes[value];
    //    if (from < to)
    //    {
    //      var currentNode = nodes[preorder[from]];
    //      var parentPreorderIndex = from;
    //      for (var i = from + 1; i <= to; i++)
    //      {
    //        var childValue = preorder[i];
    //        if (nodes[childValue] != null)
    //          continue;

    //        var child = new TreeNode(childValue);
    //        if (currentNode.left == null)
    //        {
    //          currentNode.left = child;
    //        }
    //        else
    //        {
    //          currentNode.right = child;
    //        }

    //        parentPreorderIndexes[childValue] = parentPreorderIndex;
    //        nodes[childValue] = child;

    //        currentNode = child;
    //        parentPreorderIndex = i;
    //        currentNodeValue = childValue;
    //      }
    //    }
    //    else
    //    {
    //      currentNodeValue = value;
    //    }
    //  }

    //  return root;
    //}
  }
}
