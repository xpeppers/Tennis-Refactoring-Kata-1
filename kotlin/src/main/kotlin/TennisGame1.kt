class TennisGame1(private val player1Name: String, private val player2Name: String) : TennisGame {

    private var scorePlayer1: Int = 0
    private var scorePlayer2: Int = 0

    override fun wonPoint(playerName: String) {
        if (playerName === "player1")
            scorePlayer1 += 1
        else
            scorePlayer2 += 1
    }

    override fun getScore(): String {
        var score = ""
        if (playersHaveSameScore()) {
            score = getPippo(scorePlayer1)
        } else if (scorePlayer1 >= 4 || scorePlayer2 >= 4) {
            val minusResult = scorePlayer1 - scorePlayer2
            if (minusResult == 1)
                score = "Advantage player1"
            else if (minusResult == -1)
                score = "Advantage player2"
            else if (minusResult >= 2)
                score = "Win for player1"
            else
                score = "Win for player2"
        } else {
            var tempScore = 0
            for (i in 1..2) {
                if (i == 1)
                    tempScore = scorePlayer1
                else {
                    score += "-"
                    tempScore = scorePlayer2
                }
                when (tempScore) {
                    0 -> score += "Love"
                    1 -> score += "Fifteen"
                    2 -> score += "Thirty"
                    3 -> score += "Forty"
                }
            }
        }
        return score
    }

    private fun getPippo(score: Int): String {
        return when (score) {
            0 -> "Love-All"
            1 -> "Fifteen-All"
            2 -> "Thirty-All"
            else -> "Deuce"
        }
    }

    private fun playersHaveSameScore() = scorePlayer1 == scorePlayer2
}
