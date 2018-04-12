namespace TicTacToe.TurnStatus
{
    public class CoordinateAlreadyTaken : ITurnStatus
    {
        public string Describe => "Oh no, a piece is already at this coordinate! Try again...";
    }
}