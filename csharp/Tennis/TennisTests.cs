using System;
using NUnit.Framework;
using System.Linq;

namespace Tennis
{
    [TestFixture]
    public class TennisTests
    {
        [Test]
        public void InitialGame_LoveAll()
        {
            TennisGame1 tennisGame = new TennisGame1("A", "B");

            Assert.AreEqual("Love-All", tennisGame.GetScore());

        }

        [Test]
        public void Won_40_0()
        {
            string player1 = "player1";

            TennisGame1 tennisGame = new TennisGame1("A", "B");
            tennisGame.WonPoint(player1);
            tennisGame.WonPoint(player1);
            tennisGame.WonPoint(player1);
            tennisGame.WonPoint(player1);

            Assert.AreEqual("Win for player1", tennisGame.GetScore());

        }

        [Test]
        public void Won_0_40()
        {
            string player2 = "player2";

            TennisGame1 tennisGame = new TennisGame1("A", "B");
            tennisGame.WonPoint(player2);
            tennisGame.WonPoint(player2);
            tennisGame.WonPoint(player2);
            tennisGame.WonPoint(player2);

            Assert.AreEqual("Win for player2", tennisGame.GetScore());
        }

        [Test]
        public void Advantages()
        {
            string player1 = "player1";
            string player2 = "player2";

            TennisGame1 tennisGame = DoDeuce(player1, player2);
            tennisGame.WonPoint(player1);

            Assert.AreEqual("Advantage player1", tennisGame.GetScore());
        }

        [Test]
        public void Deuce()
        {
            string player1 = "player1";
            string player2 = "player2";

            TennisGame1 tennisGame = DoDeuce(player1, player2);

            Assert.AreEqual("Deuce", tennisGame.GetScore());
        }

        [Test]
        public void AdvantagePlayer2()
        {
            string player1 = "player1";
            string player2 = "player2";

            TennisGame1 tennisGame = DoDeuce(player1, player2);
            tennisGame.WonPoint(player2);

            Assert.AreEqual("Advantage player2", tennisGame.GetScore());
        }
        
        [Test]
        [TestCase("player1,player2", "Fifteen-All")]
        [TestCase("player1,player2,player1", "Thirty-Fifteen")]
        public void ParametricTest(string playerPoints, string expectedResult)
        {
            string[] players = playerPoints.Split(',');

            TennisGame1 tennisGame1 = new TennisGame1("aa", "bbb");

            players.ToList().ForEach(x => tennisGame1.WonPoint(x));
            Assert.AreEqual(expectedResult, tennisGame1.GetScore());
        }

        private static TennisGame1 DoDeuce(string player1, string player2)
        {
            TennisGame1 tennisGame = new TennisGame1("A", "B");
            tennisGame.WonPoint(player1);
            tennisGame.WonPoint(player2);   // 15-15
            tennisGame.WonPoint(player1);
            tennisGame.WonPoint(player2);   // 30-30
            tennisGame.WonPoint(player1);
            tennisGame.WonPoint(player2);   // 40-40
            return tennisGame;
        }

    }
}

