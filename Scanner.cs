using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLC
{

    public class Token
    {
        public string lex;
        public TK token_type;
        
    }

    public class Scanner
    {
        private List<Token> _tokens = new List<Token>();
        Dictionary<string, TK> ReservedWords = new Dictionary<string, TK>();
        Dictionary<string, TK> Operators = new Dictionary<string, TK>();

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
            Operators.Add("=", TK.Equal);
            Operators.Add("+", TK.PlusOp);
            Operators.Add("-", TK.MinusOp);
            Operators.Add("<", TK.LessThanOp);
            Operators.Add(">", TK.GreaterThanOp);

        }

        public void StartScanning(string src)
        {
            // i: Outer loop to check on lexemes.
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
        }

        void FindTokenClass(string lex)
        {
            TK token_type;
            Token token = new Token();
            token.lex = lex;
            //Is it a reserved word?

            //Is it an identifier?

            //Is it a Constant?

            //Is it an operator?

            //Is it an undefined?

        }

        bool isIdentifier(string lex)
        {
            bool isValid = true;
            // Check if the lex is an identifier or not.

            return isValid;
        }
        bool isConstant(string lex)
        {
            bool isValid = true;
            // Check if the lex is a constant (Number) or not.

            return isValid;
        }

        public List<Token> Tokens { get => _tokens; }

    }
}
