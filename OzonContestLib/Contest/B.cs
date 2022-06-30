using OzonContest.Helpers;

namespace OzonContestLib.Contest
{
    public class B : IssueHandlerBase
    {
        public B()
        {
        }

        public B(IReader reader, IWriter writer) : base(reader, writer)
        {
        }

        public override int Number { get; }

        public override void Run()
        {
            throw new NotImplementedException();
        }
    }
}
