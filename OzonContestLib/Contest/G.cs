using OzonContest.Helpers;

namespace OzonContestLib.Contest
{
    public class G : IssueHandlerBase
    {
        public G()
        {
        }

        public G(IReader reader, IWriter writer) : base(reader, writer)
        {
        }

        public override int Number { get; }

        public override void Run()
        {
            throw new NotImplementedException();
        }
    }
}
