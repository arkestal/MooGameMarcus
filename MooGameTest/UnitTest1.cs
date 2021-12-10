using Microsoft.VisualStudio.TestTools.UnitTesting;
using MooGameMarcus;
using System.Collections.Generic;
using System.Linq;

namespace MooGameTest
{
    [TestClass]
    public class UnitTest1
    {
        GameLogic logic;

        [TestInitialize]
        public void Init()
        {
            logic = new();
        }

        [TestMethod]
        public void TestGuessOutputNormal1Moo()
        {
            string answer = logic.CheckGuess("1234", "1234", 4);
            Assert.AreEqual("BBBB,", answer);

        }

        [TestMethod]
        public void TestGuessOutputNormal2Moo()
        {
            string answer = logic.CheckGuess("1234", "1245", 4);
            Assert.AreEqual("BB,C", answer);
        }

        [TestMethod]
        public void TestGuessOutputNormal3Moo()
        {
            string answer = logic.CheckGuess("1234", "0146", 4);
            Assert.AreEqual(",CC", answer);
        }

        [TestMethod]
        public void TestGuessOutputNormal4Moo()
        {
            string answer = logic.CheckGuess("1234", "5678", 4);
            Assert.AreEqual(",", answer);
        }

        [TestMethod]
        public void TestGuessOutputHard1Moo()
        {
            string answer = logic.CheckGuess("123456", "123456", 6);
            Assert.AreEqual("BBBBBB,", answer);
        }

        [TestMethod]
        public void TestGuessOutputHard2Moo()
        {
            string answer = logic.CheckGuess("123456", "456789", 6);
            Assert.AreEqual(",CCC", answer);
        }

        [TestMethod]
        public void TestCreateGoalNumberNormalLengthMoo()
        {
            string answer = logic.CreateGoalNumber(4);
            Assert.AreEqual(4, answer.Length);
        }

        [TestMethod]
        public void TestCreateGoalNumberHardLengthMoo()
        {
            string answer = logic.CreateGoalNumber(6);
            Assert.AreEqual(6, answer.Length);
        }

        [TestMethod]
        public void TestCreateGoalNumberNormalDigitsMoo()
        {
            string answer = logic.CreateGoalNumber(4);
            bool isNumber = answer.All(char.IsDigit);
            Assert.IsTrue(isNumber);
        }

        [TestMethod]
        public void TestCreateGoalNumberHardDigitsMoo()
        {
            string answer = logic.CreateGoalNumber(6);
            bool isNumber = answer.All(char.IsDigit);
            Assert.IsTrue(isNumber);
        }

        [TestMethod]
        public void TestGuessOutputNumbersGame1()
        {
            string answer = logic.CheckGuess("15", "15", 2);
            Assert.AreEqual("Win!", answer);
        }

        [TestMethod]
        public void TestGuessOutputNumbersGame2()
        {
            string answer = logic.CheckGuess("25", "15", 2);
            Assert.AreEqual("Goal number is higher!", answer);
        }

        [TestMethod]
        public void TestGuessOutputNumbersGame3()
        {
            string answer = logic.CheckGuess("25", "35", 2);
            Assert.AreEqual("Goal number is lower!", answer);
        }
    }
}