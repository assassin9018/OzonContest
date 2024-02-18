using OzonContest.Helpers;
using System.Text;

namespace OzonContestLib.Sandbox;

public class E(IReader reader, IWriter writer) : IssueHandlerBase(reader, writer)
{
    public override void Run()
    {
        int t = ReadInt();

        StringBuilder sb = new(256);
        for (int i = 0; i < t; i++)
        {
            int n = ReadInt();
            {
                var something =ReadLines(n)
                    .Select(x => x.Split(' '))
                    .Select(x => new { key = x[0], value = x[1] })
                    .GroupBy(x => x.key, (k, e) => (key: k, values: e.Select(x => x.value).ToList()))
                    .OrderBy(x => x.key);

                foreach (var kvp in something)
                {
                    List<string> fakeQueue = new(6);
                    foreach (string phone in kvp.values)
                    {
                        fakeQueue.Remove(phone);
                        fakeQueue.Add(phone);
                        if (fakeQueue.Count == 6)
                            fakeQueue.RemoveAt(0);
                    }

                    fakeQueue.Reverse();
                    sb.Append(kvp.key).Append(": ").Append(fakeQueue.Count).Append(' ').AppendJoin(' ', fakeQueue);
                    Write(sb.ToString());
                    sb.Clear();
                }
            }
            Write();
        }
    }
}