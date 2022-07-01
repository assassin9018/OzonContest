namespace OzonContestTests
{
    internal class AnswerValidationException : Exception
    {
        public AnswerValidationException(string expected, string actual, string file, int line) : base($"expected - {expected}, actual - {actual}, file - {file}, line - {line}.")
        {
        }
    }
}
