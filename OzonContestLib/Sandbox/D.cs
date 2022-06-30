using OzonContest.Helpers;
using System.Text.RegularExpressions;

namespace OzonContestLib.Sandbox
{
    public class D : IssueHandlerBase
    {
        public D()
        {
        }

        public D(IReader reader, IWriter writer) : base(reader, writer)
        {
        }

        public override int Number { get; } = 0;

        public override void Run()
        {
            Regex regex = new("^[a-z0-9_][a-z0-9_-]{1,23}$");
            int t = ReadInt();
            for (int i = 0; i < t; i++)
            {
                HashSet<string> usedLogins = new();
                int n = ReadInt();
                for (int j = 0; j < n; j++)
                {
                    string login = ReadLine().ToLowerInvariant();
                    if (regex.IsMatch(login) && !usedLogins.Contains(login))
                    {
                        usedLogins.Add(login);
                        Write("YES");
                    }
                    else
                        Write("NO");
                }
                Write();
            }
        }
    }
}
