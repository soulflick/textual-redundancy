using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Threading;

namespace TextualRedundancy.Classes
{
    public class TokenChangedEventArgs : EventArgs
    {
        public string Token;
        public bool Added;
        public bool IsSeparator = false;
        public int SynchronousIndex = 0;
    }

    public class Tokenizer
    {
        public delegate void TokenChangedEventHandler(object sender, TokenChangedEventArgs e);
        public static event TokenChangedEventHandler TokenChanged;
        public List<TokenMatch> Matches = null;
        public static Tokenizer Instance = null;

        private TokenClass Token = new TokenClass(TokenType.Pure, @"[^\s]+");
        private TokenClass Separator = new TokenClass(TokenType.Separator, @"[\s]+");

        public int WhiteSpaceSequences = 0;
        public int LengthWhiteSpace = 0;
        public int MatchCount = 0;
        public int LengthUnique = 0;
        public int LengthDuplicate = 0;
        private int SynchronousIndex = -1;

        private readonly Dispatcher Dispatcher = null;
        private readonly char[] Antitoken = new char[] { ' ', '\t', '\r', '\n', '\f', '\v' };

        public Tokenizer()
        {

            Matches = new List<TokenMatch>();
            Token.MatchString = string.Empty;
            Separator.MatchString = string.Empty;
            Dispatcher = AppDispatcher.Dispatcher;
            Instance = this;

            Reset();
        }

        public void Reset()
        {
            MatchCount = 0;
            Matches.Clear();
            LengthWhiteSpace = 0;
        }

        public void FinalizeTokenizer()
        {
            if (!string.IsNullOrEmpty(Token.MatchString))
                TryAdd(Token);
            if (!string.IsNullOrEmpty(Separator.MatchString))
                AddSeparator(Separator);

            Matches = Matches.OrderByDescending(m => m.Amount).ThenBy(n => n.Token).ToList();

        }

        private bool isAntimatch(char c)
        {
            return Antitoken.Any(a => a == c);
        }

        public void Tokenize(string input)
        {
            bool antimatch = false;
            int charpos = 0;

            foreach (char c in input)
            {
                charpos++;
                antimatch = isAntimatch(c);

                if (!Token.IsActive && !antimatch)
                {
                    AddSeparator(Separator);
                    Token.MatchString = c.ToString();
                    Token.Position = (int)Analyzer.Instance.position + charpos;
                    Token.Activate();
                }
                else if (Token.IsActive && !antimatch)
                {
                    Token.MatchString += c;
                    continue;
                }
                else if (Token.IsActive && antimatch)
                {
                    if (!Separator.Match(c))
                        throw new Exception("Separator Mismatch");

                    TryAdd(Token);
                    Token.Deactivate();
                    Separator.MatchString += c;
                }
                else if (Separator.IsActive && !antimatch)
                {
                    Token.Activate();
                    Separator.Deactivate();
                    Token.MatchString = c.ToString();

                    AddSeparator(Separator);

                    if (!Token.Match(c))
                        throw new Exception("Token Mismatch");
                }
                else if (Separator.IsActive && antimatch)
                {
                    Separator.MatchString += c;
                    continue;
                }
                else if (!Separator.IsActive && antimatch)
                {
                    if (Token.Any())
                        TryAdd(Token);

                    Token.Deactivate();
                    Separator.Activate();
                    Separator.MatchString = c.ToString();
                }
            }
        }

        private void AddSeparator(TokenClass sepa)
        {
            MatchCount++;
            SynchronousIndex++;
            string m_str = sepa.MatchString;
            LengthWhiteSpace += m_str.Length;
            WhiteSpaceSequences++;
            sepa.Reset();

            TokenChangedEventArgs args = new TokenChangedEventArgs() { Added = true, IsSeparator = true, Token = m_str, SynchronousIndex = SynchronousIndex };

            Dispatcher.BeginInvoke(DispatcherPriority.Send, new Action(() => {
            TokenChanged?.Invoke(this, args);
            }));
        
        }

        private void TryAdd(TokenClass token)
        {
            MatchCount++;
            SynchronousIndex++;
            var match = Matches.FirstOrDefault(m => m.Token == token.MatchString);
            string m_str = token.MatchString;
            token.Reset();

            if (match != null)
            {
                LengthDuplicate += m_str.Length;
                TokenChangedEventArgs args = new TokenChangedEventArgs() { Added = false, IsSeparator = false, Token = m_str, SynchronousIndex = SynchronousIndex };
                Dispatcher.BeginInvoke(DispatcherPriority.Send, new Action(() => {
                    TokenChanged?.Invoke(this, args);
                }));
                match.Amount++;
                
            }
            else
            {
                LengthUnique += m_str.Length;
                TokenChangedEventArgs args = new TokenChangedEventArgs() { Added = true, IsSeparator = false, Token = m_str, SynchronousIndex = SynchronousIndex };
                Dispatcher.BeginInvoke(DispatcherPriority.Send, new Action(() => {
                    TokenChanged?.Invoke(this, args);
                }));
                match = new TokenMatch() { Token = m_str, Amount = 1 };
                match.Position = token.Position;
                match.Length = m_str.Length;
                Matches.Add(match);
            }

 

        }
    }
}
