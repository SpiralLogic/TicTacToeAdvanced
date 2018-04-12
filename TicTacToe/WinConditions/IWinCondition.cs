namespace TicTacToe.WinConditions
{
    internal interface IWinCondition
    {
        bool HasWon(Symbol player, Board board);
    }
}