using OzonContest.Helpers;
using System.Collections;

namespace OzonContestLib.Sandbox
{
    public class F : IssueHandlerBase
    {
        public F()
        {
        }

        public F(IReader reader, IWriter writer) : base(reader, writer)
        {
        }

        public override int Number { get; } = 0;

        public override void Run()
        {
            int count = ReadInt();
            for (int c = 0; c < count; c++)
            {
                _ = ReadLine();
                (int cupeCount, int reqCount) = Read2Int();
                SortedSet<int> emptyCupe = new(Enumerable.Range(0, cupeCount).Select(x => x).ToList());
                BitArray ceats = new(cupeCount * 2);
                for (int i = 0; i < reqCount; i++)
                {
                    var reqPar = ReadLine().Split(' ');
                    int param = -1;
                    ReqType reqType = (ReqType)int.Parse(reqPar[0]);
                    if (reqType is not ReqType.BuyCupe)
                        param = int.Parse(reqPar[1]);
                    string res = Handle(emptyCupe, ceats, reqType, param - 1);
                    Write(res);
                }
                Write();
            }
        }

        static string Handle(SortedSet<int> emptyCupe, BitArray ceats, ReqType reqType, int param)
        {
            string result = "FAIL";
            switch (reqType)
            {
                case ReqType.BuyCeat:
                    if (!ceats[param])
                    {
                        ceats[param] = true;
                        if (!ceats[param ^ 1])
                            emptyCupe.Remove(param / 2);
                        result = "SUCCESS";
                    }
                    break;
                case ReqType.SaleCeat:
                    if (ceats[param])
                    {
                        ceats[param] = false;
                        if (!ceats[param ^ 1])
                            emptyCupe.Add(param / 2);
                        result = "SUCCESS";
                    }
                    break;
                case ReqType.BuyCupe:
                    if (emptyCupe.Count > 0)
                    {
                        int cupeNum = emptyCupe.Min;
                        emptyCupe.Remove(cupeNum);
                        ceats[cupeNum * 2] = ceats[cupeNum * 2 + 1] = true;
                        result = $"SUCCESS {cupeNum * 2 + 1}-{cupeNum * 2 + 2}";
                    }
                    break;
            }
            return result;
        }

        enum ReqType
        {
            BuyCeat = 1,
            SaleCeat = 2,
            BuyCupe = 3,
        }
    }
}
