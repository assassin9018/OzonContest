using OzonContest.Helpers;
using System.Diagnostics;

namespace OzonContestLib.Sandbox
{
    public class H : IssueHandlerBase
    {
        private readonly static char[][][,] _templates = InitTemplates();

        private static char[][][,] InitTemplates()
        {
            var templates = new char[4][][,];
            for (int i = 0; i < templates.GetLength(0); i++)
                templates[i] = new char[4][,];
            templates[0][0] = new[,] { { '*', '*', '*' },
                                       { '*', '.', '*' },
                                       { '*', '*', '*' } };
            templates[1][0] = new[,] { { '*', '*', '*', '*' },
                                       { '*', '.', '.', '*' },
                                       { '*', '.', '*', '*' },
                                       { '*', '*', '*', ' ' } };
            templates[2][0] = new[,] { { '*', '*', '*', '*', '*' },
                                       { '*', '.', '.', '.', '*' },
                                       { '*', '.', '*', '*', '*' },
                                       { '*', '.', '*', ' ', ' ' },
                                       { '*', '*', '*', ' ', ' ' } };
            templates[3][0] = new[,] { { '*', '*', '*', '*', '*', '*' },
                                       { '*', '.', '.', '.', '.', '*' },
                                       { '*', '.', '*', '*', '*', '*' },
                                       { '*', '.', '*', ' ', ' ', ' ' },
                                       { '*', '.', '*', ' ', ' ', ' ' },
                                       { '*', '*', '*', ' ', ' ', ' ' } };

            for (int i = 0; i < templates.Length; i++)
                for (int j = 1; j < templates[i].Length; j++)
                    templates[i][j] = Rotate90Matrix(templates[i][j - 1]);

            return templates;

            //честно спизжено с просторов интернета
            char[,] Rotate90Matrix(char[,] arr)
            {
                //матрица квадратная, поэтому заменил m n на одну s
                int s = arr.GetLength(0), j = 0, p = 0, q = 0, i = s - 1;
                char[,] rotatedArr = new char[s, s];

                for (int k = 0; k < s; k++)
                {
                    while (i >= 0)
                    {
                        rotatedArr[p, q] = arr[i, j];
                        q++;
                        i--;
                    }
                    j++;
                    i = s - 1;
                    q = 0;
                    p++;
                }

                return rotatedArr;
            }
        }

        public H()
        {
        }

        public H(IReader reader, IWriter writer) : base(reader, writer)
        {
        }

        public override int Number { get; } = 0;

        public override void Run()
        {
            int count = ReadInt();
            for (int i = 0; i < count; i++)
            {
                (int n, int m) = Read2Int();
                char[,] field = ReadCharMatrix(n, m);
                var list = SearchShips(field);
                Debug.WriteLine(list.Count);
                print(field);
                if (list.Count > 0 && NoStars(field))
                {
                    Write("YES");
                    Write<byte>(list);
                }
                else
                    Write("NO");
            }
        }

        private static bool NoStars(char[,] field)
        {
            for (int i = 0; i < field.GetLength(0); i++)
                for (int j = 0; j < field.GetLength(1); j++)
                    if (field[i, j] == '*')
                        return false;
            return true;
        }

        private static List<byte> SearchShips(char[,] field)
        {
            List<byte> ships = new();
            int fieldSizeX = field.GetLength(0);
            int fieldSizeY = field.GetLength(1);
            foreach (var templateSet in _templates)
            {
                int shipSize = templateSet[0].GetLength(0) - 2;
                if (fieldSizeX < shipSize || fieldSizeY < shipSize)
                    continue;
                for (int i = 0; shipSize + i <= fieldSizeX; i++)
                {
                    for (int j = 0; shipSize + j <= fieldSizeY; j++)
                    {
                        foreach (var template in templateSet)
                        {
                            (bool isShipExist, bool isValidPos)  = AreThereShip(field, i, j, template);
                            if (isShipExist)
                            {
                                if (isValidPos)
                                    return new();
                                MarkArea(field, i, j, template);
                                ships.Add(GetShipLength(shipSize));
                                break;
                            }
                        }
                    }
                }
            }

            return ships;
        }

        private static (bool isShipExist, bool isValidPos) AreThereShip(char[,] field, int fPosX, int fPosY, char[,] template)
        {
            bool isShipExist = true, isValidPos = true;
            int fieldSizeX = field.GetLength(0), fieldSizeY = field.GetLength(1);
            int tSize = template.GetLength(0);
            for (int i = 0; isShipExist && i < tSize; i++)
            {
                int fpx = fPosX + i - 1;
                if (fpx < 0 || fpx == fieldSizeX)
                    continue;
                for (int j = 0; isShipExist && j < tSize; j++)
                {
                    int fpy = fPosY + j - 1;
                    if (fpy < 0 || fpy >= fieldSizeY)
                        continue;
                    isShipExist = field[fpx, fpy] != template[i, j];
                    isValidPos = field[fpx, fpy] == '+' && template[i, j] != ' ';
                }
            }

            return (isShipExist, isValidPos);
        }

        private static void MarkArea(char[,] field, int fPosX, int fPosY, char[,] template)
        {
            int fieldSizeX = field.GetLength(0), fieldSizeY = field.GetLength(1);
            int tSize = template.GetLength(0);
            for (int i = 0; i < tSize; i++)
            {
                int fpx = fPosX + i - 1;
                if (fpx < 0 || fpx == fieldSizeX)
                    continue;
                for (int j = 0; j < tSize; j++)
                {
                    int fpy = fPosY + j - 1;
                    if (fpy < 0 || fpy >= fieldSizeY)
                        continue;
                    if (template[i, j] == '.')
                        field[fpx, fpy] = '+';
                }
            }
        }

        private static byte GetShipLength(int shipSize)
        {
            return shipSize switch
            {
                1 => 1,
                2 => 3,
                3 => 5,
                4 => 7
            };
        }

        public static void print(char[,] chars)
        {
            for (int i = 0; i < chars.GetLength(0); i++)
            {
                for (int j = 0; j < chars.GetLength(1); j++)
                    Debug.Write(chars[i, j]);
                Debug.WriteLine("");
            }
            Debug.WriteLine("");
        }
    }
}
