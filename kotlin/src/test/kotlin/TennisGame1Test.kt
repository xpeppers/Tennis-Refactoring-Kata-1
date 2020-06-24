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
}