namespace TLC
{
    public enum TK
    {
        Int, Float, String, Identifier, L_Paren, R_Paren, L_Brace, R_Brace, 
        L_Brack, R_Brack, Coma, Colon, SemiColon, Comment, Repeat, AssignOp,
        Equal, PlusOp, MinusOp, Untill, LessThanOp, GreaterThanOp, Return, 
        Write, Read, DivideOp, MultiOp, Endl, Constant, If, Else, ElseIf, Then
    }

    public static class RE
    {
        public const string Number = "[0-9]+(.[0-9]+)?";
        public const string Identifier = "[a-zA-Z][0-9a-zA-Z]*";
    }
}
