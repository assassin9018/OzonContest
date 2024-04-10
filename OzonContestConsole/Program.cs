using OzonContest.Helpers;

var factory = new SolutionsFactory();

while (true)
{
    var solutions = factory.CreateSolutions();

    var groups = solutions
        .GroupBy(x => x.Namespace)
        .ToDictionary(k => k.Key, v => v.OrderBy(x => x.Name).ToArray());

    var groupNames = groups.Keys.ToArray();
    foreach (var (name, i) in groupNames.Select((x, i) => (x, i)))
        Console.WriteLine($"{i}:{name}");

    var groupIdx = int.Parse(Console.ReadLine()!);
    var solutionsGroup = groups[groupNames[groupIdx]];

    foreach (var (name, i) in solutionsGroup.Select((x, i) => (x.Name, i)))
        Console.WriteLine($"{i}:{name}");
    var solutionIdx = int.Parse(Console.ReadLine()!);

    var solution = solutionsGroup[solutionIdx];
    solution.Run();
}