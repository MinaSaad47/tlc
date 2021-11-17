using System;
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

        var winTks = new Window("Tokens") {
            X = Pos.Right(winSrc),
            Y = 1,
            Width = Dim.Fill(),
            Height = Dim.Percent(75),
        };

        var winErr = new Window("Errors") {
            X = Pos.Right(winSrc),
            Y = Pos.Bottom(winTks),
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

        var btnCompile = new Button("Generate Tokens", true) {
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
            winErr.Text = scanner.Error;
        };

        winSrc.Add(tvSrc, btnCompile);
        winTks.Add(tablevTokens);
        top.Add(menu, winSrc, winTks, winErr);
        Application.Run();
    }
}
