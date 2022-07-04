using OzonContest;
using OzonContest.Helpers;
using OzonContestDataSet;
using OzonContestTests.Helpers;
using System.Runtime.CompilerServices;

namespace OzonContestTests
{
    public class BaseTest
    {
        protected string DatasetName = string.Empty;

        protected void ExecuteTest(Func<IReader, IWriter, IIssueHandler> getHandler, bool useSplitValidation = false, [CallerMemberName]string issueName = null!)
        {
            foreach(var (question, answer) in DatasetProvider.GetFilesNames(DatasetName, issueName))
            {
                using var reader = new DatasetReader(question);
                using var validator = useSplitValidation ? new OutputSplitValidator(answer) : new OutputValidator(answer);
                var handler = getHandler(reader, validator);
                handler.Run();
                validator.EnsureAllDataRequested();
            }
        }
    }
}