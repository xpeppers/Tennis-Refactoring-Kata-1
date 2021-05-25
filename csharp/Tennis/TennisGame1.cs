using System;
using System.ComponentModel.DataAnnotations;

namespace Tennis
{
    class TennisGame1 : ITennisGame
    {
        private const string PLAYER1 = "player1";
        private int player1Score = 0;
        private int player2Score = 0;

        [Obsolete]
        public TennisGame1(string player1Name, string player2Name)
        {
        }

        public TennisGame1()
        {
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
            if (IsEqualScore())
            {
                return GetEqualScore(player1Score);
            }
            else if (IsAdvantages())
            {
                var minusResult = player1Score - player2Score;
                return GetAdvantageScore(minusResult);
            }
            else
            {
                return GetNormalScore();
            }
        }

        private bool IsAdvantages()
        {
            return player1Score >= 4 || player2Score >= 4;
        }

        private bool IsEqualScore()
        {
            return player1Score == player2Score;
        }

        private string GetNormalScore()
        {
            return $"{GetSingleScore(player1Score)}-{GetSingleScore(player2Score)}";
        }


        private static string GetAdvantageScore(int minusResult)
        {
            string score;
            switch (minusResult)
            {
                case -1:
                    score = "Advantage player2";
                    break;
                case 1:
                    score = "Advantage player1";
                    break;
                case 2:
                case 3:
                case 4:
                    score = "Win for player1";
                    break;
                default:
                    score = "Win for player2";
                    break;
            }
            return score;
        }

        static private string GetSingleScore(int scoreAsValue)
        {
            string tempScore = string.Empty;
            switch (scoreAsValue)
            {
                case 0:
                    tempScore = "Love";
                    break;
                case 1:
                    tempScore = "Fifteen";
                    break;
                case 2:
                    tempScore = "Thirty";
                    break;
                case 3:
                    tempScore = "Forty";
                    break;
            }

            return tempScore;
        }

        static private string GetEqualScore(int pScore)
        {
            string score;
            switch (pScore)
            {
                case 0:
                case 1:
                case 2:
                    score = $"{GetSingleScore(pScore)}-All";
                    break;
                default:
                    score = "Deuce";
                    break;

            }

            return score;
        }
    }
}

