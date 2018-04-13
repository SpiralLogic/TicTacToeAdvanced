

namespace TicTacToe.GameState
{
      
    public abstract class AbstractGameStateWithPlayer : IGameState
    {
          
        protected readonly Player Player;

        internal AbstractGameStateWithPlayer(Player player)
        {
            Player = player;
        }

        public abstract string Describe { get; }
    }
}