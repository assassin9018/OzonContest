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

        private protected void ExecuteTest(Func<IReader, IWriter, IIssueHandler> getHandler, TestOptions? options = null, [CallerMemberName] string issueName = null!)
        {
            options ??= TestOptions.Default;
            foreach (var (question, answer) in DatasetProvider.GetFilesNames(DatasetName, issueName))
            {
                using var reader = new DatasetReader(question);
                using var validator = options.CustomValidationRule != null 
                    ? new OutputValidatorWithCustomRule(answer, options.TimeLimit, options.CustomValidationRule) 
                    : new OutputValidator(answer, options.TimeLimit);
                var handler = getHandler(reader, validator);
                handler.Run();
                validator.EnsureAllDataRequested();
            }
        }

        private protected static bool SplitValidationRule(string actual, string expected)
        {
            var splitedEx = expected.Split(' ');
            var splitedAc = actual.Split(' ');

            if (splitedAc.Length == splitedEx.Length)
            {
                HashSet<string> expectedSet = [..splitedEx];
                return splitedAc.All(x => expectedSet.Contains(x));
            }

            return false;
        }

        private protected class TestOptions
        {
            public static TestOptions Default { get; } = new();

            public int TimeLimit { get; init; } = 30;
            public Func<string, string, bool>? CustomValidationRule { get; init; }
        }
    }
}