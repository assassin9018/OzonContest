using OzonContest.Helpers;

namespace OzonContestLib.Contest
{
    public class C : IssueHandlerBase
    {
        public C()
        {
        }

        public C(IReader reader, IWriter writer) : base(reader, writer)
        {
        }

        public override int Number { get; }

        public override void Run()
        {
            throw new NotImplementedException();
        }
    }
}
