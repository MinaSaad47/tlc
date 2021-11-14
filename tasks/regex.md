# RegEx for all tokens.


| Token      | RegEx                                                                    |       |          |
|------------|--------------------------------------------------------------------------|-------|----------|
| Number     | `[0-9]+(\.[0-9]+)?`                                                      |       |          |
| String     | `".*"`                                                                   |       |          |
| Comment    | `\/\*.*\*\/`                                                             |       |          |
| Identifier | `[a-zA-Z][0-9a-zA-Z]*`                                                   |       |          |
| Func_Call  | `Idetifier\(((Identifier,)*Identifier)?\)`                               |       |          |
| Term       | <code>[Number&#124;Identifier&#124;Func_Call]</code>                     |       |          |
| Arth_Ops   | `[+\-*/]`                                                                |       |          |
| Equation   | `((\(?Term[+\-*/])*\(?Term\)?\)?[+\-*/])*(\(?Term[+\-*/])*\(?Term\)?\)?` |       |          |
| Expression | <code>String&#124;Term&#124;Equation</code>                              |       |          |
| Assin_Stat | `Identifier:=Expression`                                                 |       |          |
| DataType   | <code>[int&#124;float&#124;string]</code>                                |       |          |
| Dec_Stat   |                                                                          |       |          |
