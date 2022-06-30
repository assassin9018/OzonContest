using OzonContest.Helpers;

namespace OzonContestLib.Contest
{
    public class E : IssueHandlerBase
    {
        public E()
        {
        }

        public E(IReader reader, IWriter writer) : base(reader, writer)
        {
        }

        public override int Number { get; }

        public override void Run()
        {
            throw new NotImplementedException();
        }
    }
}
