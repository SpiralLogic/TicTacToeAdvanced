using TicTacToe;
using TicTacToe.TurnStatus;

namespace TicTacToeWebApp.Models
{
    public class TurnStatusModel : GameModel
    {
        public string TurnStatus { get; }
        
        public TurnStatusModel(Game game, ITurnStatus turnStatus) : base(game)
        {
            TurnStatus = turnStatus.Describe;
        }
    }
}