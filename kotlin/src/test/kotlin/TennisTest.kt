import org.junit.Assert
import org.junit.Assert.assertTrue
import org.junit.Test


class TennisTest {
    
    @Test
    fun `one point player1`() {
        val game = TennisGame1("player1", "player2")
        game.wonPoint("player1")
        Assert.assertEquals("Fifteen-Love", game.getScore())
    }

    @Test
    fun `same point`() {
        val game = TennisGame1("player1", "player2")
        game.wonPoint("player1")
        game.wonPoint("player2")
        Assert.assertEquals("Fifteen-All", game.getScore())
    }

    @Test
    fun `no one score`() {
        val game = TennisGame1("player1", "player2")
        Assert.assertEquals("Love-All", game.getScore())
    }

    @Test
    fun `same point thirty-all`() {
        val game = TennisGame1("player1", "player2")
        game.wonPoint("player1")
        game.wonPoint("player1")
        game.wonPoint("player2")
        game.wonPoint("player2")
        Assert.assertEquals("Thirty-All", game.getScore())
    }
    @Test
    fun `same point deuce`() {
        val game = TennisGame1("player1", "player2")
        game.wonPoint("player1")
        game.wonPoint("player1")
        game.wonPoint("player2")
        game.wonPoint("player2")
        game.wonPoint("player1")
        game.wonPoint("player2")
        Assert.assertEquals("Deuce", game.getScore())
    }
    @Test
    fun `same point Advantage player2`() {
        val game = TennisGame1("player1", "player2")
        game.wonPoint("player1")
        game.wonPoint("player1")
        game.wonPoint("player2")
        game.wonPoint("player2")
        game.wonPoint("player1")
        game.wonPoint("player2")
        game.wonPoint("player2")
        Assert.assertEquals("Advantage player2", game.getScore())
    }
}
