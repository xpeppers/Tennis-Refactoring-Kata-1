using NUnit.Framework;

namespace Tennis
{
	[TestFixture]
	public class TennisTests
	{
		private readonly string player1 = "player1";
		private readonly string player2 = "player2";

		[Test]
		public void TestBasic()
		{
			TennisGame1 tennisGame1 = new TennisGame1(this.player1, this.player2);
			tennisGame1.WonPoint(this.player1);
			Assert.AreEqual("Fifteen-Love", tennisGame1.GetScore());
		}

		[Test]
		public void TestDeuce()
		{
			TennisGame1 tennisGame1 = new TennisGame1(this.player1, this.player2);
			Assert.AreEqual("Love-All", tennisGame1.GetScore());

			tennisGame1.WonPoint(this.player1);
			tennisGame1.WonPoint(this.player2);
			Assert.AreEqual("Fifteen-All", tennisGame1.GetScore());

			tennisGame1.WonPoint(this.player1);
			tennisGame1.WonPoint(this.player2);
			Assert.AreEqual("Thirty-All", tennisGame1.GetScore());

			tennisGame1.WonPoint(this.player1);
			tennisGame1.WonPoint(this.player2);
			Assert.AreEqual("Deuce", tennisGame1.GetScore());

		}

		[Test]
		public void TestAdvantage()
        {
			TennisGame1 tennisGame1 = new TennisGame1(this.player1, this.player2);
			tennisGame1.WonPoint(this.player1);
			tennisGame1.WonPoint(this.player2);

			tennisGame1.WonPoint(this.player1);
			tennisGame1.WonPoint(this.player2);

			tennisGame1.WonPoint(this.player1);
			tennisGame1.WonPoint(this.player2);

			tennisGame1.WonPoint(this.player1);
			tennisGame1.WonPoint(this.player2);

			tennisGame1.WonPoint(this.player1);
			Assert.AreEqual("Advantage player1", tennisGame1.GetScore());
		}
	}
}

