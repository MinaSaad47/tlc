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

        TLC.Scanner scanner = new TLC.Scanner();
        scanner.StartScanning(src);

        foreach(TLC.Token token in scanner.Tokens)
        {
            Console.WriteLine($"{token.lex}\t{token.token_type}");
        }
        

        Console.WriteLine(String.Concat(Enumerable.Repeat("=", 80)));
    }
}
