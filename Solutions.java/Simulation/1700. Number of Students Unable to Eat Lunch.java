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
class Solution
{
  public int countStudents(int[] students, int[] sandwiches)
  {
    var line = new LinkedList<Integer>();
    var types = new int[2];

    for (var i = 0; i < students.length; i++)
    {
      var student = students[i];
      line.add(student);
      types[student]++;
    }

    var sandwichNumber = 0;
    while (sandwichNumber < sandwiches.length)
    {
      var sandwich = sandwiches[sandwichNumber];
      var student = line.poll();

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

        line.add(student);
      }
    }

    return 0;
  }
}
