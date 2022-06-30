using OzonContest.Helpers;

namespace OzonContestLib.Sandbox
{
    public class B : IssueHandlerBase
    {
        public B()
        {
        }

        public B(IReader reader, IWriter writer) : base(reader, writer)
        {
        }

        public override int Number { get; } = 2;

        public override void Run()
        {
            int count = ReadInt();
            for (int i = 0; i < count; i++)
            {
                _ = ReadLine();

                int sum = ReadEnumerableInt()
                    .GroupBy(x => x, (int k, IEnumerable<int> e) => (k, e.Count()))
                    .Select(x => x.k * (x.Item2 - x.Item2 / 3))
                    .Sum();

                Write(sum);
            }
        }
    }
}
