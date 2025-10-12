namespace KokoEatingBananasTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            KokoEatingBananas.Solution solution = new KokoEatingBananas.Solution();
            
            var result = solution.MinEatingSpeed([3, 6, 7, 11], 8);

            Assert.AreEqual(result, 4);
        }

        [TestMethod]
        public void TestMethod2()
        {
            KokoEatingBananas.Solution solution = new KokoEatingBananas.Solution();

            var result = solution.MinEatingSpeed([30, 11, 23, 4, 20], 5);

            Assert.AreEqual(result, 30);
        }

        [TestMethod]
        public void TestMethod3()
        {
            KokoEatingBananas.Solution solution = new KokoEatingBananas.Solution();

            var result = solution.MinEatingSpeed([30, 11, 23, 4, 20], 6);

            Assert.AreEqual(result, 23);
        }


        [TestMethod]
        public void TestMethod4()
        {
            KokoEatingBananas.Solution solution = new KokoEatingBananas.Solution();

            ///// [ 4,4,4,4,4,4,4, 5,5,5,5,5,5 ] , 26

            var result = solution.MinEatingSpeed([4,5,4,5,4,5,4,5,4,5,4,5,4], 26);

            Assert.AreEqual(result, 3);
        }

        [TestMethod]
        public void TestMethod5()
        {
            KokoEatingBananas.Solution solution = new KokoEatingBananas.Solution();

            ///// [ 4,4,4,4,4,4,4, 5,5,5,5,5,5 ] , 26
            var arrayInput = Enumerable.Range(0, 10_000).Select(e =>
            {
                if (e % 2 == 0)
                    return 4;
                else
                    return 5;
            }).ToArray();


            var result = solution.MinEatingSpeed(arrayInput, arrayInput.Length * 2);

            Assert.AreEqual(result, 3);
        }

        [TestMethod]
        public void TestMethod6()
        {
            KokoEatingBananas.Solution solution = new KokoEatingBananas.Solution();
            
            int [] arrayInput = [4, 4, 4, 4, 4, 4, 4, 5, 5, 5, 5, 5, 5];
            var result = solution.MinEatingSpeed(arrayInput, arrayInput.Sum() + 1 );

            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void TestMethod7()
        {
            KokoEatingBananas.Solution solution = new KokoEatingBananas.Solution();

            int[] arrayInput = [332484035, 524908576, 855865114, 632922376, 222257295, 690155293, 112677673, 679580077, 337406589, 290818316, 877337160, 901728858, 679284947, 688210097, 692137887, 718203285, 629455728, 941802184];
            var result = solution.MinEatingSpeed(arrayInput, 823855818);

            Assert.AreEqual(result, 14);
        }
    }
}