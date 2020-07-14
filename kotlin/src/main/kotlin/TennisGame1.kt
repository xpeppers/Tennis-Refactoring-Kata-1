class TennisGame1(private val player1Name: String, private val player2Name: String) : TennisGame {

    private var gameState: GameState = BigGameState()

    override fun wonPoint(playerName: String) {
        gameState.wonPoint(playerName)
    }

    override fun getScore(): String {
        return gameState.score()
    }

    interface GameState {
        fun score(): String
        fun wonPoint(playerName: String): GameState {
            TODO()
        }
    }

    class BigGameState(private var player1Points: Int = 0, private var player2Points: Int = 0) : GameState {
        private var gameState: GameState = Draw()

        override fun wonPoint(playerName: String): GameState {
            if (playerName === "player1")
                player1Points += 1
            else
                player2Points += 1

            gameState = nextGameState(playerName)
            return if (isWinning())
                Winning(playerName)
            else
                this
        }

        private fun nextGameState(playerName: String): GameState {
            var nextGameState: GameState = Normal(player1Points, player2Points)
            if (isDraw()) {
                nextGameState = Draw(player1Points)
            }
            if (isDeuce()) {
                nextGameState = Deuce()
            }
            if (isAdvantage()) {
                nextGameState = Advantage(playerName)
            }
            if (isWinning()) {
                nextGameState = Winning(playerName)
            }
            return nextGameState
        }

        override fun score(): String {
            return gameState.score()
        }

        private fun isWinning() = (player1Points >= 4 || player2Points >= 4) && (pointsGap() >= 2 || pointsGap() <= -2)

        private fun isAdvantage() = (player1Points >= 4 || player2Points >= 4) && (pointsGap() == 1 || pointsGap() == -1)

        private fun pointsGap(): Int = player1Points - player2Points

        private fun isDraw() = (player1Points == player2Points) && player2Points < 3

        private fun isDeuce() = (player1Points == player2Points) && player2Points >= 3
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

    class Winning(private val winningPlayer: String) : GameState {
        override fun wonPoint(playerName: String): GameState {
            return this
        }

        override fun score(): String {
            return "Win for $winningPlayer"
        }
    }

    class Advantage(private val playerInAdvantage: String) : GameState {

        override fun score(): String {
            return "Advantage $playerInAdvantage"
        }
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

}
