using OzonContest.Helpers;

namespace OzonContestLib.Contest
{
    public class F : IssueHandlerBase
    {
        public F()
        {
        }

        public F(IReader reader, IWriter writer) : base(reader, writer)
        {
        }

        public override int Number { get; }

        public override void Run()
        {
            int count = ReadInt();
            for (int i = 0; i < count; i++)
            {
                int count2 = ReadInt();
                bool allValid = true;
                List<(TimeOnly start, TimeOnly end)> intervals = new(count2);

                for (int j = 0; j < count2; j++)
                {
                    string str = ReadLine();
                    (bool isValid1, TimeOnly t1) = ParseTime(str.AsSpan(0, 8));
                    (bool isValid2, TimeOnly t2) = ParseTime(str.AsSpan(9, 8));
                    allValid &= isValid1 && isValid2 && t1 <= t2;
                    intervals.Add((t1, t2));
                }

                if (allValid)
                    intervals.Sort((l, r) => l.start.CompareTo(r.start));

                for (int j = 0; allValid && j < intervals.Count - 1; j++)
                    allValid &= intervals[j].end < intervals[j + 1].start;
                Write(allValid ? "YES" : "NO");
            }
        }

        private (bool isValid1, TimeOnly time1) ParseTime(ReadOnlySpan<char> timeStr)
        {
            int h = int.Parse(timeStr.Slice(0, 2));
            int m = int.Parse(timeStr.Slice(3, 2));
            int s = int.Parse(timeStr.Slice(6, 2));
            bool isValid = h < 24 && m < 60 && s < 60;

            return (isValid, isValid ? new TimeOnly(h, m, s) : new TimeOnly(0, 0, 0));
        }
    }
}
