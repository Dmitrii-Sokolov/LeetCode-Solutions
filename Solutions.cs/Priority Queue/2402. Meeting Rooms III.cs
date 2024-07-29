namespace Problem2402
{

  /// <summary>
  /// 2402. Meeting Rooms III
  /// https://leetcode.com/problems/meeting-rooms-iii
  /// 
  /// Difficulty Hard
  /// Acceptance 44.3%
  /// 
  /// Array
  /// Hash Table
  /// Sorting
  /// Heap(Priority Queue)
  /// Simulation
  /// </summary>
  public class Solution
  {
    private const int EndOfTime = 1000000;

    public int MostBooked(int n, int[][] meetings)
    {
      var starts = new PriorityQueue<MeetingStart, long>();
      var ends = new PriorityQueue<MeetingEnd, long>();
      var meetingsCount = new long[n];
      var isFree = new PriorityQueue<int, int>();
      long currentTime = 0;

      for (var i = 0; i < n; i++)
        isFree.Enqueue(i, i);

      for (var i = 0; i < meetings.Length; i++)
        starts.Enqueue(new MeetingStart(meetings[i]), meetings[i][0]);

      while (starts.Count > 0)
      {
        if (isFree.Count == 0)
        {
          do
          {
            var end = ends.Dequeue();
            currentTime = end.End;
            EndMeeting(end.Room);
          }
          while (ends.Count > 0 && ends.Peek().End == currentTime);
        }
        else
        {
          var nextStart = starts.Peek().Start;
          var nextEnd = ends.Count > 0 ? ends.Peek().End : EndOfTime;

          if (nextEnd <= nextStart)
          {
            var end = ends.Dequeue();
            currentTime = end.End;

            EndMeeting(end.Room);
          }
          else
          {
            var start = starts.Dequeue();
            currentTime = Math.Max(currentTime, start.Start);

            StartMeeting(currentTime + start.Duration);
          }
        }
      }

      return GetMax();

      void StartMeeting(long end)
      {
        var room = isFree.Dequeue();
        meetingsCount[room] = meetingsCount[room] + 1;
        var another = new MeetingEnd(end, room);
        ends.Enqueue(another, end);
      }

      void EndMeeting(int room)
      {
        isFree.Enqueue(room, room);
      }

      int GetMax()
      {
        var max = 0;
        for (var i = 0; i < n; i++)
        {
          if (meetingsCount[max] < meetingsCount[i])
            max = i;
        }
        return max;
      }
    }

    public struct MeetingEnd : IEvent
    {
      public long End;
      public int Room;

      public MeetingEnd(long end, int room)
      {
        End = end;
        Room = room;
      }
    }

    public struct MeetingStart : IEvent
    {
      public long Start;
      public long Duration;

      public MeetingStart(int[] p)
      {
        Start = p[0];
        Duration = p[1] - p[0];
      }
    }

    public interface IEvent
    {
    }
  }
}
