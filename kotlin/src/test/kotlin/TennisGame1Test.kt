import org.junit.Assert.*
import org.junit.Test

class TennisGame1Test {
    @Test
    fun `at the beginning of the game, the score is Love-All`() {
        val tennisGame = TennisGame1("", "")

        assertEquals("Love-All", tennisGame.getScore())
    }

    @Test
    fun `the first player scores a point, then the score is Fifteen-Love`() {
        val tennisGame = TennisGame1("A", "B")
        tennisGame.wonPoint("player1")

        assertEquals("Fifteen-Love", tennisGame.getScore())
    }

    @Test
    fun `The player 1 is in Advantage`() {
        val tennisGame = TennisGame1("player1", "B")
        tennisGame.wonPoint("player1")
        tennisGame.wonPoint("player1")
        tennisGame.wonPoint("player1")

        tennisGame.wonPoint("B")
        tennisGame.wonPoint("B")
        tennisGame.wonPoint("B")

        //Player 1 Advantage
        tennisGame.wonPoint("player1")

        assertEquals("Advantage player1", tennisGame.getScore())
    }

    @Test
    fun `The player 1 wins`() {
        val tennisGame = TennisGame1("player1", "B")

        tennisGame.wonPoint("player1")
        tennisGame.wonPoint("player1")
        tennisGame.wonPoint("player1")
        tennisGame.wonPoint("player1")

        assertEquals("Win for player1", tennisGame.getScore())
    }

    @Test
    fun `The player 2 wins`() {
        val tennisGame = TennisGame1("player1", "B")

        tennisGame.wonPoint("B")
        tennisGame.wonPoint("B")
        tennisGame.wonPoint("B")
        tennisGame.wonPoint("B")

        assertEquals("Win for player2", tennisGame.getScore())
    }

    @Test
    fun `Should score player2, when "player1" doesn't make a point`() {
        val tennisGame = TennisGame1("A", "B")
        tennisGame.wonPoint("A")

        assertEquals("Love-Fifteen", tennisGame.getScore())
    }
}