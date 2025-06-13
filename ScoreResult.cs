using System.Linq;
using System.Text;

namespace NB_Camp_Project_9
{
    internal class ScoreResult
    {
        public static StringBuilder inputWords = new StringBuilder();
        public static bool bExit = false;

        static void Main(string[] args)
        {
            while (bExit == false)
            {
                // 그리기
                Grid();

                // 키 입력 받기
                string word = Console.ReadLine();

                // 만약 -1이 들어왔다면 반복문 빠져나가기
                if(word.Equals("-1") == true)
                {
                    bExit = true;
                    break;
                }

                // 숫자인지 체크
                if (WordCheck(word) == true) inputWords.Append($"{word},");
                else Console.WriteLine("숫자를 입력해주세요.");
            }

            // 글자 자른 뒤 배열에 집어 넣기
            Result();
        }

        public static void Grid()
        {
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("점수를 입력해주세요. (전부 입력하셨다면 -1을 입력해주세요)");
        }

        public static bool WordCheck(string word)
        {
            if (int.TryParse(word, out int score))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void Result()
        {
            // 문자열 자른 뒤 빈 문자열 제거이후 int 배열에 추가 
            int[] scores = inputWords.ToString().Split(',').Where(s => !string.IsNullOrWhiteSpace(s)).Select(int.Parse).ToArray();

            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("입력한 점수");

            int iCount = 1;
            // 내가 입력한 점수 보여주기
            foreach(var pair in scores)
            {
                Console.WriteLine($"{iCount} : {pair}");
                iCount++;
            }

            int totalScore = TotalScore(scores);
            float averageScore = AverageScore(totalScore, scores);

            // 평균 및 합계 보여주기
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("입력한 점수의 합계");
            Console.WriteLine($"{totalScore}");

            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("입력한 점수의 평균");
            Console.WriteLine($"{averageScore.ToString("F2")}");
        }

        // 합계 구하기
        public static int TotalScore(int[] scores)
        {
            int iTotalScore = 0;
            foreach (var pair in scores)
            {
                iTotalScore += pair;
            }
            return iTotalScore;
        }

        // 평균 구하기
        public static float AverageScore(int totalScore,int[] scores)
        {
            return (float)totalScore / scores.Length;
        }
    }
}
