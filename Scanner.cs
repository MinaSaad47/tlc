using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace TLC
{

    public class Token
    {
        public string lex;
        public TK token_type;

        public Token(){}
        
        public Token(string lexeme, TK tokenType)
        {
            lex = lexeme;
            token_type = token_type;
        }
    }

    public class Scanner
    {
        private List<Token> _tokens = new List<Token>();
        Dictionary<string, TK> ReservedWords = new Dictionary<string, TK>();
        Dictionary<string, TK> Operators = new Dictionary<string, TK>();
        private string _error = String.Empty;

        public Scanner()
        {
            ReservedWords.Add("int", TK.Int);
            ReservedWords.Add("float", TK.Float);
            ReservedWords.Add("string", TK.String);
            ReservedWords.Add("repeat", TK.Repeat);
            ReservedWords.Add("untill", TK.Untill);
            ReservedWords.Add("return ", TK.Return);
            ReservedWords.Add("write", TK.Write);
            ReservedWords.Add("read", TK.Read);
            ReservedWords.Add("endl", TK.Endl);
            ReservedWords.Add("if", TK.If);
            ReservedWords.Add("else", TK.Else);
            ReservedWords.Add("elseIf", TK.ElseIf);
            ReservedWords.Add("then", TK.Then);

            Operators.Add(":", TK.Colon);
            Operators.Add(";", TK.SemiColon);
            Operators.Add(",", TK.Coma);
            Operators.Add("(", TK.L_Paren);
            Operators.Add(")", TK.R_Paren);
            Operators.Add("{", TK.L_Brace);
            Operators.Add("}", TK.R_Brace);
            Operators.Add("[", TK.L_Brack);
            Operators.Add("]", TK.R_Brack);
            Operators.Add("/", TK.DivideOp);
            Operators.Add("*", TK.MultiOp);
            Operators.Add(":=", TK.AssignOp);
            Operators.Add("=", TK.EqualOp);
            Operators.Add("+", TK.PlusOp);
            Operators.Add("-", TK.MinusOp);
            Operators.Add("<", TK.LessThanOp);
            Operators.Add(">", TK.GreaterThanOp);
            Operators.Add("<>", TK.NotEqualOp);

        }

        public void StartScanning(string src)
        {
            // i: Outer loop to check on lexemes.
            /*
            for (int i = 0; i < src.Length; i++)
            {
                // j: Inner loop to check on each character in a single lexeme.
                int j = i;
                char CurrentChar = src[i];
                string CurrentLexeme = CurrentChar.ToString();

                if (CurrentChar == ' ' || CurrentChar == '\r' || CurrentChar == '\n')
                    continue;

                if (char.IsLetter(CurrentChar))
                {
                    // The possible Token Classes that begin with a character are
                    // an Idenifier or a Reserved Word.

                    // (1) Update the CurrentChar and validate its value.

                    // (2) Iterate to build the rest of the lexeme while satisfying the
                    // conditions on how the Token Classes should be.
                        // (2.1) Append the CurrentChar to CurrentLexeme.
                        // (2.2) Update the CurrentChar.

                    // (3) Call FindTokenClass on the CurrentLexeme.

                    // (4) Update the outer loop pointer (i) to point on the next lexeme.
                    
                }
                else if (char.IsDigit(CurrentChar))
                {

                }
                else if (CurrentChar == '{')
                {

                }
                else
                {

                }
            }
            */

            string lexeme = string.Empty;

            for (int i = 0; i < src.Length; i++)
            {
                char ch = src[i];


                if (Char.IsLetterOrDigit(ch) || ch == '.')
                {
                    lexeme += ch;
                }
                else
                {
                    if (!String.IsNullOrEmpty(lexeme))
                    {
                        FindTokenClass(lexeme);
                        lexeme = String.Empty;
                    }

                    if (isWhiteSpace(ch))
                        continue;

                    if (src[i] == '/' && src[i + 1] == '*')
                    {
                        int j;
                        for (j = i; j < src.Length; j++)
                        {
                            lexeme += src[j]; 

                            if (src[j] == '*' && src[j + 1] == '/')
                            {
                                lexeme += src[j + 1];
                                break;
                            }
                        }
                        FindTokenClass(lexeme);
                        lexeme = String.Empty;
                        i = j + 2;
                    }
                    else if (src[i] == '\"')
                    {
                        int j;
                        for (j = i; j < src.Length; j++)
                        {
                            lexeme += src[j];
                            if (src[j + 1] == '\"')
                            {
                                lexeme += src[j + 1];
                                break;
                            }
                        }
                        FindTokenClass(lexeme);
                        lexeme = String.Empty;
                        i = j + 1;
                    }
                    else 
                    {
                        Token opToken = new Token();
                        if ((src[i] == ':' && src[i + 1] == '=') ||
                            (src[i] == '&' && src[i + 1] == '&') ||
                            (src[i] == '|' && src[i + 1] == '|') ||
                            (src[i] == '<' && src[i + 1] == '>'))
                        {
                            opToken.lex = $"{src[i]}{src[i + 1]}";
                            opToken.token_type = Operators[opToken.lex];
                            i++;
                        }
                        else if (Operators.ContainsKey(Char.ToString(ch)))
                        {
                            opToken.lex = Char.ToString(ch);
                            opToken.token_type = Operators[Char.ToString(ch)];

                        }
                        else 
                        {
                            _error += $"Invalid Lexem:\n{ch}\n\n";
                            continue;
                        }

                        _tokens.Add(opToken);
                    }
                
                }
            }
            
            if (!String.IsNullOrEmpty(lexeme))
                FindTokenClass(lexeme);
        }

        void FindTokenClass(string lex)
        {
            TK token_type;
            Token token = new Token();
            token.lex = lex;
            //Is it a reserved word?
            if (ReservedWords.ContainsKey(lex))
            {
                token.token_type = ReservedWords[lex];
                _tokens.Add(token);
            }
            else if (isIdentifier(lex))
            {
                token.token_type = TK.Identifier;
                _tokens.Add(token);
            }
            else if (isConstant(lex))
            {
                token.token_type = TK.Constant;
                _tokens.Add(token);
            }
            else if (isComment(lex))
            {
                token.token_type = TK.Comment;
                _tokens.Add(token);
            }
            else if (isString(lex))
            {
                token.token_type = TK.String;
                _tokens.Add(token);
            }
            else
            {
                _error += $"Invalid Lexem:\n{lex}\n\n";
            }
            //Is it an identifier?

            //Is it a Constant?

            //Is it an operator?

            //Is it an undefined?

            
        }

        bool isIdentifier(string lex)
        {
            // Check if the lex is an identifier or not.
            Regex re = new Regex($"^{RE.Identifier}$", RegexOptions.Compiled);  

            return re.IsMatch(lex);
        }
        bool isConstant(string lex)
        {
            // Check if the lex is a constant (Number) or not.
            Regex re = new Regex($"^{RE.Number}$", RegexOptions.Compiled);  

            return re.IsMatch(lex);
        }
        bool isComment(string lex)
        {
            Regex re = new Regex($"^{RE.Comment}$", RegexOptions.Compiled);
            return re.IsMatch(lex);
        }
        bool isString(string lex)
        {
            Regex re = new Regex($"^{RE.String}$", RegexOptions.Compiled);

            return re.IsMatch(lex);
        }

        bool isWhiteSpace(char ch)
        {
            return (ch == ' ' || ch == '\r' || ch == '\n');
        }

        public List<Token> Tokens { get => _tokens; }
        public String Error { get => _error; }

    }
}

