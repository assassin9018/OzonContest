using OzonContest.Helpers;

namespace OzonContestLib.Contest
{
    public class I : IssueHandlerBase
    {
        public I()
        {
        }

        public I(IReader reader, IWriter writer) : base(reader, writer)
        {
        }

        public override int Number { get; }

        public override void Run()
        {
            (int coresCount, int tasks) = Read2Int();
            var coresTdp = ReadArray();
            PriorityQueue<int, int> freeCores = new(coresTdp.Select(x => (x, x)));
            PriorityQueue<(int endTime, int tdp), int> execurectiomQueue = new();

            long totalPower = 0;
            for (int i = 0; i < tasks; i++)
            {
                (int now, int duration) = Read2Int();

                while (execurectiomQueue.Count > 0 && execurectiomQueue.Peek().endTime <= now)
                {
                    int tdp = execurectiomQueue.Dequeue().tdp;
                    freeCores.Enqueue(tdp, tdp);
                }

                if (freeCores.Count == 0)
                    continue;

                int minTdp = freeCores.Dequeue();
                execurectiomQueue.Enqueue((now + duration, minTdp), now + duration);
                totalPower += minTdp * (long)duration;
            }
            Write(totalPower);
        }
    }
}