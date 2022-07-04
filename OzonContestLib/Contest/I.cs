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

        //todo решение правильное, но медленное
        public override void Run()
        {
            (int coresCount, int tasks) = Read2Int();
            int[] coresTdp = ReadArray();
            Array.Sort(coresTdp);
            long totalPower = 0;
            int[] taskEndTime = new int[coresCount];
            for (int i = 0; i < tasks; i++)
            {
                (int now, int duration) = Read2Int();

                int coreIndex = 0;
                while (coreIndex < coresCount && taskEndTime[coreIndex] > now)
                    coreIndex++;

                if (coreIndex != coresCount)
                {
                    taskEndTime[coreIndex] = now + duration;
                    totalPower += coresTdp[coreIndex] * (long)duration;
                }
            }
            Write(totalPower);
        }
    }
}