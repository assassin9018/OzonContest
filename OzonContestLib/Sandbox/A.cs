using OzonContest.Helpers;

namespace OzonContestLib.Sandbox;

public class A(IReader reader, IWriter writer) : IssueHandlerBase(reader, writer)
{
    public override void Run()
    {
        int count = ReadInt();
        for (int i = 0; i < count; i++)
        {
            var strs = Read2Int();
            Write(strs.Item1 + strs.Item2);
        }
    }
}