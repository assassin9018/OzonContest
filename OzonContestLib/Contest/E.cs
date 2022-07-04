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
            int count = ReadInt();
            for (int i = 0; i < count; i++)
            {
                _ = ReadInt();
                int[] arr = ReadArray();
                List<int> list = new(arr.Length+1);
                list.Add(-1);
                foreach(var item in arr)
                    if(item != list[^1])
                        list.Add(item);
                if (list.Count == list.Distinct().Count())
                    Write("YES");
                else
                    Write("NO");
            }
        }
    }
}
