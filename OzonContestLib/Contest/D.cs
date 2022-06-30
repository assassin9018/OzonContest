using OzonContest.Helpers;

namespace OzonContestLib.Contest
{
    public class D : IssueHandlerBase
    {
        public D()
        {
        }

        public D(IReader reader, IWriter writer) : base(reader, writer)
        {
        }

        public override int Number { get; }

        public override void Run()
        {
            throw new NotImplementedException();
        }
    }
}
