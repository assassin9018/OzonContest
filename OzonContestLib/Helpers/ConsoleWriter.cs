namespace OzonContest.Helpers;

public class ConsoleWriter : IWriter
{
    public void Write<T>(T value)
        => Console.WriteLine(value?.ToString());

    public void WriteRange<T>(IEnumerable<T> arr, char separator = ' ')
        => Console.WriteLine(string.Join(' ', arr));
}
