using OzonContest;
using OzonContest.Helpers;

namespace OzonContestLib
{
    public  abstract class IssueHandlerBase : IIssueHandler
    {
        private readonly IReader _reader;
        private readonly IWriter _writer;

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

        protected int[,] ReadIntMatrix(int n, int m)
        {
            var arr = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                string[] line = ReadLine().Split(' ');
                for (int j = 0; j < m; j++)
                    arr[i, j] = int.Parse(line[j]);
            }
            return arr;
        }

        protected char[,] ReadCharMatrix(int n, int m)
        {
            var arr = new char[n, m];
            for (int i = 0; i < n; i++)
            {
                string line = ReadLine();
                for (int j = 0; j < m; j++)
                    arr[i, j] = line[j];
            }
            return arr;
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

        protected static void BubbleSort<T1, T2>(IList<T1> array, Func<T1, T2> selector) where T2 : IComparable<T2>
        {
            for (int i = 0; i < array.Count; i++)
                for (int j = 1; j < array.Count; j++)
                    if (selector(array[j]).CompareTo(selector(array[j - 1])) < 0)
                        (array[j], array[j - 1]) = (array[j - 1], array[j]);
        }

        #endregion Help methods
    }
}
