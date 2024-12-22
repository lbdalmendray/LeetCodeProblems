namespace MeetingRoomsII;

public class Solution
{
    public int MinMeetingRooms(int[][] intervals)
    {
        var startList = intervals.Select(i => i[0]).ToArray();
        Array.Sort(startList);
        var endList = intervals.Select(i => i[1]).ToArray();
        Array.Sort(endList);

        int i = 0;
        int j = 0;
        int result = 0;
        int overlapCounter = 0;
        
        while( i < startList.Length && j < endList.Length)
        {
            if (startList[i] < endList[j])
            {
                overlapCounter++;
                i++;
                if (overlapCounter > result)
                    result = overlapCounter;
            }
            else
            {
                overlapCounter--;
                j++;
            }
        }

        return result;
    }
}
