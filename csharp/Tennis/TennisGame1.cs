namespace Tennis
{
    class TennisGame1 : ITennisGame
    {
        private const string PLAYER1 = "player1";
        private int player1Score = 0;
        private int player2Score = 0;
        private string player1Name;
        private string player2Name;

        public TennisGame1(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == PLAYER1)
                player1Score += 1;
            else
                player2Score += 1;
        }

        public string GetScore()
        {
            if (player1Score == player2Score)
            {
                return GetEqualScore();
            }
            else if (player1Score >= 4 || player2Score >= 4)
            {
                var minusResult = player1Score - player2Score;
                return GetAdvantageScore(minusResult);
            }
            else
            {
                return GetNormalScore();
            }
        }

        private string GetNormalScore()
        {
            var score = string.Empty;
            var tempScore = 0;
            for (var i = 1; i < 3; i++)
            {
                if (i == 1) tempScore = player1Score;
                else { score += "-"; tempScore = player2Score; }
                switch (tempScore)
                {
                    case 0:
                        score += "Love";
                        break;
                    case 1:
                        score += "Fifteen";
                        break;
                    case 2:
                        score += "Thirty";
                        break;
                    case 3:
                        score += "Forty";
                        break;
                }
            }

            return score;
        }

        private static string GetAdvantageScore(int minusResult)
        {
            string score;
            if (minusResult == 1) score = "Advantage player1";
            else if (minusResult == -1) score = "Advantage player2";
            else if (minusResult >= 2) score = "Win for player1";
            else score = "Win for player2";
            return score;
        }

        private string GetEqualScore()
        {
            string score;
            switch (player1Score)
            {
                case 0:
                    score = "Love-All";
                    break;
                case 1:
                    score = "Fifteen-All";
                    break;
                case 2:
                    score = "Thirty-All";
                    break;
                default:
                    score = "Deuce";
                    break;

            }

            return score;
        }
    }
}

