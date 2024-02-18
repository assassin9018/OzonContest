namespace OzonContest;

public interface IIssueHandler
{
    string Name { get; }
    string Namespace { get; }
    void Run();
}