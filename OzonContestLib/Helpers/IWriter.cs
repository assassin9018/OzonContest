namespace OzonContest.Helpers;

public interface IWriter
{
    void Write<T>(T value);
    void WriteRange<T>(IEnumerable<T> values, char separator);
}
