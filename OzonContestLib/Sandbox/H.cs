using OzonContest.Helpers;

namespace OzonContestLib.Sandbox
{
    public class H : IssueHandlerBase
    {
        public H()
        {
        }

        public H(IReader reader, IWriter writer) : base(reader, writer)
        {
        }

        public override int Number { get; } = 0;

        public override void Run()
        {
        }
    }
}
