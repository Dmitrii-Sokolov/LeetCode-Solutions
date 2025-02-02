namespace Problem2127
{

  /// <summary>
  /// 2127. Maximum Employees to Be Invited to a Meeting
  /// https://leetcode.com/problems/maximum-employees-to-be-invited-to-a-meeting
  /// 
  /// Difficulty Hard
  /// Acceptance 46.3%
  /// 
  /// Depth-First Search
  /// Graph
  /// Topological Sort
  /// </summary>
  public class Solution
  {
    public int MaximumInvitations(int[] favourites)
    {
      var count = favourites.Length;
      Span<int> degrees = stackalloc int[count];
      for (var i = 0; i < favourites.Length; i++)
        degrees[favourites[i]]++;

      var queue = new Queue<int>();
      for (var i = 0; i < count; i++)
      {
        if (degrees[i] == 0)
          queue.Enqueue(i);
      }

      Span<int> tails = stackalloc int[count];
      while (queue.Count > 0)
      {
        var node = queue.Dequeue();
        var favourite = favourites[node];
        tails[favourite] = Math.Max(tails[favourite], tails[node] + 1);
        degrees[favourite]--;
        if (degrees[favourite] == 0)
          queue.Enqueue(favourite);
      }

      var maxCycle = 0;
      var uncycled = 0;
      Span<bool> visited = stackalloc bool[count];
      for (var i = 0; i < count; i++)
      {
        if (!visited[i] && degrees[i] > 0)
        {
          var counter = 0;
          var node = i;
          while (!visited[node])
          {
            visited[node] = true;
            node = favourites[node];
            counter++;
          }

          if (maxCycle < counter)
            maxCycle = counter;

          if (counter == 2)
          {
            uncycled += tails[node] + 1;
            uncycled += tails[favourites[node]] + 1;
          }
        }
      }

      return Math.Max(uncycled, maxCycle);
    }
  }
}
