namespace TLC
{
    public enum TK
    {
        Int, Float, String, Identifier, L_Paren, R_Paren, L_Brace, R_Brace, 
        L_Brack, R_Brack, Coma, Colon, SemiColon, Comment, Repeat, AssignOp,
        EqualOp, NotEqualOp, PlusOp, MinusOp, Untill, LessThanOp, GreaterThanOp,
        Return, Write, Read, DivideOp, MultiOp, Endl, Constant, If, Else,
        ElseIf, End, Then, AndOp, OrOp, Main
    }

    public static class RE
    {
        public const string Number = "[0-9]+(.[0-9]+)?";
        public const string Identifier = "[a-zA-Z][0-9a-zA-Z]*";
        public const string String = @"""[^\n]*"""; // single-line string literal.
        public const string Comment = @"\/\*.*\*\/"; // multi-line comment.
    }

	public static class Errors
	{
		public static List<string> Error_List = new List<string>();
	}

    public static class Logger
    {
        static StreamWriter sw = new StreamWriter(@"c:/Users/winPC/Desktop/log.txt");
        public static void Log(string str)
        {
            sw.WriteLine(str);
            sw.Flush();
        }
    }

}
