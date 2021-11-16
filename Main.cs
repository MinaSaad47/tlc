using System.IO;

public class MainClass
{
    public static void Main(string[] args)
    {
        if (args.Length < 1)
        {
            Console.Error.WriteLine("Expected one argument");
            Console.Error.WriteLine($"Usage: dotnet run -- <src-file>");
            
            Environment.Exit(-1);
        }
        
        string src = File.ReadAllText(args[0]);

        Console.Write(String.Concat(Enumerable.Repeat("=", 33)));
        Console.Write("Tiny SRC");
        Console.WriteLine(String.Concat(Enumerable.Repeat("=", 33)));

        Console.WriteLine(src);

        Console.Write(String.Concat(Enumerable.Repeat("=", 37)));
        Console.Write("Tokens");
        Console.WriteLine(String.Concat(Enumerable.Repeat("=", 37)));

        TLC.Scanner scanner = new TLC.Scanner();
        scanner.StartScanning(src);

        foreach(TLC.Token token in scanner.Tokens)
        {
            Console.WriteLine("{0,-50}|{1,-15}", token.lex, token.token_type.ToString());
            Console.WriteLine(String.Concat(Enumerable.Repeat("-", 80)));
        }

        if (!String.IsNullOrEmpty(scanner.Error))
        {
            Console.Write(String.Concat(Enumerable.Repeat("=", 37)));
            Console.Write("Errors");
            Console.WriteLine(String.Concat(Enumerable.Repeat("=", 37)));
            Console.WriteLine(scanner.Error);
        }

    }
}
