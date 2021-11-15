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

        Console.WriteLine("Tiny SRC:\n");
        Console.WriteLine(src);
    }
}
