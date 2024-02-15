using OzonContest.Helpers;

namespace OzonContestTests.Helpers;

internal class OutputValidator : IWriter, IDisposable
{
    private readonly string _fileName;
    private readonly StreamReader _streamReader;
    private readonly int _startTimeInTicks;
    private readonly int _timeLimitInSeconds;
    private int _line;
    private bool disposedValue;

    private const int MSecInOneSecond = 1000;

    public OutputValidator(string fileName, int timeLimit)
    {
        _fileName = fileName;
        _streamReader = new StreamReader(fileName);
        _timeLimitInSeconds = timeLimit;
        _startTimeInTicks = Environment.TickCount;
    }

    private string ReadStr()
    {
        _line++;
        string result = string.Empty;
        while (string.IsNullOrEmpty(result))
            result = _streamReader.ReadLine() ?? throw new ArgumentNullException(nameof(_streamReader), "End of test file, but there is output from handler.");
        return result;
    }
    public void Write<T>(T value)
    {
        string actual = (value as string) ?? value!.ToString()!;
        if (string.IsNullOrEmpty(actual))
            return;

        string expected = ReadStr();
        ValidateExecutionTime();
        Validate(actual, expected);
    }

    public void WriteRange<T>(IEnumerable<T> values, char separator = ' ')
    {
        string expected = ReadStr();
        string actual = string.Join(separator, values);

        ValidateExecutionTime();
        Validate(actual, expected);
    }

    protected virtual void Validate(string actual, string expected)
    {
        if (!expected.Trim().Equals(actual.Trim()))
            Fail(actual, expected);
    }

    private void ValidateExecutionTime()
    {
        if (Environment.TickCount > _startTimeInTicks + _timeLimitInSeconds * MSecInOneSecond)
            throw new AnswerValidationException($"Time limit excited. Expected execution time - {_timeLimitInSeconds} sec. File - {_fileName}.");
    }

    internal void EnsureAllDataRequested()
    {
        while (!_streamReader.EndOfStream)
        {
            string tStr = _streamReader.ReadLine()!;
            if (!string.IsNullOrEmpty(tStr))
                throw new AnswerValidationException($"Not all answers receawed. Expected - {tStr}, file - {_fileName}, line - {_line}.");
        }
    }

    protected void Fail(string actual, string expected)
        => throw new AnswerValidationException($"expected - {expected}, actual - {actual}, file - {_fileName}, line - {_line}.");

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                _streamReader.Dispose();
            }

            disposedValue = true;
        }
    }

    public void Dispose()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}