namespace Problem2658
{

  /// <summary>
  /// 2658. Maximum Number of Fish in a Grid
  /// https://leetcode.com/problems/maximum-number-of-fish-in-a-grid
  /// 
  /// Difficulty Medium
  /// Acceptance 67.5%
  /// 
  /// Array
  /// Depth-First Search
  /// Breadth-First Search
  /// Union Find
  /// Matrix
  /// </summary>
  public class Solution
  {
    public int FindMaxFish(int[][] gridRaw)
    {
      var result = 0;
      var xLimit = gridRaw.Length;
      var yLimit = gridRaw[0].Length;
      var cellLimit = xLimit * yLimit;
      Span<int> grid = stackalloc int[xLimit * yLimit];
      for (var x = 0; x < xLimit; x++)
      {
        for (var y = 0; y < yLimit; y++)
          grid[x * yLimit + y] = gridRaw[x][y];
      }

      var queueStart = 1;
      var queueEnd = 0;
      var queueCount = 0;
      var queueCapacity = cellLimit + 1;
      Span<int> queue = stackalloc int[queueCapacity];
      for (var cellStart = 0; cellStart < cellLimit; cellStart++)
      {
        if (grid[cellStart] != 0)
        {
          queueEnd = (queueEnd + 1) % queueCapacity;
          queue[queueEnd] = cellStart;
          queueCount++;

          var fish = 0;
          while (queueCount > 0)
          {
            var cell = queue[queueStart];
            queueStart = (queueStart + 1) % queueCapacity;
            queueCount--;

            if (grid[cell] != 0)
            {
              fish += grid[cell];
              grid[cell] = 0;

              var x = cell / yLimit;
              var y = cell % yLimit;

              if (x > 0)
              {
                queueEnd = (queueEnd + 1) % queueCapacity;
                queue[queueEnd] = cell - yLimit;
                queueCount++;
              }

              if (x < xLimit - 1)
              {
                queueEnd = (queueEnd + 1) % queueCapacity;
                queue[queueEnd] = cell + yLimit;
                queueCount++;
              }

              if (y > 0)
              {
                queueEnd = (queueEnd + 1) % queueCapacity;
                queue[queueEnd] = cell - 1;
                queueCount++;
              }

              if (y < yLimit - 1)
              {
                queueEnd = (queueEnd + 1) % queueCapacity;
                queue[queueEnd] = cell + 1;
                queueCount++;
              }
            }
          }

          if (result < fish)
            result = fish;
        }
      }

      return result;
    }

    private struct SimpleQueue
    {
      private readonly int[] Queue;
      private readonly int Capacity;

      private int Start = 1;
      private int End = 0;
      private int Count = 0;

      public SimpleQueue(int capacity) : this()
      {
        Capacity = capacity;
        Queue = new int[capacity];
      }

      public void Add(int number)
      {
        End = (End + 1) % Capacity;
        Queue[End] = number;
        Count++;
      }

      public bool TryGet(out int number)
      {
        number = Queue[Start];
        if (Count == 0)
        {
          return false;
        }
        else
        {
          Start = (Start + 1) % Capacity;
          Count--;

          return true;
        }
      }
    }
  }
}
