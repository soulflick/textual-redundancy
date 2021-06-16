using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TextualRedundancy.Classes
{
    public enum TokenType
    {
        Pure, Separator, Unknown
    }

    public static class MatchFactory
    {
        public static List<TokenClass> Tokens = new List<TokenClass>();
        public static List<TokenClass> Classes = new List<TokenClass>();
        public static void Add(TokenClass TC)
        {
            Classes.Add(TC);
        }

        public static TokenClass Match(char c)
        {
            TokenClass fc = Classes.FirstOrDefault(C => C.Match(c));
            return fc;

        }
    }

    public class AnyToken : TokenClass
    {
        public AnyToken(TokenType TKT) : base(TKT, string.Empty) {; }
    }


    public class TokenClass
    {
        public int Position = 0;
        public TokenType TokenType = TokenType.Unknown;
        public string regex_str = "";
        public string MatchString = "";
        public bool IsActive = false;

        private Regex regex = null;

        public TokenClass(TokenType TKT, string reg)
        {
            TokenType = TKT;
            regex_str = reg;
            regex = new Regex(regex_str);
        }

        public void Add(char c)
        {
            MatchString += c;
        }

        public void Reset()
        {
            MatchString = string.Empty;
        }

        public bool Any()
        {
            return MatchString.Any();
        }

        public bool Match(string str)
        {
            return (IsActive = regex.IsMatch(str));
        }

        public void Activate()
        {
            IsActive = true;
        }

        public void Deactivate()
        {
            IsActive = false;
        }

        public bool Match(char c)
        {
            return regex.IsMatch(c.ToString());
        }

        public void Add()
        {
            MatchFactory.Tokens.Add(this);
        }

    }
}
