class TennisGame1(private val player1Name: String, private val player2Name: String) : TennisGame {

    private var m_score1: Int = 0
    private var m_score2: Int = 0

    override fun wonPoint(playerName: String) {
        if (playerName === "player1")
            m_score1 += 1
        else
            m_score2 += 1
    }

    private fun scores_are_equals() : String
    {
        return when (m_score1) {
            0 -> "Love-All"
            1 -> "Fifteen-All"
            2 -> "Thirty-All"
            else -> "Deuce"
        }
    }

    private fun advantage() : String
    {
        val minusResult = m_score1 - m_score2
        return when {
            minusResult == 1 -> "Advantage player1"
            minusResult == -1 -> "Advantage player2"
            minusResult >= 2 -> "Win for player1"
            else -> "Win for player2"
        }
    }

    override fun getScore(): String {
        if (sameScore()) {
            return scores_are_equals()
        } else if (isAdvantage()) {
            return advantage()
        } else {
            val player1Score = getScoreName(m_score1)
            val player2Score = getScoreName(m_score2)
            return player1Score + "-" + player2Score
        }
    }

    private fun getScoreName(score: Int): String {
        return when (score) {
            0 -> "Love"
            1 -> "Fifteen"
            2 -> "Thirty"
            3 -> "Forty"
            else -> ""
        }
    }

    private val advantageScore = 4
    private fun isAdvantage(): Boolean {
        return m_score1 >= advantageScore || m_score2 >= advantageScore
    }

    private fun sameScore() = m_score1 == m_score2
}
