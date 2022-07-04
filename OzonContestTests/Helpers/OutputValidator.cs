using OzonContest.Helpers;

namespace OzonContestTests.Helpers;

internal class OutputValidator : IWriter
{
    private readonly string _fileName;
    private readonly StreamReader _streamReader;
    private int _line;
    private bool disposedValue;

    public OutputValidator(string fileName)
    {
        _fileName = fileName;
        _streamReader = new StreamReader(fileName);
    }

    private string ReadStr()
    {
        _line++;
        string result = string.Empty;
        while(string.IsNullOrEmpty(result))
            result = _streamReader.ReadLine() ?? throw new ArgumentNullException(nameof(_streamReader), "End of test file, but there is output from handler.");
        return result;
    }
    public void Write<T>(T value)
    {
        string actual = (value as string) ?? value!.ToString()!;
        if (string.IsNullOrEmpty(actual))
            return;

        string expected = ReadStr();
        Validate(actual, expected);
    }

    public void WriteRange<T>(IEnumerable<T> values, char separator = ' ')
    {
        string expected = ReadStr();
        string actual = string.Join(separator, values);
        Validate(actual, expected);
    }

    protected virtual void Validate(string actual, string expected)
    {
        if (!expected.Equals(actual))
            Fail(actual, expected);
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

internal class OutputSplitValidator : OutputValidator
{
    public OutputSplitValidator(string fileName) : base(fileName)
    {
    }

    protected override void Validate(string actual, string expected)
    {
        string[] splitedEx = expected.Split(' ');
        if (splitedEx.Length > 1)
        {
            string[] splitedAc = actual.Split(' ');
            if (splitedAc.Length != splitedEx.Length)
                Fail(actual, expected);
            HashSet<string> expectedSet = new(splitedEx);
            if (!splitedAc.All(x => expectedSet.Contains(x)))
                Fail(actual, expected);
        }
        else
            base.Validate(actual, expected);
    }
}
