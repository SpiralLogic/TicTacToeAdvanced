using System.Runtime.Serialization;

namespace TicTacToe.GameState
{
    [DataContract]  
    public abstract class AbstractGameStateWithPlayer : IGameState
    {
        [DataMember]  
        protected readonly Player Player;

        internal AbstractGameStateWithPlayer(Player player)
        {
            Player = player;
        }

        public abstract string Describe { get; }
    }
}