using System.Runtime.Serialization;

namespace TicTacToe.GameState
{
    [DataContract]  
    public class GameDraw : IGameState
    {
        public string Describe => "Draw";
    }
}