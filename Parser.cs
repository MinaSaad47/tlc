using System;
using System.Collections.Generic;
using Terminal.Gui.Trees;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLC
{
	public class Node
	{
		public List<Node> Children = new List<Node>();
		
		public string Name;
		public Node(string N)
		{
			this.Name = N;
		}
	}
	public class Parser
	{
		int InputPointer = 0;
		List<Token> TokenStream;
		public  Node root;
		
		public Node StartParsing(List<Token> TokenStream)
		{
			this.InputPointer = 0;
			this.TokenStream = TokenStream;
			root = new Node("Tree");
			root.Children.Add(Program());
			return root;
		}

		Node Program()
		{
			Node program = new Node("Program");
			program.Children.Add(FuncStmt());
			// program.Children.Add(MainFunc());
			// program.Children.Add(match(TK.Dot));
			// MessageBox.Show("Success");
			return program;
		}

		Node FuncStmt()
		{
			Node node = new Node("FuncStmt");
			node.Children.Add(FuncDecl());
			node.Children.Add(FuncBody());

			return node;
		}

		Node FuncDecl()
		{
			Node node = new Node("FuncDecl");
			node.Children.Add(DataType());
			node.Children.Add(FuncName());
			node.Children.Add(match(TK.L_Paren));
			// node.Children.Add(ParamList());
			node.Children.Add(match(TK.R_Paren));
			return node;
		}

		Node FuncName()
		{
			Node node = new Node("FuncName");
			node.Children.Add(match(TK.Identifier));
			return node;
		}

		Node FuncBody()
		{
			Node node = new Node("FuncBody");
			return node;
		}

		Node DataType()
		{
			Node node = new Node("DataType");
			switch (TokenStream[InputPointer].token_type)
			{
			case TK.Int:
				node.Children.Add(match(TK.Int));
				break;
			case TK.Float:
				node.Children.Add(match(TK.Float));
				break;
			case TK.String:
				node.Children.Add(match(TK.String));
				break;
			default:
				return null;
			}
			return node;
		}



		// 
		// Node Header()
		// {
		// 	Node header = new Node("Header");
		// 	// write your code here to check the header sructure
		// 	return header;
		// }
		// Node DeclSec()
		// {
		// 	Node declsec = new Node("DeclSec");
		// 	// write your code here to check atleast the declare sturcure 
		// 	// without adding procedures
		// 	return declsec;
		// }
		// Node Block()
		// {
		// 	Node block = new Node("block");
		// 	// write your code here to match statements
		// 	return block;
		// }

		// Implement your logic here
		Node RValue()
		{
			Node node = new Node("RValue");
			if(TokenStream[InputPointer].token_type==TK.String)
			{
				node.Children.Add(match(TK.String));
			}
			else
			{
				node.Children.Add(Expression());
			}
			return node;
		}
		Node Expression()
		{
			Node node = new Node("Expression");
			node.Children.Add(Term());
			node.Children.Add(ExpressionDash());
			return node ;
		}
		Node ExpressionDash()
		{
			Node node = new Node("ExpressionDash");
			if(TokenStream[InputPointer].token_type==TK.PlusOp || TokenStream[InputPointer].token_type==TK.MinusOp)
			{
				node.Children.Add(AddOp());
				node.Children.Add(Term());
				node.Children.Add(ExpressionDash());
			}
			else
			{
				return null ;
			}
			return node ;
		}
		Node AddOp()
		{
			Node node = new Node("AddOp");
			if(TokenStream[InputPointer].token_type==TK.PlusOp)
			{
				node.Children.Add(match(TK.PlusOp));
			}
			else
			{
				node.Children.Add(match(TK.MinusOp));
			}
			return node ;
		}
		Node Term()
		{
			Node node = new Node("Term");
			node.Children.Add(Factor());
			node.Children.Add(TermDash());
			return node ;
		}
		Node TermDash()
		{
			Node node = new Node("TermDash");
			if(TokenStream[InputPointer].token_type==TK.MultiOp || TokenStream[InputPointer].token_type==TK.DivideOp)
			{
				node.Children.Add(MulOp());
				node.Children.Add(Factor());
				node.Children.Add(TermDash());
			}
			else
			{
				return null ;
			}
			return node ;
		}
		Node MulOp()
		{
			Node node = new Node("MulOp");
			if(TokenStream[InputPointer].token_type==TK.MultiOp)
			{
				node.Children.Add(match(TK.MultiOp));
			}
			else
			{
				node.Children.Add(match(TK.DivideOp));
			}
			return node ;
		}
		Node Factor()
		{
			Node node = new Node("Factor");
				if(TokenStream[InputPointer].token_type==TK.Constant)
				{
					node.Children.Add(match(TK.Constant));
				}
				else if (TokenStream[InputPointer].token_type==TK.Identifier)
				{
					node.Children.Add(match(TK.Identifier));
				}
				else
				{
					node.Children.Add(FuncCall());
				}
				return node ;
		}
		Node DeclStmt()
		{
			Node node = new Node("DeclStmt");
			node.Children.Add(DataType());
			node.Children.Add(IdentList());
			node.Children.Add(match(TK.SemiColon));
			return node ;
		}
		Node IdentList()
		{
			Node node = new Node("IdentList");
			node.Children.Add(match(TK.Identifier));
			node.Children.Add(IdentListDash());
			return node ;
		}
		Node IdentListDash()
		{
			Node node = new Node("IdentListDash");
			if(TokenStream[InputPointer].token_type == TK.Coma)
			{
				node.Children.Add(match(TK.Coma));
				node.Children.Add(match(TK.Identifier));
				node.Children.Add(IdentListDash());
			}
			else
			{
				return null;
			}
			return node ;
		}
		Node WriteStmt()
		{
			Node node = new Node("WriteStmt");
			node.Children.Add(match(TK.Write));
			node.Children.Add(RValue());
			node.Children.Add(match(TK.SemiColon));
			return node ;
		}
		Node ReadStmt()
		{
			Node node = new Node("ReadStmt");
			node.Children.Add(match(TK.Read));
			node.Children.Add(LValue());
			node.Children.Add(match(TK.SemiColon));
			return node ;
		}
		Node RetStmt()
		{
			Node node = new Node("RetStmt");
			node.Children.Add(match(TK.Return));
			node.Children.Add(RValue());
			node.Children.Add(match(TK.SemiColon));
			return node;
		}
		Node RepeatStmt()
		{
			Node node = new Node("RepeatStmt");
			node.Children.Add(match(TK.Repeat));
			node.Children.Add(Statements());
			node.Children.Add(match(TK.Untill));
			node.Children.Add(CondStmt());
			return node;
		}
		Node CondStmt()
		{
			Node node = new Node("CondStmt");
			node.Children.Add(Condition());
			node.Children.Add(CondStmtDash());
			return node;
		}
		Node CondStmtDash()
		{
			Node node = new Node("CondStmtDash");
			if(TokenStream[InputPointer].token_type==TK.AndOp || TokenStream[InputPointer].token_type==TK.OrOp )
			{
				node.Children.Add(BoolList());
				node.Children.Add(Condition());
				node.Children.Add(CondStmtDash());
			}
			else
			{
				return null ;
			}
			return node;
		}
		Node Condition()
		{
			Node node = new Node("Condition");
			node.Children.Add(Expression());
			node.Children.Add(CondOp());
			node.Children.Add(Expression());
			return node;
		}
		Node CondOp()
		{
			Node node = new Node("CondOp");
			switch(TokenStream[InputPointer].token_type)
			{
				case TK.LessThanOp :
					node.Children.Add(match(TK.LessThanOp));
					break;
				case TK.GreaterThanOp :
					node.Children.Add(match(TK.GreaterThanOp));
					break;
				case TK.EqualOp :
					node.Children.Add(match(TK.EqualOp));
					break;
				case TK.NotEqualOp :
					node.Children.Add(match(TK.NotEqualOp));
					break;
			}
			return node;
		}
		Node BoolList()
		{
			Node node = new Node("BoolList");
			if(TokenStream[InputPointer].token_type==TK.AndOp)
			{
				node.Children.Add(match(TK.AndOp));
			}
			else
			{
				node.Children.Add(match(TK.OrOp));
			}
			return node ;
		}
		Node IfElseStmt()
		{
			Node node = new Node("IfElseStmt");
			node.Children.Add(match(TK.If));
			node.Children.Add(CondStmt());
			node.Children.Add(match(TK.Then));
			node.Children.Add(Statements());
			node.Children.Add(ElseBlock());
			node.Children.Add(match(TK.End));
			return node ;
		}
		public Node match(TK ExpectedToken)
		{

			if (InputPointer < TokenStream.Count)
			{
				if (ExpectedToken == TokenStream[InputPointer].token_type)
				{
					InputPointer++;
					Node newNode = new Node(ExpectedToken.ToString());

					return newNode;

				}

				else
				{
					Errors.Error_List.Add("Parsing Error: Expected "
						+ ExpectedToken.ToString() + " and " +
						TokenStream[InputPointer].token_type.ToString() +
						"  found\r\n");
					InputPointer++;
					return null;
				}
			}
			else
			{
				Errors.Error_List.Add("Parsing Error: Expected "
						+ ExpectedToken.ToString()  + "\r\n");
				InputPointer++;
				return null;
			}
		}

		public static TreeNode PrintParseTree(Node root)
		{
			TreeNode tree = new TreeNode("Parse Tree");
			TreeNode treeRoot = PrintTree(root);
			if (treeRoot != null)
				tree.Children.Add(treeRoot);
			return tree;
		}
		static TreeNode PrintTree(Node root)
		{
			if (root == null || root.Name == null)
				return null;
			TreeNode tree = new TreeNode(root.Name);
			if (root.Children.Count == 0)
				return tree;
			foreach (Node child in root.Children)
			{
				if (child == null)
					continue;
				tree.Children.Add(PrintTree(child));
			}
			return tree;
		}
	}
}
