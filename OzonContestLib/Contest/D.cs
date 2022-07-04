using OzonContest.Helpers;

namespace OzonContestLib.Contest
{
    public class D : IssueHandlerBase
    {
        public D()
        {
        }

        public D(IReader reader, IWriter writer) : base(reader, writer)
        {
        }

        public override int Number { get; }

        /// <summary>
        /// todo подумать над тестами c несколькими вариантами ответов, решение правильное
        /// </summary>
        public override void Run()
        {
            //лютейший говнокод. Торопился
            char[] glasnie = new[] { 'e', 'u', 'i', 'o', 'a', 'y', 'E', 'U', 'I', 'O', 'A', 'Y' };
            int count = ReadInt();
            for (int i = 0; i < count; i++)
            {
                string pass = ReadLine();

                bool olnyUpper = pass.ToUpperInvariant() == pass, olnyLower = pass.ToLowerInvariant() == pass;
                bool anyGlasnie = false, anyNotGlasnie = false, anyDigit = false;
                foreach (char c in pass)
                {
                    anyGlasnie |= glasnie.Contains(c);
                    anyNotGlasnie |= !glasnie.Contains(c) && !char.IsDigit(c);
                    anyDigit |= char.IsDigit(c);
                }
                if (olnyLower)
                {
                    if (!anyGlasnie)
                    {
                        anyGlasnie = true;
                        pass = pass + "E";
                    }
                    else
                    {
                        anyNotGlasnie = true;
                        pass = pass + "D";
                    }
                }
                if (olnyUpper)
                {
                    if (!anyGlasnie)
                    {
                        anyGlasnie = true;
                        pass = pass + "e";
                    }
                    else
                    {
                        anyNotGlasnie = true;
                        pass = pass + "d";
                    }
                }
                if (!anyGlasnie)
                {
                    anyGlasnie = true;
                    pass = pass + "e";
                }
                if (!anyNotGlasnie)
                {
                    anyNotGlasnie = true;
                    pass = pass + "d";
                }
                if (!anyDigit)
                    pass = pass + "1";
                Write(pass);
            }
        }
    }
}
