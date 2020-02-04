using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinimumDifficultyofaJobSchedule;

namespace MinimumDifficultyofaJobScheduleTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution s = new Solution();
            var result = s.MinDifficulty(new int[] { 6, 5, 4, 3, 2, 1 }, 2);
            Assert.AreEqual(result, 7);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution s = new Solution();
            var result = s.MinDifficulty(new int[] { 1,1,1 }, 3);
            Assert.AreEqual(result, 3);
        }

        [TestMethod]
        public void TestMethod3()
        {
            Solution s = new Solution();
            var result = s.MinDifficulty(new int[] { 1,7, 1, 1 }, 3);
            Assert.AreEqual(result, 9);
        }

        [TestMethod]
        public void TestMethod4()
        {
            Solution s = new Solution();
            var result = s.MinDifficulty(new int[] { 9, 9, 9 }, 4);
            Assert.AreEqual(result, -1);
        }

        [TestMethod]
        public void TestMethod5()
        {
            Solution s = new Solution();
            var result = s.MinDifficulty(new int[] { 7, 1, 7, 1, 7, 1 }, 3);
            Assert.AreEqual(result, 15);
        }

        [TestMethod]
        public void TestMethod6()
        {
            Solution s = new Solution();
            var result = s.MinDifficulty(new int[] { 11, 111, 22, 222, 33, 333, 44, 444 }, 6);
            Assert.AreEqual(result, 843);
        }

        [TestMethod]
        public void TestMethod7()
        {
            Solution s = new Solution();
            var result = s.MinDifficulty(new int[] { 920, 539, 840, 271, 685, 491, 802, 635, 240, 339, 353, 483, 65, 945, 122, 944, 638, 618, 873, 382, 183, 891, 582, 839, 781, 331, 178, 888, 437, 490, 411, 47, 327, 977, 135, 408, 454, 963 }, 1);
            Assert.AreEqual(result, 977);
        }

        [TestMethod]
        public void TestMethod8()
        {
            Solution s = new Solution();
            var result = s.MinDifficulty(new int[] { 42, 35, 957, 671, 87, 222, 524, 5, 280, 878, 242, 398, 610, 984, 649, 513, 563, 997, 786, 223, 413, 961, 208, 189, 519, 606, 504, 406, 994, 475, 940, 476, 762, 283, 218, 404, 715, 755, 689, 457, 20, 403, 749, 68, 17, 763, 78, 695, 445, 338, 643, 400, 615, 29, 866, 861, 103, 665, 743, 361, 798, 236, 255, 15, 326, 124, 14, 588, 711, 992, 501, 731, 538, 619, 765, 8, 477, 854, 243, 95, 627, 480, 505, 800, 818, 722, 194, 717, 305, 810, 497, 686, 704, 322, 532, 22, 234, 290, 885, 416, 155, 428, 161, 315, 152, 441, 730, 926, 175, 536, 646, 922, 951, 101, 107, 233, 61, 735, 669, 512, 28, 569, 447, 982, 916, 321, 1000, 754, 483, 482, 811, 654, 47, 344, 772, 978, 467, 308, 472, 269, 0, 252, 131, 834, 303, 945, 469, 785, 537, 188, 449, 675, 528, 733, 271, 541, 822, 328, 904, 876, 889, 55, 16, 853, 154, 767, 573, 925, 279, 697, 525, 431, 375, 958, 836, 911, 166, 965, 523, 709, 923, 587, 603, 226, 354, 641, 620, 316, 110, 292, 529, 943, 1, 151, 737, 959, 27, 56, 353, 681, 26, 677, 337, 723, 12, 914, 955, 134, 370, 260, 490, 684, 364, 618, 232, 870, 985, 196, 225, 359, 129, 58, 341, 67, 494, 757, 229, 323, 256, 21, 783, 692, 642, 37, 909, 248, 81, 345, 425, 478, 651, 309, 435, 10, 534, 450, 576, 144, 201, 496, 267, 609, 11, 454, 531, 966, 156, 176, 190, 542, 856, 365, 983, 947, 758, 950, 388, 820, 867, 833, 605, 741, 34, 663, 884, 65, 628, 969, 864, 664, 718, 805, 891, 657, 863, 960, 518, 71, 300, 756, 613, 667, 228, 274, 971, 970, 552, 556, 648, 251 }, 10);
            Assert.AreEqual(result, 3044);
        }
    }
}
