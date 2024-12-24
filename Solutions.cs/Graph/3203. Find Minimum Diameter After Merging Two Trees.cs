namespace Problem3203
{

  /// <summary>
  /// 3203. Find Minimum Diameter After Merging Two Trees
  /// https://leetcode.com/problems/find-minimum-diameter-after-merging-two-trees
  /// 
  /// Difficulty Hard
  /// Acceptance 45.7%
  /// 
  /// Tree
  /// Depth-First Search
  /// Breadth-First Search
  /// Graph
  /// </summary>
  public class Solution
  {
    public int MinimumDiameterAfterMerge(int[][] edges0, int[][] edges1)
    {
      var diameter0 = GetDiameter(edges0);
      var diameter1 = GetDiameter(edges1);
      var combined = (diameter0 + 1) / 2 + (diameter1 + 1) / 2 + 1;

      return Math.Max(combined, Math.Max(diameter0, diameter1));
    }

    private static int GetDiameter(int[][] edgesRaw)
    {
      if (edgesRaw.Length == 0)
        return 0;

      var edges = new List<int>[edgesRaw.Length + 1];
      foreach (var edge in edgesRaw)
      {
        var node0 = edge[0];
        var node1 = edge[1];

        AddEdge(edges, node0, node1);
        AddEdge(edges, node1, node0);
      }

      RemoveParent(edges, 0);

      return GetHeightAndChord(edges, 0).Chord;
    }

    private static (int Height, int Chord) GetHeightAndChord(List<int>[] edges, int node)
    {
      var maxHeight0 = -1;
      var maxHeight1 = -1;
      var maxChord = 0;
      foreach (var child in edges[node])
      {
        var (height, chord) = GetHeightAndChord(edges, child);
        if (maxChord < chord)
          maxChord = chord;

        if (height > maxHeight0)
        {
          maxHeight1 = maxHeight0;
          maxHeight0 = height;
        }
        else if (height > maxHeight1)
        {
          maxHeight1 = height;
        }
      }

      var anotherChord = maxHeight0 + maxHeight1 + 2;
      if (maxChord < anotherChord)
        maxChord = anotherChord;

      return (maxHeight0 + 1, maxChord);
    }

    private static void RemoveParent(List<int>[] edges, int node)
    {
      foreach (var child in edges[node])
        RemoveParent(edges, child, node);
    }

    private static void RemoveParent(List<int>[] edges, int node, int parent)
    {
      edges[node].Remove(parent);
      foreach (var child in edges[node])
        RemoveParent(edges, child, node);
    }

    private static void AddEdge(List<int>[] edges, int node0, int node1)
    {
      if (edges[node0] == null)
        edges[node0] = [];

      edges[node0].Add(node1);
    }
  }
}
