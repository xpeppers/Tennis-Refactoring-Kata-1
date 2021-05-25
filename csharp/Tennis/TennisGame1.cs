using System;

namespace Tennis
{
    class TennisGame1 : ITennisGame
    {
        private int player1_score = 0;
        private int player2_score = 0;
        private string player1Name;
        private string player2Name;

        public TennisGame1(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

        public void WonPoint(string playerName)
        {
            if (playerName.Equals(this.player1Name, StringComparison.CurrentCultureIgnoreCase))
                player1_score += 1;
            else if (playerName.Equals(this.player2Name, StringComparison.CurrentCultureIgnoreCase))
                player2_score += 1;
            // TODO: add a new test for this condition
            else
                throw new Exception(string.Format("Player '{0}' doesn't exist", playerName));
        }

        public string GetScore()
        {
            if (player1_score == player2_score)
            {
                return GetEvenScore(player1_score);
            }

            if (player1_score >= 4 || player2_score >= 4)
            {
                return GetAdvantageScore();
            }

            return GetScoreNotEvenBeforeForty();
        }

        private string GetScoreNotEvenBeforeForty()
        {
            return string.Format("{0}-{1}", GetSinglePlayerScore(player1_score), GetSinglePlayerScore(player2_score));
        }

        private string GetSinglePlayerScore(int playerScore)
        {
            string score;
            switch (playerScore)
            {
                case 0:
                    score = "Love";
                    break;
                case 1:
                    score = "Fifteen";
                    break;
                case 2:
                    score = "Thirty";
                    break;
                case 3:
                    score = "Forty";
                    break;
                default:
                    score = "";
                    break;
            }
            return score;
        }

        private string GetEvenScore(int player1_score)
        {
            string score = player1_score switch
            {
                0 => "Love-All",
                1 => "Fifteen-All",
                2 => "Thirty-All",
                _ => "Deuce",
            };

            return score;
        }


        private string GetAdvantageScore()
        {
            int scoreDifference = player1_score - player2_score;

            string score = scoreDifference switch
            {
                1 => "Advantage " + player1Name,
                -1 => "Advantage " + player2Name,
                _ => scoreDifference >= 2 ? "Win for " + player1Name : "Win for " + player2Name
            };

            return score;
        }
    }
}




