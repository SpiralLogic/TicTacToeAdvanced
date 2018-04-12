using TicTacToe;
using TicTacToe.TurnStatus;

namespace TicTacToeWebApp.Models
{
    public class TurnStatusModel : GameStateModel
    {
        public string TurnStatus { get; }
        
        public TurnStatusModel(TicTacToeGame game, ITurnStatus turnStatus) : base(game)
        {
            TurnStatus = turnStatus.Describe;
        }
    }
}