namespace Problem2471
{

  /// <summary>
  /// 2471. Minimum Number of Operations to Sort a Binary Tree by Level
  /// https://leetcode.com/problems/minimum-number-of-operations-to-sort-a-binary-tree-by-level
  /// 
  /// Difficulty Medium
  /// Acceptance 67.3%
  /// 
  /// Tree
  /// Breadth-First Search
  /// Binary Tree
  /// </summary>
  public class Solution
  {
    public int MinimumOperations(TreeNode root)
    {
      var numbers = new List<(int Index, int Value)>();
      var queue = new Queue<TreeNode>();
      queue.Enqueue(root);
      var currentLevel = 1;
      var result = 0;
      while (currentLevel > 0)
      {
        numbers.Clear();
        var nextLevel = 0;
        for (var j = 0; j < currentLevel; j++)
        {
          var node = queue.Dequeue();
          numbers.Add((j, node.val));

          if (node.left != null)
          {
            queue.Enqueue(node.left);
            nextLevel++;
          }

          if (node.right != null)
          {
            queue.Enqueue(node.right);
            nextLevel++;
          }
        }

        currentLevel = nextLevel;
        result += CountSwaps(numbers);
      }

      return result;
    }

    private static int CountSwaps(List<(int Index, int Value)> numbers)
    {
      numbers.Sort((a, b) => a.Value.CompareTo(b.Value));
      var result = 0;
      var i = 0;
      while (i < numbers.Count)
      {
        var j = numbers[i].Index;
        if (j == i)
        {
          i++;
        }
        else
        {
          (numbers[j], numbers[i]) = (numbers[i], numbers[j]);
          result++;
        }
      }

      return result;
    }
  }
}
