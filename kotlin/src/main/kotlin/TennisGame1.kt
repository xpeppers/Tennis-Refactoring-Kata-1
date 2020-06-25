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
            return scoreOnTie(scorePlayer1)
        } else if (scorePlayer1 >= 4 || scorePlayer2 >= 4) {
            return scoreForVictory(scorePlayer1 - scorePlayer2)
        } else {
            var tempScore: Int
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

    private fun playersHaveSameScore() = scorePlayer1 == scorePlayer2

}

private fun scoreForVictory(differenceBetweenScores: Int): String {
    return when {
        differenceBetweenScores == 1 -> "Advantage player1"
        differenceBetweenScores == -1 -> "Advantage player2"
        differenceBetweenScores >= 2 -> "Win for player1"
        else -> "Win for player2"
    }
}

private fun scoreOnTie(score: Int): String {
    return when (score) {
        0 -> "Love-All"
        1 -> "Fifteen-All"
        2 -> "Thirty-All"
        else -> "Deuce"
    }
}
