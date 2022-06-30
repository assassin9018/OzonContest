using OzonContest.Helpers;

namespace OzonContestTests.Helpers;

internal class DatasetReader : IReader
{
    private readonly StreamReader _streamReader;
    private bool disposedValue;

    public DatasetReader(string fileName)
    {
        _streamReader = new StreamReader(fileName);
    }

    public string ReadStr()
        => _streamReader.ReadLine() ?? throw new ArgumentNullException(nameof(_streamReader), "End of stream.");

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
