namespace Problem2092
{

  /// <summary>
  /// 2092. Find All People With Secret
  /// https://leetcode.com/problems/find-all-people-with-secret
  /// 
  /// Difficulty Hard
  /// Acceptance 45.6%
  /// 
  /// Depth-First Search
  /// Breadth-First Search
  /// Union Find
  /// Graph
  /// Sorting
  /// </summary>
  public class Solution
  {
    public IList<int> FindAllPeople(int n, int[][] meetings, int firstPerson)
    {
      var meets = new PriorityQueue<int[], int>();
      var people = new HashSet<int>();

      for (var i = 0; i < meetings.Length; i++)
      {
        var m = meetings[i];
        var p0 = m[0];
        var p1 = m[1];
        var t = m[2];
        meets.Enqueue(m, t);
      }

      var meets2 = new PriorityQueue<List<HashSet<int>>, int>();
      var time = 0;

      while (meets.Count > 0)
      {
        var list = new List<HashSet<int>>();

        do
        {
          var m = meets.Dequeue();
          var p0 = m[0];
          var p1 = m[1];
          time = m[2];

          HashSet<int> set0 = null;
          HashSet<int> set1 = null;

          foreach (var s in list)
          {
            if (s.Contains(p0))
              set0 = s;

            if (s.Contains(p1))
              set1 = s;
          }

          if (set0 == null && set1 == null)
          {
            var set = new HashSet<int>();
            set.Add(p0);
            set.Add(p1);
            list.Add(set);
          }
          else if (set0 == null && set1 != null)
          {
            set1.Add(p0);
          }
          else if (set0 != null && set1 == null)
          {
            set0.Add(p1);
          }
          else if (set0 != null && set1 != null)
          {
            list.Remove(set0);
            list.Remove(set1);

            var set = new HashSet<int>();
            foreach (var s in set0)
              set.Add(s);

            foreach (var s in set1)
              set.Add(s);
            list.Add(set);
          }
        } while (meets.Count > 0 && meets.Peek()[2] == time);

        meets2.Enqueue(list, time);
      }

      people.Add(0);
      people.Add(firstPerson);

      while (meets2.Count > 0)
      {
        var list = meets2.Dequeue();
        foreach (var set in list)
        {
          if (set.Any(p => people.Contains(p)))
            foreach (var s in set)
              people.Add(s);
        }
      }

      return people.ToList();
    }
  }
}
