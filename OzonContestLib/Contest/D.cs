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
            char[] vowels = new[] { 'e', 'u', 'i', 'o', 'a', 'y', 'E', 'U', 'I', 'O', 'A', 'Y' };
            int count = ReadInt();
            for (int i = 0; i < count; i++)
            {
                string pass = ReadLine();

                bool olnyUpper = pass.ToUpperInvariant() == pass, olnyLower = pass.ToLowerInvariant() == pass;
                bool anyVowel = false, anyСonsonants = false, anyDigit = false;
                foreach (char c in pass)
                {
                    anyVowel |= vowels.Contains(c);
                    anyСonsonants |= !vowels.Contains(c) && !char.IsDigit(c);
                    anyDigit |= char.IsDigit(c);
                }
                if (olnyLower)
                {
                    if (!anyVowel)
                    {
                        anyVowel = true;
                        pass += "E";
                    }
                    else
                    {
                        anyСonsonants = true;
                        pass += "D";
                    }
                }
                if (olnyUpper)
                {
                    if (!anyVowel)
                    {
                        anyVowel = true;
                        pass += "e";
                    }
                    else
                    {
                        anyСonsonants = true;
                        pass += "d";
                    }
                }
                if (!anyVowel)
                {
                    anyVowel = true;
                    pass += "e";
                }
                if (!anyСonsonants)
                {
                    anyСonsonants = true;
                    pass += "d";
                }
                if (!anyDigit)
                    pass += "1";
                Write(pass);
            }
        }
    }
}
