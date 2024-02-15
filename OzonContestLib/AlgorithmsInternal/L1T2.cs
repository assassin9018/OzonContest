using OzonContest.Helpers;

namespace OzonContestLib.AlgorithmsInternal;

public class L1T2 : IssueHandlerBase
{
    public L1T2()
    {
    }

    public L1T2(IReader reader, IWriter writer) : base(reader, writer)
    {
    }

    public override int Number { get; } = 2;

    public override void Run()
    {
        var _ = ReadInt();

        var arr = ReadArray();
        var last = arr[^1];
        var lessThanLast = 0;
        var equalLast = 0;

        foreach (var i in arr)
            if (i < last)
                lessThanLast++;
            else if(i == last)
                equalLast++;
        
        
        Write($"{lessThanLast} {lessThanLast + equalLast - 1}");
    }
}