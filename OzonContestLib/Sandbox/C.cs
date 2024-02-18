using OzonContest.Helpers;

namespace OzonContestLib.Sandbox;

public class C(IReader reader, IWriter writer) : IssueHandlerBase(reader, writer)
{
    public override void Run()
    {
        int count = ReadInt();
        for (int c = 0; c < count; c++)
        {
            ReadLine();
            (int n, int m) = Read2Int();
            int[][] arr = ReadArrayWithSubs(n, m);

            _ = ReadLine();
            int[] sorts = ReadArray();

            foreach (int index in sorts)
                BubbleSort(arr, x => x[index - 1]);

            foreach (int[] subArr in arr)
                Write<int>(subArr);
            Write();
        }
    }
}