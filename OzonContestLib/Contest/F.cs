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
            throw new NotImplementedException();
        }
    }
}
