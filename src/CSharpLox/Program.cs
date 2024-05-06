using CSharpLox.Enums;
using CSharpLox.Scanning;

internal class Program
{
    private static bool _hadError = false;

    private static void Main(string[] args)
    {
        if (args.Length > 1) 
        {
            Console.WriteLine("Too many arguments provided");
            Environment.Exit((int)ExitCode.BadArguments);
        }
        else if (args.Length == 1)
        {
            RunFile(args[0]);
        }
        else
        {
            RunPrompt();
        }

        if (_hadError)
        {
            Environment.Exit((int)ExitCode.Error);
        }

        Environment.Exit((int)ExitCode.NoError);
    }
    public static void Error(int line, string message)
    {
        Report(line, string.Empty, message);
    }

    private static void RunFile(string filePath)
    {
        if (!File.Exists(filePath)) 
        {
            Environment.Exit((int)ExitCode.BadArguments);
        }

        var loxScript = File.ReadAllText(filePath);

        Run(loxScript);
    }

    private static void RunPrompt()
    {
        do
        {
            Console.Write(">");
            var line = Console.ReadLine();

            if (line is null || string.IsNullOrWhiteSpace(line))
            {
                break;
            }

            Run(line);
        } 
        while (true);
    }

    private static void Run(string source)
    {
        var scanner = new Scanner(source);
        var tokens = scanner.ScanTokens();

        foreach (var token in tokens)
        {
            Console.WriteLine(token.ToString());
        }
    }

    private static void Report(int line, string where, string message)
    {
        Console.WriteLine($"[line {line}] Error {where}: {message}");
        _hadError = true;
    }
}