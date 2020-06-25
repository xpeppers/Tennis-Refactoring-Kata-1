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
        if( m_score1 >= 3 )
        {
            return "Deuce"
        }
        return getScoreName(m_score1) + "-All"
    }

    private fun advantage() : String
    {
        val minusResult = m_score1 > m_score2
        if (m_score1 > m_score2) {
            if (m_score1 - m_score2 > 1) {
                return "Win for player1"
            }
            else return "Advantage player1"
        }
        else {
            if (m_score2 - m_score1 > 1) {
                return "Win for player2"
            } else return "Advantage player2"
        }
    }

    override fun getScore(): String {
        return when {
            sameScore() -> scores_are_equals()
            isAdvantage() -> advantage()
            else -> {
                val player1Score = getScoreName(m_score1)
                val player2Score = getScoreName(m_score2)
                return "$player1Score-$player2Score"
            }
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
