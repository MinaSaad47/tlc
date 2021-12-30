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
