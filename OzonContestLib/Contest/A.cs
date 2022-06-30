using OzonContest.Helpers;

namespace OzonContestLib.Contest
{
    public class A : IssueHandlerBase
    {
        public A()
        {
        }

        public A(IReader reader, IWriter writer) : base(reader, writer)
        {
        }

        public override int Number { get; }

        public override void Run()
        {
            throw new NotImplementedException();
        }
    }
}
