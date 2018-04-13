

namespace TicTacToe.GameState
{
      
    public class GameWon : AbstractGameStateWithPlayer
    {
        public GameWon(Player player) : base(player)
        {
        }

        public override string Describe => $"Well done {Player.Name} you've won the game!";
    }
}