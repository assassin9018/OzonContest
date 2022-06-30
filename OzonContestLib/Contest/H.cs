using OzonContest.Helpers;

namespace OzonContestLib.Contest
{
    public class H : IssueHandlerBase
    {
        public H()
        {
        }

        public H(IReader reader, IWriter writer) : base(reader, writer)
        {
        }

        public override int Number { get; }

        public override void Run()
        {
            throw new NotImplementedException();
        }
    }
}
