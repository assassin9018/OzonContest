namespace OzonContestTests.Helpers;

internal class OutputValidatorWithCustomRule : OutputValidator
{
    private readonly Func<string, string, bool> _validationRule;

    public OutputValidatorWithCustomRule(string fileName, int timeLimit, Func<string, string, bool> validationRule) : base(fileName, timeLimit)
    {
        _validationRule = validationRule;
    }

    protected override void Validate(string actual, string expected)
    {
        bool isValid = _validationRule(actual, expected);
        if(!isValid)
            Fail(actual, expected);
    }
}