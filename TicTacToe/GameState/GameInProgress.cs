using System.Runtime.Serialization;

namespace TicTacToe.GameState
{
    [DataContract]  
    public class GameInProgress : AbstractGameStateWithPlayer
    {
        public GameInProgress(Player player) : base(player)
        {
        }

        public override string Describe => $"{Player.Name} enter a coord x,y to place your {Player.Symbol} or enter 'q' to give up";
    }
}