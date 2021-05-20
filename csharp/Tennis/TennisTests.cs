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

    }
}

