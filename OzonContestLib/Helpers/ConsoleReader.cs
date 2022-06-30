namespace OzonContest.Helpers;

public class ConsoleReader : IReader
{
    public string ReadStr()
        => Console.ReadLine()!;
}