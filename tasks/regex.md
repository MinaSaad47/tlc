# RegEx for all tokens.


| Token                 | RegEx                                                                                                 |
|-----------------------|-------------------------------------------------------------------------------------------------------|
| Number                | `[0-9]+(\.[0-9]+)?`                                                                                   |
| String                | `".*"`                                                                                                |
| Reserved_Keywords     | `#TODO`                                                                                               |
| Comment               | `\/\*.*\*\/`                                                                                          |
| Identifier            | `[a-zA-Z][0-9a-zA-Z]*`                                                                                |
| Function_Call         | `Idetifier\(((Identifier,)*Identifier)?\)`                                                            |
| Term                  | <code>(Number&#124;Identifier&#124;Function_Call)</code>                                              |
| Asthmatic_Operators   | `[+\-*/]`                                                                                             |
| Equation              | `((\(?Term[+\-*/])*\(?Term\)?\)?[+\-*/])*(\(?Term[+\-*/])*\(?Term\)?\)?`                              |
| Expression            | <code>(String&#124;Term&#124;Equation)</code>                                                         |
| Assignment_Statement  | `Identifier:=Expression`                                                                              |
| Data_Type             | <code>(int&#124;float&#124;string)</code>                                                             |
| Declaration_Statement | <code>Data_Type(Identifier&#124;Assignment_Statement,)*(Identifier&#124;Assignment_Statement);</code> |
| Write_Statement       | <code>write(Expression&#124;endl);</code>                                                             |
| Read_Statement        | `readIdentifier;`                                                                                     |
| Return_Statement      | `returnExpression;`                                                                                   |
| Condition_Operators   | <code>(<&#124;>&#124;=&#124;<>)</code>                                                                |
| Condition             | `IdentifierCondition_OperatorIdentifier`                                                              |
| Boolean_Operators     | <code>(&&&#124;\\&#124;\\&#124;)</code>                                                               |
| Condition_Statement   | `(ConditionCondition_Operator)*Condition`                                                             |

