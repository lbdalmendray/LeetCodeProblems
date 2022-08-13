using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotRoomCleaner;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace RobotRoomCleanerTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int[,] world = new int[,] 
            {
                { 0,0,0,0,0,0,0,0,0,0,0 },
                { 0,1,1,1,1,1,1,1,1,1,0 },
                { 0,1,0,1,1,1,1,1,1,1,0 },
                { 0,1,0,1,1,1,1,1,1,1,0 },
                { 0,1,1,1,1,1,1,0,0,1,0 },
                { 0,1,0,0,1,1,1,1,1,1,0 },
                { 0,1,1,1,1,1,1,1,1,1,0 },
                { 0,0,0,0,0,0,0,0,0,0,0 },
            };
            IEnumerable<(int x,int y)> onePositions = GetAll1Positions(world).ToArray();

            Solution solution = new Solution();
            RobotTester robot = new RobotTester(world, (3,2));
            solution.CleanRoom(robot);
            Assert.IsTrue( world.IsClean(onePositions));
        }

        [TestMethod]
        public void TestMethod2()
        {
            int[,] world = new int[,]
            {
                { 0,0,0,0,0 },
                { 0,1,1,1,0 },
                { 0,1,1,1,0 },
                { 0,0,0,0,0 }
            };
            IEnumerable<(int x, int y)> onePositions = GetAll1Positions(world).ToArray();

            Solution solution = new Solution();
            RobotTester robot = new RobotTester(world, (3, 2));
            solution.CleanRoom(robot);
            Assert.IsTrue(world.IsClean(onePositions));
        }


        private IEnumerable<(int x, int y)> GetAll1Positions(int[,] world)
        {
            for (int i = 0; i < world.GetLength(0); i++)
            {
                for (int j = 0; j < world.GetLength(1); j++)
                {
                    if (world[i, j] == 1)
                        yield return (j,i);
                }
            }
        }
    }

    public static class HelpClass
    {
        public static bool IsClean(this int [,] world, IEnumerable<(int x, int y)> onePositions)
        {
            foreach (var item in onePositions)
            {
                try
                {
                    if (world[item.y, item.x] == 1)
                        return false;
                }
                catch (System.Exception e)
                {
                    throw e;
                }
                
            }

            return true;
        }
    }
}
