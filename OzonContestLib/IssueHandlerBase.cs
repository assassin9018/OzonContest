using OzonContest;
using OzonContest.Helpers;

namespace OzonContestLib
{
    public  abstract class IssueHandlerBase : IIssueHandler, IDisposable
    {
        private readonly IReader _reader;
        private readonly IWriter _writer;
        private bool disposedValue;

        public string Name { get; }
        public abstract int Number { get; }
        public abstract void Run();

        public IssueHandlerBase():this(new ConsoleReader(), new ConsoleWriter())
        {
        }

        public IssueHandlerBase(IReader reader, IWriter writer)
        {
            _reader = reader;
            _writer = writer;
            Name = GetType().Name;
        }

        #region Read

        protected string ReadLine()
            => _reader.ReadStr();

        protected IEnumerable<string> ReadLines(int n)
            => Enumerable.Range(0, n).Select(_ => ReadLine());

        protected int ReadInt() 
            => int.Parse(ReadLine());

        protected (int, int) Read2Int()
        {
            var strs = ReadLine().Split(' ');
            return (int.Parse(strs[0]), int.Parse(strs[1]));
        }

        protected double ReadDouble() 
            => double.Parse(ReadLine());

        protected IEnumerable<int> ReadEnumerableInt()
            => ReadLine().Split(' ').Select(x => int.Parse(x));

        protected int[] ReadArray()
            => ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

        protected int[,] Read2DimArray()
        {
            throw new NotImplementedException();
        }

        protected int[][] ReadArrayWithSubs(int n, int _)
        {
            int[][] arr = new int[n][];

            for (int i = 0; i < arr.Length; i++)
                arr[i] = ReadArray();

            return arr;
        }

        #endregion Read

        #region Write

        protected void Write() 
            => _writer.Write(string.Empty);

        protected void Write<T>(T value)
            => _writer.Write(value);

        protected void Write<T>(IEnumerable<T> values, char separator = ' ')
            => _writer.WriteRange<T>(values, separator);

        #endregion Write

        #region Help methods

        protected static void BubbleSort<T1, T2>(T1[] array, Func<T1, T2> selector) where T2 : IComparable<T2>
        {
            for (int i = 0; i < array.Length; i++)
                for (int j = 1; j < array.Length; j++)
                    if (selector(array[j]).CompareTo(selector(array[j - 1])) < 0)
                        (array[j], array[j - 1]) = (array[j - 1], array[j]);
        }

        #endregion Help methods

        #region Dispose

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if(_reader is IDisposable dr)
                        dr.Dispose();
                    if(_writer is IDisposable dw)
                        dw.Dispose();
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        #endregion Dispose
    }
}
