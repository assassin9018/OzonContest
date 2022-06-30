namespace OzonContest;

public interface IIssueHandler
{
    int Number { get; }
    string Name { get; }
    void Run();
}