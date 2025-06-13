using System.Text;

namespace NB_Camp_Project_5
{
    internal class Capitals
    {
        public static string[] _Capitals = { "인천", "평창", "서울", "부산" };
        public static StringBuilder capitalsQuiz = new StringBuilder();
        public static bool isExit = false;

        static void Main(string[] args)
        {
            while (isExit == false)
            {
                Grid();

                string inputKey = Console.ReadLine();

                if (CheckQuiz(inputKey) == true) Console.WriteLine("정답입니다!");
                else Console.WriteLine("오답입니다!");
            }
        }

        public static void Grid()
        {
            Console.WriteLine("-------------------------------------------------------------------------------------------------");
            Console.WriteLine("Q. 대한민국의 수도는 어디인가요?");

            for (int i = 0; i < _Capitals.Length; i++)
            {
                capitalsQuiz.Append($"{i + 1}. {_Capitals[i]}   ");
            }

            Console.WriteLine(capitalsQuiz);
        }

        public static bool CheckQuiz(string inputKey)
        {
            int iSelectNumber = 0;
            string correctAnswer = "서울";

            if (int.TryParse(inputKey, out iSelectNumber))
            {
                if (_Capitals[iSelectNumber - 1] == correctAnswer)
                {
                    isExit = true;
                    return true;
                }
                else
                {
                    capitalsQuiz.Clear();
                    return false;
                }
            }
            else
            {
                capitalsQuiz.Clear();
                return false;
            }
        }
    }
}
