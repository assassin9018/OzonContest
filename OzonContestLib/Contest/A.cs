using OzonContest.Helpers;

namespace OzonContestLib.Contest;

public class A(IReader reader, IWriter writer) : IssueHandlerBase(reader, writer)
{
    public override void Run()
    {
        Write("I am sure that I will fill out the form by 11:00 am on July 4, 2022.");
    }
}
