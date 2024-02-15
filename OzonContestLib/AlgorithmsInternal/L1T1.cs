using System.IO;
using System.Text;
using OzonContest.Helpers;

namespace OzonContestLib.AlgorithmsInternal;

public class L1T1 : IssueHandlerBase
{
    public L1T1()
    {
    }

    public L1T1(IReader reader, IWriter writer) : base(reader, writer)
    {
    }

    public override int Number { get; } = 1;

    public override void Run()
    {
        var size = Read2Int();

        var first = ReadArray();
        var second = ReadArray();

        int i = 0, j = 0;
        var sb = new StringBuilder(size.Item1 + size.Item2);

        while (i < first.Length && j < second.Length)
        {
            int f = first[i], s = second[j];
            if (f < s)
            {
                i++;
                sb.Append(f + " ");
            }
            else
            {
                j++;
                sb.Append(s + " ");
            }
        }

        var (arr, idx) = i < first.Length ? (first, i) : (second, j);
        for (; idx < arr.Length; idx++)
            sb.Append(arr[idx] + " ");
        if (sb.Length > 0)
            sb.Remove(sb.Length - 1, 1);
        
        Write(sb.ToString());
    }
}