using System.Runtime.Serialization;

namespace TicTacToe
{
    [DataContract]
    public class Player
    {
        [DataMember]
        public string Name { get; private set; }

        [DataMember] public readonly Symbol Symbol;

        public Player(string name, Symbol symbol)
        {
            Name = name;
            Symbol = symbol;
        }

        public Player(string name, char symbol) : this(name, new Symbol(symbol))
        {
        }

        public override int GetHashCode()
        {
            return Symbol.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return obj is Player player && player.Symbol == Symbol;
        }

        public static bool operator ==(Player player1, Player player2)
        {
            return player1?.Symbol == player2?.Symbol;
        }

        public static bool operator !=(Player player1, Player player2)
        {
            return !(player1 == player2);
        }
    }
}