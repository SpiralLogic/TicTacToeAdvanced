namespace TicTacToe.TurnStatus
{
    public class TurnGameOver : ITurnStatus
    {
        public string Describe => "Game is already over!";
    }
}