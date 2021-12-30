```
Program					-> FuncStmt Main_Func | Main_Func
FuncStmt				-> FuncDecl FuncBody
FuncDecl				-> DataType FuncName (ParamList)
FuncName				-> identifier
ParamList				-> Param ParamList' | ParamList'
ParamList'			-> , Param ParamList' | e
Param						-> DataType identifier
DataType				-> int | float | string
FuncBody				-> { Statements RetStmt }
Statements			-> Statement Statements'
Statements'			-> Statement Statements' | e
Statement				-> FuncCall | AssignStmt | DeclStmt | WriteStmt | ReadStmt | RetStmt | IfElseStmt | RepeatStmt | CommentStmt |  e
CommentStmt			-> comment
FuncCall				-> FuncName (ArgList) ;
ArgList					-> Arg ArgList' | ArgList'
ArgList'				-> , Arg ArgList' | e
Arg							-> indentifier
AssignStmt			-> LValue := RValue ;
LValue					-> identifier
RValue					-> string | Expression
Expression			-> Term Expression'
Expression'			-> AddOp Term Expression' | e
AddOp						-> + | -
Term						-> Factor Term'
Term'						-> MulOp Factor Term' | e
MulOp						-> * | /
Factor					-> number | identifier | FuncCall
DeclStmt				-> DataType IdentList ;
IdentList				-> identifier IdentList'
IdentList'			-> , identifier IdentList' | e
WriteStmt				-> write RValue ;
ReadStmt				-> read LValue ;
RetStmt					-> return RValue ;
RepeatStmt			-> repeat Statements until CondStmt
CondStmt				-> Condition CondStmt'
CondStmt'				-> BoolList Condition CondStmt' | e
Condition				-> Expression CondOp Expression
CondOp					-> < | > | = | <>
BoolList				-> && | "||"
IfElseStmt			-> if CondStmt then Statements ElseBlock end
ElseBlock				-> ElIfBlock ElseBlock | else Statments | e
ElIfBlock				-> elseif CondStmt then Statements
MainFunc				-> Datatype main () FuncBody
```
