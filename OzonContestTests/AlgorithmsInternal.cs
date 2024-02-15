using OzonContest.Helpers;
using OzonContestLib.AlgorithmsInternal;

namespace OzonContestTests;

[TestClass]
public class AlgorithmsInternal : BaseTest
{
    public AlgorithmsInternal()
    {
        DatasetName = nameof(AlgorithmsInternal);
    }

    [TestMethod]
    public void L1T1()
        => ExecuteTest((IReader reader, IWriter validator) => new L1T1(reader, validator));
    
    [TestMethod]
    public void L1T2()
        => ExecuteTest((IReader reader, IWriter validator) => new L1T2(reader, validator));
}