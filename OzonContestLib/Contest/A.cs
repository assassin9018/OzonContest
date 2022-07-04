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
            Write("I am sure that I will fill out the form by 11:00 am on July 4, 2022.");
        }
    }
}
