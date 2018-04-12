namespace TicTacToe.TurnStatus
{
    public class CoordinateInvalid : ITurnStatus
    {
        public string Describe => "Invalid move!";
    }
}