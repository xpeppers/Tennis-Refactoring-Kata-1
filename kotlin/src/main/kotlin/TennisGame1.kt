class TennisGame1(private val player1Name: String, private val player2Name: String) : TennisGame {

    private var player1Points: Int = 0
    private var player2Points: Int = 0
    private var gameState: GameState = Draw()

    override fun wonPoint(playerName: String) {
        if (playerName === "player1")
            player1Points += 1
        else
            player2Points += 1

        gameState = nextGameState()
    }

    override fun getScore(): String {
        return gameState.score()
    }

    private fun nextGameState(): GameState {
        var nextGameState: GameState = Normal(player1Points, player2Points)
        if (isDraw()) {
            nextGameState = Draw(player1Points)
        }
        if (isDeuce()) {
            nextGameState = Deuce()
        }
        if (isAdvantage()) {
            nextGameState = Advantage(player1Points, player2Points)
        }
        if (isWinning()) {
            nextGameState = Winning(player1Points, player2Points)
        }
        return nextGameState
    }

    interface GameState {
        fun score(): String
    }

    class Normal(private val player1Points: Int, private val player2Points: Int) : GameState {
        override fun score() = scoreForPlayer(player1Points) + "-" + scoreForPlayer(player2Points)

        private fun scoreForPlayer(points: Int): String {
            return when (points) {
                0 -> "Love"
                1 -> "Fifteen"
                2 -> "Thirty"
                3 -> "Forty"
                else -> ""
            }
        }
    }

    class Winning(private val player1Points: Int, private val player2Points: Int) : GameState {
        override fun score(): String {
            return if (pointsGap() >= 2)
                "Win for player1"
            else
                "Win for player2"
        }

        private fun pointsGap(): Int = player1Points - player2Points
    }

    class Advantage(private val player1Points: Int, private val player2Points: Int) : GameState {
        override fun score(): String {
            return if (pointsGap() == 1)
                "Advantage player1"
            else
                "Advantage player2"
        }

        private fun pointsGap(): Int = player1Points - player2Points
    }

    class Deuce : GameState {
        override fun score(): String = "Deuce"
    }

    class Draw(private val player1Points: Int = 0) : GameState {
        override fun score(): String = when (player1Points) {
            0 -> "Love-All"
            1 -> "Fifteen-All"
            2 -> "Thirty-All"
            else -> ""
        }
    }

    private fun isWinning() = (player1Points >= 4 || player2Points >= 4) && (pointsGap() >= 2 || pointsGap() <= -2)

    private fun isAdvantage() = (player1Points >= 4 || player2Points >= 4) && (pointsGap() == 1 || pointsGap() == -1)

    private fun pointsGap(): Int = player1Points - player2Points

    private fun isDraw() = (player1Points == player2Points) && player2Points < 3

    private fun isDeuce() = (player1Points == player2Points) && player2Points >= 3

}
