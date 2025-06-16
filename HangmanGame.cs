using System.Runtime.CompilerServices;
using System.Text;

namespace NB_Camp_Project_14
{
    internal class HangmanGame
    {
        public static string secretWord = "hangman";        // 맞춰야 하는 글자
        public static char[] guessWord;                     // 사용자가 맞춘 글자
        public static int attempts = 6;                     // 최대 기회 수
        public static bool wordGuessed = false;             // 단어를 모두 맞췄는지?

        public static StringBuilder strCurWord = new StringBuilder();

        static void Main(string[] args)
        {
            Initialize();

            while (true)
            {
                Grid();
                string inputWord = Console.ReadLine();

                // 알파벳 입력하고 Console 청소
                Console.Clear();

                CheckWord(inputWord);
                SuccessCheck();

                if(wordGuessed)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("전부 맞추셨습니다 !!");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                }

                if(attempts <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("기회를 모두 소진하셨습니다. ㅠㅠ");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                }
            }
        }

        // 초기화
        public static void Initialize()
        {
            int lengeh = secretWord.Length;
            guessWord = new char[lengeh];

            for (int i = 0; i < guessWord.Length; i++)
                guessWord[i] = '_';            
        }

        // 그리기
        public static void Grid()
        {
            // 타이틀 및 설명
            Console.WriteLine("-----------------------------------------------------------------------------------------------");

            Console.Write("|                                    글자 맞추기 게임                ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"Chance : {attempts}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"               |");

            Console.WriteLine("-----------------------------------------------------------------------------------------------");

            // Tip 1
            Console.Write("|                            ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Tip : Chance가 0이 되면 패배합니다.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("                              |");
            // Tip 2
            Console.Write("|                            ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Tip : 숨겨진 글자의 개수는 □의 개수와 같습니다.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("                  |");

            Console.WriteLine("-----------------------------------------------------------------------------------------------");

            // 문제
            Grid_WordQuiz();

            Console.WriteLine("-----------------------------------------------------------------------------------------------");
            Console.Write("알파벳을 입력해주세요 (1글자) : ");
        }

        // 문제 그리기
        public static void Grid_WordQuiz()
        {
            strCurWord.Clear();

            Console.Write("|                            ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"맞춘 글자 :    ");
            Console.ForegroundColor = ConsoleColor.White;

            for (int i = 0; i < guessWord.Length; i++)
            {
                if (guessWord[i].Equals('_') == true)
                    strCurWord.Append("□ ");
                else
                    strCurWord.Append($"{guessWord[i]} ");
            }
            Console.Write(strCurWord);
            Console.WriteLine("                                    |");
        }

        // 글자 체크
        public static void CheckWord(string inputWord)
        {
            bool bWordCheck = false;

            // 길이 체크
            if(inputWord.Length > 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("! : 하나씩 입력해주세요.");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }

            char userWord = char.Parse(inputWord.ToLower());

            // 알파벳인지 체크
            if (userWord >= 'a' && userWord <= 'z')
            {
                char[] aiWords = secretWord.ToLower().ToCharArray();

                // 정답 문자 위치 찾기
                for (int i = 0; i < aiWords.Length; i++)
                {
                    // 중복되는 글자가 존재할 수 있으니 반복문 종료는 ㄴㄴ
                    if (userWord == aiWords[i])
                    {
                        guessWord[i] = userWord;
                        bWordCheck = true;
                    }
                }

                if (bWordCheck == false)
                {
                    attempts--;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"! : 해당 알파벳은 포함되지 않습니다! 기회 차감");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("! : 알파벳이 아닙니다.");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        // 정답 전부 맞췄는지 체크
        public static void SuccessCheck()
        {
            for(int i = 0; i < guessWord.Length; i++)
            {
                if (guessWord[i] == '_')
                {
                    // 하나라도 _ 존재하면 바로 함수 종료
                    return;
                }
            }
            wordGuessed = true;
        }
    }
}
