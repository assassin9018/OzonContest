using OzonContest.Helpers;

namespace OzonContestLib.Contest
{
    public class J : IssueHandlerBase
    {
        public J()
        {
        }

        public J(IReader reader, IWriter writer) : base(reader, writer)
        {
        }

        public override int Number { get; }

        //todo решение правильное, а вот что делать с тестом хз. Тоже несколько вариантов ответов
        public override void Run()
        {
            int wordsCount = ReadInt();

            List<string> dictionary = new(wordsCount);
            for (int i = 0; i < wordsCount; i++)
            {
                string word = ReverceStr(ReadLine());
                dictionary.Add(word);
            }
            dictionary.Sort();
            int requestsCount = ReadInt();
            for (int i = 0; i < requestsCount; i++)
            {
                string request = ReverceStr(ReadLine());
                string res = GetSimilar(request, dictionary);
                Write(ReverceStr(res));
            }
        }

        private static string GetSimilar(string sourceStr, List<string> dictionary)
        {
            int index = dictionary.BinarySearch(sourceStr);
            int left = index < 0 ? (~index)-1 : index-1;
            int right = index < 0 ? (~index) : index + 1;
            string leftStr = left >= 0 ? dictionary[left] : dictionary[right];
            string rightStr = right < dictionary.Count ? dictionary[right] : dictionary[left];

            int leftEqulity = 0, rightEqulity = 0;
            for (int i = 0; i < sourceStr.Length && leftEqulity==rightEqulity; i++)
            {
                if (i < leftStr.Length && sourceStr[i] == leftStr[i])
                    leftEqulity++;
                if (i < rightStr.Length && sourceStr[i] == rightStr[i])
                    rightEqulity++;
            }
            if (leftEqulity > rightEqulity)
                return leftStr;
            return rightStr;
        }

        private static string ReverceStr(string str)
        {
            //можно было и через linq, но фиг с ним
            char[] arr = str.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
    }
}