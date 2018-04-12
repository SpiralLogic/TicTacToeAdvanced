using System.Runtime.Serialization;

namespace TicTacToe
{
    [DataContract]
    public class Symbol
    {
        [DataMember]
        private readonly char _symbol;

        internal Symbol(char symbol)
        {
            _symbol = symbol;
        }

        public override string ToString()
        {
            return _symbol.ToString();
        }

        public override bool Equals(object obj)
        {
            return obj is Symbol symbol && symbol._symbol == _symbol;
        }

        public override int GetHashCode()
        {
            return _symbol.GetHashCode();
        }

        public static bool operator ==(Symbol symbol1, Symbol symbol2)
        {
            return symbol1?._symbol == symbol2?._symbol;
        }

        public static bool operator !=(Symbol symbol1, Symbol symbol2)
        {
            return !(symbol1 == symbol2);
        }
    }
}