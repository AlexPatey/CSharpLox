using CSharpLox.Enums;

namespace CSharpLox.Scanning
{
    public class Token(TokenType type, string lexeme, object? literal, int line)
    {
        private readonly TokenType _type = type;
        private readonly string _lexeme = lexeme;
        private readonly object? _literal = literal;
        private readonly int _line = line;

        public override string ToString()
        {
            return $"{_type} {_lexeme} {_literal}";
        }
    }
}
