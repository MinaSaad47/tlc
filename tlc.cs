namespace TLC
{
    public enum TK
    {
        Int, Float, String, Identifier, L_Paren, R_Paren, L_Brace, R_Brace, 
        L_Brack, R_Brack, Coma, Colon, SemiColon, Comment, Repeat, AssignOp,
        EqualOp, NotEqualOp, PlusOp, MinusOp, Untill, LessThanOp, GreaterThanOp,
        Return, Write, Read, DivideOp, MultiOp, Endl, Constant, If, Else,
        ElseIf, End, Then, AndOp, OrOp
    }

    public static class RE
    {
        public const string Number = "[0-9]+(.[0-9]+)?";
        public const string Identifier = "[a-zA-Z][0-9a-zA-Z]*";
        public const string String = @"""((\\[^\n]|[^""\n])*)""";
        public const string Comment = @"/\*(.*?)\*/";
    }
}
