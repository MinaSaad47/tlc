using System;
using Terminal.Gui;
using Terminal.Gui;
using NStack;
using System.Data;
using System.IO;


class MainClass
{
	public static void Main(string[] args)
	{

		Application.Init();
		var top = Application.Top;

		var winSrc = new Window("Tiny Source") {
			X = 0,
			Y = 1,
			Width = Dim.Percent(50),
			Height = Dim.Fill(),
		};

		var menu = new MenuBar (new MenuBarItem [] {
			new MenuBarItem ("_File", new MenuItem [] {
				new MenuItem ("_Quit", "", () => { 
					Application.RequestStop ();
				})
			}),
		});

		var tabRes = new TabView() {
			X = Pos.Percent(50),
			Y = 0,
			Width = Dim.Fill(),
			Height = Dim.Percent(75),
		};

		var winTK = new Window() {
			X = 0,
			Y = 0,
			Width = Dim.Fill(),
			Height = Dim.Fill(),
		};

		var winPT = new Window() {
			X = 0,
			Y = 0,
			Width = Dim.Fill(),
			Height = Dim.Fill(),
		};

		var tabTK = new TabView.Tab("Tokens", winTK);
		var tabPT = new TabView.Tab("Parser Tree", winPT);

		var winErr = new Window("Errors") {
			X = Pos.Right(winSrc),
			Y = Pos.Bottom(tabRes),
			Width = Dim.Fill(),
			Height = Dim.Fill(),
			ColorScheme = Colors.Error
		};

		var tvSrc = new TextView() {
			X = 1,
			Y = 1,
			Width = Dim.Fill(),
			Height = Dim.Fill() - 1
		};

		if (args.Length > 0)
		{
			tvSrc.Text = File.ReadAllText(args[0]);
		}

		var tablevTokens = new TableView() {
			X = 1,
			Y = 1,
			Width = Dim.Fill(),
			Height = Dim.Fill()
		};

		var treeSyntax = new TreeView() {
			X = 1,
			Y = 1,
			Width = Dim.Fill(),
			Height = Dim.Fill()
		};

		var btnCompile = new Button("Compile", true) {
			X = Pos.Center(),
			Y = Pos.Bottom(tvSrc),
		};

		btnCompile.Clicked += () => {
			string src = tvSrc.Text.ToString();
			TLC.Scanner scanner = new TLC.Scanner();
			scanner.StartScanning(src);


			var dt = new DataTable();
			dt.Columns.Add("lexem");
			dt.Columns.Add("token");

			foreach (var token in scanner.Tokens)
			{
				dt.Rows.Add(token.lex, token.token_type.ToString());
			}

			tablevTokens.Table = dt;
			if (!winErr.Text.IsEmpty) {
				winErr.Clear();
			}
			winErr.Text = scanner.Error;
		};

		winSrc.Add(tvSrc, btnCompile);
		winTK.Add(tablevTokens);
		winPT.Add(treeSyntax);
		tabRes.AddTab(tabTK, true);
		tabRes.AddTab(tabPT, false);
		top.Add(menu, winSrc, tabRes, winErr);
		Application.Run();
	}
}
