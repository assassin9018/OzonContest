using OzonContest.Helpers;

namespace OzonContestLib.Contest
{
    public class C : IssueHandlerBase
    {
        public C()
        {
        }

        public C(IReader reader, IWriter writer) : base(reader, writer)
        {
        }

        public override int Number { get; }

        public override void Run()
        {
            (int usersCount, int reqCount)= Read2Int();
            int[] notifications = new int[usersCount + 1];
            int ntfIterator = 0;
            for (int i = 0; i < reqCount; i++)
            {
                (int t, int id) = Read2Int();
                if (t == 1)
                    notifications[id] = ++ntfIterator;
                else
                    Write(Math.Max(notifications[id], notifications[0]));
            }
        }
    }
}
