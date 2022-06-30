using OzonContest.Helpers;
using OzonContestLib.Sandbox;

namespace OzonContestTests
{
    [TestClass]
    public class SandBox : BaseTest
    {
        public SandBox()
        {
            DatasetName = nameof(SandBox);
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
    }
}