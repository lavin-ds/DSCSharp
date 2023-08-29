/* TODO:
252. Meeting Rooms
https://leetcode.com/problems/meeting-rooms/
Easy

Given an array of meeting time intervals consisting of start and end times [[s1,e1], [s2,e2], ...]
(si< ei), determine if a person could attend all meetings.

Example 1:

Input:
[[0,30],[5,10],[15,20]]
Output: false

Example 2:

Input:[[7,10],[2,4]]

Output:true
*/

using System.Collections.Generic;
using Xunit;

namespace Algorithms.LeetCode.Scheduling
{   
    public class MeetingRooms2
    {
        public bool MeetingRooms(int[][] intervals) 
        {
            HashSet<int> runningMeet = new HashSet<int>();
            for(int i = 0;i<intervals.Length;i++)
            {
                for(int k = intervals[i][0]; k <= intervals[i][1];k++)
                {
                    if(!runningMeet.Add(k))
                        return false;                    
                }                
            }
            return true;
        }

        [Fact]
        public void TestName()
        {
            int[][] meetings1 = new int[3][];            
            meetings1[0]  = new int[2]{0,30};
            meetings1[1]  = new int[2]{5,10};
            meetings1[2]  = new int[2]{15,20};           

            Assert.False(MeetingRooms(meetings1));

            int[][] meetings2 = new int[4][];            
            meetings2[0]  = new int[2]{0,30};
            meetings2[1]  = new int[2]{31,40};
            meetings2[2]  = new int[2]{45,50};
            meetings2[3]  = new int[2]{55,60};

            Assert.True(MeetingRooms(meetings2));

            int[][] meetings3 = new int[2][];            
            meetings3[0]  = new int[2]{7,10};
            meetings3[1]  = new int[2]{2,4};

            Assert.True(MeetingRooms(meetings3));
        }
    }
}