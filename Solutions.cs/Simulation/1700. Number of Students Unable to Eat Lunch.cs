namespace Problem1700
{

  /// <summary>
  /// 1700. Number of Students Unable to Eat Lunch
  /// https://leetcode.com/problems/number-of-students-unable-to-eat-lunch
  /// 
  /// Difficulty Easy
  /// Acceptance 78.3%
  /// 
  /// Array
  /// Stack
  /// Queue
  /// Simulation
  /// </summary>
  public class Solution
  {
    public int CountStudents(int[] students, int[] sandwiches)
    {
      var line = new Queue<int>();
      var types = new int[2];

      for (var i = 0; i < students.Length; i++)
      {
        var student = students[i];
        line.Enqueue(student);
        types[student]++;
      }

      var sandwichNumber = 0;
      while (sandwichNumber < sandwiches.Length)
      {
        var sandwich = sandwiches[sandwichNumber];
        var student = line.Dequeue();

        if (sandwich == student)
        {
          sandwichNumber++;
          types[student]--;
        }
        else
        {
          if (sandwich == 0 && types[0] == 0)
            return types[1];

          if (sandwich == 1 && types[1] == 0)
            return types[0];

          line.Enqueue(student);
        }
      }

      return 0;
    }
  }
}
