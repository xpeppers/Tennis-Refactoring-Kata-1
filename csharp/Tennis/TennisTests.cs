using System;
using NUnit.Framework;

namespace Tennis
{
    [TestFixture]
    public class TennisTests
    {
        [Test]
        public void InitialGame_LoveAll()
        {
            TennisGame1 tennisGame = new TennisGame1("A","B");

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
    }
}

