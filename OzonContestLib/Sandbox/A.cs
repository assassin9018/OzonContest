using OzonContest.Helpers;

namespace OzonContestLib.Sandbox
{
    public class A : IssueHandlerBase
    {
        public A()
        {
        }

        public A(IReader reader, IWriter writer) : base(reader, writer)
        {
        }

        public override int Number { get; } = 1;

        public override void Run()
        {
            int count = ReadInt();
            for (int i = 0; i < count; i++)
            {
                var strs = Read2Int();
                Write(strs.Item1 + strs.Item2);
            }
        }
    }
}
