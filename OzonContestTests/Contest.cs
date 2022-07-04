using OzonContest.Helpers;
using OzonContestLib.Contest;

namespace OzonContestTests
{
    [TestClass]
    public class Contest : BaseTest
    {
        public Contest()
        {
            DatasetName = nameof(Contest);
        }

        [TestMethod]
        public void A()
            => ExecuteTest((IReader reader, IWriter validator) => new A(reader, validator));

        [TestMethod]
        public void B()
            => ExecuteTest((IReader reader, IWriter validator) => new B(reader, validator));

        [TestMethod]
        public void C()
            => ExecuteTest((IReader reader, IWriter validator) => new C(reader, validator));

        [TestMethod]
        public void D()
            => ExecuteTest((IReader reader, IWriter validator) => new D(reader, validator), new TestOptions{ CustomValidationRule = ContestD_CustomRule });

        [TestMethod]
        public void E()
            => ExecuteTest((IReader reader, IWriter validator) => new E(reader, validator));

        [TestMethod]
        public void F()
            => ExecuteTest((IReader reader, IWriter validator) => new F(reader, validator));

        [TestMethod]
        public void G()
            => ExecuteTest((IReader reader, IWriter validator) => new G(reader, validator));

        [TestMethod]
        public void H()
            => ExecuteTest((IReader reader, IWriter validator) => new H(reader, validator));

        [TestMethod]
        public void I()
            => ExecuteTest((IReader reader, IWriter validator) => new I(reader, validator));

        [TestMethod]
        public void J()
            => ExecuteTest((IReader reader, IWriter validator) => new J(reader, validator));

        private static bool ContestD_CustomRule(string actual, string expected)
        {
            char[] vowels = new[] { 'e', 'u', 'i', 'o', 'a', 'y', 'E', 'U', 'I', 'O', 'A', 'Y' };
            if (actual.Length != expected.Length)
                return false;

            bool olnyUpper = expected.ToUpperInvariant() == expected, olnyLower = expected.ToLowerInvariant() == expected;
            bool anyVowel = false, anyСonsonants = false, anyDigit = false;
            foreach (char c in expected)
            {
                anyVowel |= vowels.Contains(c);
                anyСonsonants |= !vowels.Contains(c) && !char.IsDigit(c);
                anyDigit |= char.IsDigit(c);
            }
            
            return !olnyUpper && !olnyLower && anyVowel && anyСonsonants && anyDigit;
        }
    }
}
