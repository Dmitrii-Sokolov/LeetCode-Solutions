namespace Problem1233
{

  /// <summary>
  /// 1233. Remove Sub-Folders from the Filesystem
  /// https://leetcode.com/problems/remove-sub-folders-from-the-filesystem
  /// 
  /// Difficulty Medium
  /// Acceptance 69.3%
  /// 
  /// Array
  /// String
  /// Depth-First Search
  /// Trie
  /// </summary>
  public class Solution
  {
    public IList<string> RemoveSubfolders(string[] folders)
    {
      var foldersSet = folders.ToHashSet();
      return folders
        .Where(folder => IsUnique(foldersSet, folder))
        .ToList();
    }

    private static bool IsUnique(HashSet<string> folders, string folder)
    {
      var parts = folder.Split('/');
      var path = string.Empty;
      for (var i = 1; i < parts.Length - 1; i++)
      {
        path += $"/{parts[i]}";
        if (folders.Contains(path))
          return false;
      }

      return true;
    }
  }
}
