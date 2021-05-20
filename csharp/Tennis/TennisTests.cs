using NUnit.Framework;

namespace Tennis
{
	[TestFixture]
	public class TennisTests
	{
		private readonly string player1 = "player1";
		private readonly string player2 = "player2";

		private readonly string player1Winner = "Win for player1";

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

		[Test]
		public void TestAdvantagePlayer2()
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

			tennisGame1.WonPoint(this.player2);
			Assert.AreEqual("Advantage player2", tennisGame1.GetScore());
		}

		[Test]
		public void TestWinsPlayer1()
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
			tennisGame1.WonPoint(this.player1);
			Assert.AreEqual("Win for player1", tennisGame1.GetScore());
		}

		[Test]
		public void TestWinsPlayer2()
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

			tennisGame1.WonPoint(this.player2);
			tennisGame1.WonPoint(this.player2);
			Assert.AreEqual("Win for player2", tennisGame1.GetScore());
		}

		[Test]
		public void TestWinsBoth()
		{
			TennisGame1 tennisGame1 = CreateGameScore(this.player1, this.player2, 6, 4);

			Assert.AreEqual("Win for player1", tennisGame1.GetScore());

			tennisGame1.WonPoint(this.player2);
			tennisGame1.WonPoint(this.player2);
			tennisGame1.WonPoint(this.player2);
			tennisGame1.WonPoint(this.player2);
			Assert.AreEqual("Win for player2", tennisGame1.GetScore());
		}

		private TennisGame1 CreateGameScore(string player1, string player2, int firstPoint, int secondPoint)
		{
			// global
			TennisGame1 tennisGame1 = new TennisGame1(player1, player2);
			
			for (int i = 0; i < firstPoint; i++)
				tennisGame1.WonPoint(this.player1);
			for (int i = 0; i < secondPoint; i++)
				tennisGame1.WonPoint(this.player2);

			return tennisGame1;
		}
	}
}

