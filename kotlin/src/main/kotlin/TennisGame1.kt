class TennisGame1(private val player1Name: String, private val player2Name: String) : TennisGame {

    private var m_score1: Int = 0
    private var m_score2: Int = 0

    override fun wonPoint(playerName: String) {
        if (playerName === "player1")
            m_score1 += 1
        else
            m_score2 += 1
    }

    override fun getScore(): String {
        if (isDraw()) {
            return scoreForDraw()
        }
        if (isAdvantage()) {
            return scoreForAdvantage()
        }
        if (isWinning()) {
            return scoreForWinning()
        }

        var score = ""
        var tempScore = 0
        for (i in 1..2) {
            if (i == 1)
                tempScore = m_score1
            else {
                score += "-"
                tempScore = m_score2
            }
            when (tempScore) {
                0 -> score += "Love"
                1 -> score += "Fifteen"
                2 -> score += "Thirty"
                3 -> score += "Forty"
            }
        }
        return score
    }

    private fun isWinning() = (m_score1 >= 4 || m_score2 >= 4) && (pointsGap() >= 2 || pointsGap() <= -2)

    private fun isAdvantage() = (m_score1 >= 4 || m_score2 >= 4) && (pointsGap() == 1 || pointsGap() == -1)

    private fun scoreForWinning(): String {
        return if (pointsGap() >= 2)
            "Win for player1"
        else
            "Win for player2"
    }

    private fun scoreForAdvantage(): String {
        return if (pointsGap() == 1)
            "Advantage player1"
        else
            "Advantage player2"
    }

    private fun pointsGap(): Int {
        val pointsGap = m_score1 - m_score2
        return pointsGap
    }

    private fun isDraw() = m_score1 == m_score2

    private fun scoreForDraw(): String {
        var score = ""
        when (m_score1) {
            0 -> score = "Love-All"
            1 -> score = "Fifteen-All"
            2 -> score = "Thirty-All"
            else -> score = "Deuce"
        }
        return score
    }
}
