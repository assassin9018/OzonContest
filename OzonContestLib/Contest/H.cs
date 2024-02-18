using OzonContest.Helpers;

namespace OzonContestLib.Contest;

public class H(IReader reader, IWriter writer) : IssueHandlerBase(reader, writer)
{
    public override void Run()
    {
        int count = ReadInt();
        for (int i = 0; i < count; i++)
        {
            (int x, int y) = Read2Int();
            char[][] map = new char[x][];
            for (int j = 0; j < x; j++)
                map[j] = ReadLine().ToCharArray();
            bool isValid = Validate(map);
            //print(map);
            Write(isValid ? "YES" : "NO");
        }
    }

    private bool Validate(char[][] map)
    {
        List<char> usedColors = new(4);

        for (int i = 0; i < map.Length; i++)
        for (int j = 0; j < map[0].Length; j++)
        {
            if (map[i][j] == '.' || map[i][j] == '+')
                continue;
            if (usedColors.Contains(map[i][j]))
                return false;
            usedColors.Add(map[i][j]);
            Recolor(map, i, j);
        }

        return true;
    }

    private void Recolor(char[][] map, int x, int y)
    {
        Stack<(int x, int y)> way = new();
        way.Push((x, y));
        char currentColor = map[x][y];
        map[x][y] = '+';
        while (way.Count > 0)
        {
            var pos = way.Pop();
            IEnumerable<(int x, int y)> directions = GetDirections(pos);
            foreach (var dir in directions)
            {
                if (dir.x < 0 || dir.y < 0 || dir.x >=map.Length || dir.y >= map[0].Length || map[dir.x][dir.y] != currentColor)
                    continue;
                way.Push((dir.x, dir.y));
                map[dir.x][dir.y] = '+';
            }
        }
    }

    private IEnumerable<(int x, int y)> GetDirections((int x, int y) pos)
    {
        yield return (pos.x, pos.y - 2);
        yield return (pos.x, pos.y + 2);


        yield return (pos.x + 1, pos.y + 1);
        yield return (pos.x + 1, pos.y - 1);

        yield return (pos.x - 1, pos.y + 1);
        yield return (pos.x - 1, pos.y - 1);
    }

    //как вывод для отладки
    //private static void print(char[][] chars)
    //{
    //    for (int i = 0; i < chars.Length; i++)
    //    {
    //        for (int j = 0; j < chars[0].Length; j++)
    //            Debug.Write(chars[i][j]);
    //        Debug.WriteLine("");
    //    }
    //    Debug.WriteLine("");
    //}
}