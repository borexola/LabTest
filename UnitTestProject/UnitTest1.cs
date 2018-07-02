using System;
using System.Collections.Generic;
using System.Linq;
using LABTest.App_Code;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ValidateLeaderMethod1()
        {
            List<int> values = new List<int> { 2, 2, 2, 2, 2, 3, 4, 4, 4, 6 };

            int leader = LeaderClass.GetLeader(values);

            Assert.AreEqual(-1, leader);
        }

        [TestMethod]
        public void ValidateLeaderMethod2()
        {
            List<int> values = new List<int> { 1, 1, 1, 1, 50 };

            int leader = LeaderClass.GetLeader(values);

            Assert.AreEqual(1, leader);
        }


        [TestMethod]
        public void ValidateLeaderMethod3()
        {
            List<int> values = new List<int> { 2, 2, 2, 2, 50, 20, 5, 5, 5, 5, 5, 2, 2, 2, 22, 8, 9, 8, 4, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 };

            int leader = LeaderClass.GetLeader(values);

            Assert.AreEqual(2, leader);
        }
    }
}
