using OzonContest.Helpers;
using System.Text;

namespace OzonContestLib.Sandbox;

public class G(IReader reader, IWriter writer) : IssueHandlerBase(reader, writer)
{
    public override void Run()
    {
        int count = ReadInt();
        for (int c = 0; c < count; c++)
        {
            _ = ReadLine();
            int mCount = ReadInt();

            Dictionary<string, string[]> dependenciesByModul = ReadLines(mCount)
                .Select(x => x.Split(' '))
                .ToDictionary(k => k[0][..^1], v => v.Skip(1).ToArray());

            int reqCount = ReadInt();
            var requests = ReadLines(reqCount);

            List<string> sequence = new();
            HashSet<string> alreadyBuilt = new();
            StringBuilder sb = new(256);
            foreach (string modul in requests)
            {
                CreateSequence(modul, alreadyBuilt, dependenciesByModul, sequence);
                sb.Append(sequence.Count);
                if (sequence.Count > 0)
                    sb.Append(' ').AppendJoin(' ', sequence);

                Write(sb.ToString());
                sequence.Clear();
                sb.Clear();
            }
            Write();
        }
    }

    private static void CreateSequence(string modul, HashSet<string> alreadyBuilt, Dictionary<string, string[]> dependenciesByModul, List<string> sequence)
    {
        if (alreadyBuilt.Contains(modul))
            return;
        foreach (string dependency in dependenciesByModul[modul])
            CreateSequence(dependency, alreadyBuilt, dependenciesByModul, sequence);
        sequence.Add(modul);
        alreadyBuilt.Add(modul);
    }
}