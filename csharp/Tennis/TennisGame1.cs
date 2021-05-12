namespace Tennis
{
    class TennisGame1 : ITennisGame
    {
        private int firstPlayerPoints = 0;
        private int secondPlayerPoints = 0;
        private string player1Name;
        private string player2Name;

        public TennisGame1(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
                firstPlayerPoints += 1;
            else
                secondPlayerPoints += 1;
        }

        public string GetScore()
        {
            if (IsDraw())
            {
                return ScoreForDraw();
            }

            if (IsDuece())
            {
                return ScoreForDeuce();
            }

            if (IsWinning())
            {
                return ScoreForWinning();
            }

            return ScoreForGame();
        }

        private string ScoreForGame()
        {
            return ScoreFor(firstPlayerPoints) + "-" + ScoreFor(secondPlayerPoints);
        }

        private string ScoreForWinning()
        {
            return PointsGap() >= 2 ? "Win for player1" : "Win for player2";
        }

        private bool IsWinning()
        {
            return (firstPlayerPoints >= 4 || secondPlayerPoints >= 4) && (PointsGap() >= 2 || PointsGap() <= -2);
        }

        private string ScoreForDeuce()
        {
            return PointsGap() == 1 ? "Advantage player1" : "Advantage player2";
        }

        private bool IsDuece()
        {
            return (firstPlayerPoints >= 4 || secondPlayerPoints >= 4) && (PointsGap() == 1 || PointsGap() == -1);
        }

        private int PointsGap()
        {
            return firstPlayerPoints - secondPlayerPoints;
        }

        private bool IsDraw()
        {
            return firstPlayerPoints == secondPlayerPoints;
        }

        private string ScoreFor(int playerScore)
        {
            return playerScore switch
            {
                0 => "Love",
                1 => "Fifteen",
                2 => "Thirty",
                3 => "Forty",
                _ => ""
            };
        }

        private string ScoreForDraw()
        {
            return firstPlayerPoints switch
            {
                0 => "Love-All",
                1 => "Fifteen-All",
                2 => "Thirty-All",
                _ => "Deuce"
            };
        }
    }
}