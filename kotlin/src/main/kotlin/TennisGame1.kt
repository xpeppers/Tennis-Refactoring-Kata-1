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
        return when {
            playersHaveSameScore() -> {
                scoreOnTie(scorePlayer1)
            }

            scorePlayer1 >= 4 || scorePlayer2 >= 4 -> {
                scoreForVictory(scorePlayer1 - scorePlayer2)
            }

            else -> {
                scoreName(scorePlayer1) + "-" + scoreName(scorePlayer2)
            }
        }
    }

    private fun playersHaveSameScore() = scorePlayer1 == scorePlayer2
}

private fun scoreName(scorePoint: Int): String {
    return when (scorePoint) {
        0 -> "Love"
        1 -> "Fifteen"
        2 -> "Thirty"
        3 -> "Forty"
        else -> ""
    }
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
