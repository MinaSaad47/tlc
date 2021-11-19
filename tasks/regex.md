# RegEx for all tokens.


| Token                 | RegEx                                                                                                                                             |
|-----------------------|---------------------------------------------------------------------------------------------------------------------------------------------------|
| Number                | <code>[0-9]+(\.[0-9]+)?</code>                                                                                                                    |
| String                | <code>".*"</code>                                                                                                                                 |
| Reserved_Keywords     | <code>int&#124;float&#124;string&#124;read&#124;write&#124;repeat&#124;until&#124;if&#124;elseif&#124;else&#124;then&#124;return&#124;endl</code> |
| Comment               | <code>\/\*.*\*\/</code>                                                                                                                           |
| Identifier            | <code>[a-zA-Z][0-9a-zA-Z]*</code>                                                                                                                 |
| Function_Call         | <code>Idetifier\\(((Identifier,)*Identifier)?\\)</code>                                                                                           |
| Term                  | <code>(Number&#124;Identifier&#124;Function_Call)</code>                                                                                          |
| Asthmatic_Operators   | <code>[+\-*/]</code>                                                                                                                              |
| Equation              | <code>((\(?Term[+\-*/])*\(?Term\)?\)?[+\-*/])*(\(?Term[+\-*/])*\(?Term\)?\)?</code>                                                               |
| Expression            | <code>(String&#124;Term&#124;Equation)</code>                                                                                                     |
| Assignment_Statement  | <code>Identifier:=Expression</code>                                                                                                               |
| Data_Type             | <code>(int&#124;float&#124;string)</code>                                                                                                         |
| Declaration_Statement | <code>Data_Type(Identifier&#124;Assignment_Statement,)*(Identifier&#124;Assignment_Statement);</code>                                             |
| Write_Statement       | <code>write(Expression&#124;endl);</code>                                                                                                         |
| Read_Statement        | <code>readIdentifier;</code>                                                                                                                      |
| Return_Statement      | <code>return(Expression);</code>                                                                                                                  |
| Condition_Operators   | <code>(<&#124;>&#124;=&#124;<>)</code>                                                                                                            |
| Condition             | <code>(Identifier)(Condition_Operator)(Identifier)</code>                                                                                         |
| Boolean_Operators     | <code>(&&&#124;\\&#124;\\&#124;)</code>                                                                                                           |
| Condition_Statement   | <code>((Condition)(Condition_Operator))*(Condition)</code>                                                                                        |
| If_Statement          | <code>if(Condition_Statement)then(Statement)*(elseif)*(else)?end</code>                                                                           |
| Else_If_Statement     | <code>elseif(Statement)*</code>                                                                                                                   |
| Else_Statement        | <code>else(Statement)*</code>                                                                                                                     |
| Repeat_Statement      | <code>repeat(Statements)*untill(Condition_Statement)</code>                                                                                       |
| Function_Name         | <code>(Identifier)</code>                                                                                                                         |
| Parameter             | <code>(Data_Type)(Identifier)</code>                                                                                                              |
| Function_Declaration  | <code>(Data_Type)(Function_Name)\\(((Parameter,)*(Parameter))?\)</code>                                                                           |
| Function_Body         | <code>{(Statements)(Return_Statement)}</code>                                                                                                     |
| Function_Statement    | <code>(Function_Declaration)(Function_Body)</code>                                                                                                |
| Main_Function         | <code>(Data_Type)main\\(\\)(Function_Body)</code>                                                                                                 |
| Program               | <code>(Function_Statement)*(Main_Function)</code>                                                                                                 |

