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
                throw new Exception("Player doesn't exist");
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


        public string GetScore()
        {
            string score = "";
            var tempScore = 0;

            if (player1_score == player2_score)
            {
                return GetEvenScore(player1_score);
            }

            if (player1_score >= 4 || player2_score >= 4)
            {
                var minusResult = player1_score - player2_score;
                if (minusResult == 1) score = "Advantage player1";
                else if (minusResult == -1) score = "Advantage player2";
                else if (minusResult >= 2) score = "Win for player1";
                else score = "Win for player2";
            }
            else
            {
                for (var i = 1; i < 3; i++)
                {
                    if (i == 1) tempScore = player1_score;
                    else { score += "-"; tempScore = player2_score; }
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
            }
            return score;
        }
    }
}

