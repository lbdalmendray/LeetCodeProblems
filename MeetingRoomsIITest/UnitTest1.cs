using MeetingRoomsII;

namespace MeetingRoomsIITest;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestMethod1()
    {
        Solution solution = new Solution();
        var result = solution.MinMeetingRooms([[0, 30], [5, 10], [15, 20]]);
        Assert.AreEqual(result, 2);
    }

    [TestMethod]
    public void TestMethod2()
    {
        Solution solution = new Solution();
        var result = solution.MinMeetingRooms([[7, 10], [2, 4]]);
        Assert.AreEqual(result, 1);
    }

    [TestMethod]
    public void TestMethod3()
    {
        Solution solution = new Solution();
        var result = solution.MinMeetingRooms([[7, 10], [2, 4] , [3,8]]);
        Assert.AreEqual(result, 2);
    }

    [TestMethod]
    public void TestMethod4()
    {
        Solution solution = new Solution();
        var result = solution.MinMeetingRooms([[7, 10], [2, 4], [3, 8] , [11,15]]);
        Assert.AreEqual(result, 2);
    }

    [TestMethod]
    public void TestMethod5()
    {
        Solution solution = new Solution();
        var result = solution.MinMeetingRooms([[7, 10], [2, 4], [3, 8], [11, 15], [15, 18] , [6,16]]);
        Assert.AreEqual(result, 3);
    }

    [TestMethod]
    public void TestMethod6()
    {
        Solution solution = new Solution();
        var result = solution.MinMeetingRooms([[2, 15], [36, 45], [9, 29], [16, 23], [4, 9]]);
        Assert.AreEqual(result, 2);
    }

    [TestMethod]
    public void TestMethod7()
    {
        Solution solution = new Solution();
        var result = solution.MinMeetingRooms([[1, 5], [1, 5], [1, 5], [1, 5], [1, 5]]);
        Assert.AreEqual(result, 5);
    }
}