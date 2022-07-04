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
            => ExecuteTest((IReader reader, IWriter validator) => new D(reader, validator));

        [TestMethod]
        public void E()
            => ExecuteTest((IReader reader, IWriter validator) => new E(reader, validator));

        [TestMethod]
        public void F()
            => ExecuteTest((IReader reader, IWriter validator) => new F(reader, validator));

        [TestMethod]
        public void G()
            => ExecuteTest((IReader reader, IWriter validator) => new G(reader, validator), true);

        [TestMethod]
        public void H()
            => ExecuteTest((IReader reader, IWriter validator) => new H(reader, validator));

        [TestMethod]
        public void I()
            => ExecuteTest((IReader reader, IWriter validator) => new I(reader, validator));
    }
}
