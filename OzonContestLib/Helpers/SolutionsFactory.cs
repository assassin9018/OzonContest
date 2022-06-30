using System.Reflection;

namespace OzonContest.Helpers;

public class SolutionsFactory
{
    public SolutionsFactory()
    {
    }

    public IEnumerable<IIssueHandler> CreateSolutions()
    {
        return Assembly
            .GetAssembly(typeof(SolutionsFactory))
            !.GetTypes()
            .Where(x => x.IsClass && x.GetInterface(nameof(IIssueHandler)) != null && !x.IsAbstract)
            .Select(x => x.GetConstructor(Type.EmptyTypes)?.Invoke(Array.Empty<object>()))
            .Where(x => x != null)
            .Cast<IIssueHandler>()
            .OrderBy(x => x.Name);
    }
}