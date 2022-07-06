using OzonContest.Helpers;

namespace OzonContestLib.Contest
{
    public class B : IssueHandlerBase
    {
        public B()
        {
        }

        public B(IReader reader, IWriter writer) : base(reader, writer)
        {
        }

        public override int Number { get; }

        public override void Run()
        {
            int count = ReadInt();
            for (int i = 0; i < count; i++)
            {
                _ = ReadInt();
                var devs = ReadArray();
                for (int j = 0; j < devs.Length; j++)
                {
                    var current = devs[j];
                    if (current == int.MinValue)
                        continue;
                    int otherDelta = int.MaxValue, otherIndex = -1;
                    for (int k = j + 1; k < devs.Length; k++)
                        if (Math.Abs(current - devs[k]) < otherDelta)
                        {
                            otherDelta = Math.Abs(current - devs[k]);
                            otherIndex = k;
                        }
                    devs[otherIndex] = int.MinValue;
                    Write($"{j + 1} {otherIndex + 1}");
                }
                Write();
            }
        }

    }
}
