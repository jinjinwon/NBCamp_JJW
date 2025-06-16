using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Threading;
using System;

namespace NB_Camp_Project_15
{
    internal class BaseBallGame
    {
        public static int[] targetNumber = new int[3];                              // 컴퓨터가 선택한 숫자
        public static int[] userGuess = new int[3];                                 // 사용자가 선택한 숫자

        public static int userStrikes;                                              // 자릿수와 숫자가 모두 맞는 경우의 개수
        public static int userBalls;                                                // 자릿수는 맞지 않지만 숫자는 맞는 경우의 개수
        public static int userOuts;                                                 // 자릿수는 맞지 않지만 숫자는 맞는 경우의 개수

        public static int aiStrikes;                                                // 자릿수와 숫자가 모두 맞는 경우의 개수
        public static int aiBalls;                                                  // 자릿수는 맞지 않지만 숫자는 맞는 경우의 개수
        public static int aiOuts;                                                   // 자릿수는 맞지 않지만 숫자는 맞는 경우의 개수

        public static bool guessedCorrectly;                                        // 사용자가 숫자를 정확히 맞췄는지에 대한 변수
        public static bool aiCorrectly;                                             // 컴퓨터가 숫자를 정확히 맞췄는지에 대한 변수
                                                                                    
        public static bool userNumberCheck = false;                                 // 사용자가 숫자를 선택했는지에 대한 변수
                                                                                    
        public static int round = 0;                                                // 현재 몇라운드 인지

        public static List<int>[] aiSuccessNumbers = new List<int>[3]               // 스트라이크든 볼이든 의미있는 숫자를 기억하기 위한 변수
        {
            new List<int>() {1,2,3,4,5,6,7,8,9},
            new List<int>() {1,2,3,4,5,6,7,8,9},
            new List<int>() {1,2,3,4,5,6,7,8,9}
        };                
        public static HashSet<string> triedGuessSet = new HashSet<string>();        // 중복 추측을 방지하기 위한 변수

        public static bool userTurn = true;                                         // 사용자 차례

        public static int[] aiPick = new int[3];                                    // AI가 사용자의 문제를 맞추기 위해 선택한 번호
        public static int[] userPick = new int[3];                                  // 사용자가 AI의 문제를 맞추기 위해 선택한 번호

        public static bool[] aiPickChecked = new bool[3];                           // 컴퓨터가 맞췄는지에 대한 변수


        static void Main(string[] args)
        {
            while (!userNumberCheck)
            {
                Init_Grid();
                string inputValue = Console.ReadLine();

                if (WordCheck(inputValue) == true)
                {
                    userNumberCheck = true;
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("안내사항에 따라 정확히 입력해주세요.");
                }
            }

            // 턴제기반 로직 수행
            BaseBallLogic();
            
            // 조건 되면 Clear하고 다시 그리기
            Console.Clear();
            Grid();
        }

        #region Logic
        public static void BaseBallLogic()
        {
            while (!guessedCorrectly && !aiCorrectly)
            {
                round++;
                Grid();

                // ------------------------ User 턴
                string inputNumber = Console.ReadLine();

                // 잘못 입력했으면 다시 입력하게 continue
                if (UserInputCheck(inputNumber) == false)
                {
                    ConsoleColorAPI.FontColor_Line("정확히 입력해주세요.", ConsoleColor.Red);
                    continue;
                }

                userTurn = false;

                Compare(userPick, targetNumber, out userStrikes, out userBalls, out userOuts);

                // 미리 Pick 해놓기
                SelectNumber();
                Console.Clear();
                Grid();

                if (userStrikes == 3)
                {
                    guessedCorrectly = true;
                    break;
                }

                // ------------------------ AI 턴
                Compare(aiPick, userGuess, out aiStrikes, out aiBalls, out aiOuts,true);
                UpdateAISuccessNumbers(aiPick, userGuess, aiPickChecked, aiStrikes, aiBalls);
                Console.Clear();
                Grid();

                if (aiStrikes == 3)
                {
                    aiCorrectly = true;
                    break;
                }
                userTurn = true;

                Thread.Sleep(2000);
                Console.Clear();

            }
        }
        #endregion

        #region 그리기
        public static void Init_Grid()
        {
            // 타이틀 및 설명
            Console.WriteLine("-----------------------------------------------------------------------------------------------");
            Console.Write("|                                    숫자 야구 게임            ");

            ConsoleColorAPI.FontColor($"Round : {round}", ConsoleColor.Green);
            Console.WriteLine($"                      ");
            Console.WriteLine("-----------------------------------------------------------------------------------------------");

            ConsoleColorAPI.FontColor("컴퓨터가 찾을 숫자를 입력해주세요. (중복 X, 3글자, 1 ~ 9) : ", ConsoleColor.Yellow);
        }

        public static void Grid()
        {
            // 타이틀 및 설명
            Console.WriteLine("-----------------------------------------------------------------------------------------------");
            Console.Write("|                                    숫자 야구 게임            ");

            ConsoleColorAPI.FontColor($"Round : {round}", ConsoleColor.Green);
            Console.WriteLine($"");
            Console.WriteLine("-----------------------------------------------------------------------------------------------");

            Console.Write("|                                    내가 고른 숫자            ");

            for(int i = 0; i < userGuess.Length; i++)
                ConsoleColorAPI.FontColor($"{userGuess[i]}", ConsoleColor.Blue);

            Console.WriteLine($"");
            Console.WriteLine("-----------------------------------------------------------------------------------------------");

            Console.WriteLine("-----------------------------------------------------------------------------------------------");
            Console.WriteLine($"|     |                 User                  |                         AI                       ");
            Console.WriteLine("-----------------------------------------------------------------------------------------------");
            ConsoleColorAPI.FontColor_Line($"|  S  |                   {userStrikes}                   |                         {aiStrikes}", ConsoleColor.Red);
            Console.WriteLine("-----------------------------------------------------------------------------------------------");
            ConsoleColorAPI.FontColor_Line($"|  B  |                   {userBalls}                   |                         {aiBalls}", ConsoleColor.Blue);
            Console.WriteLine("-----------------------------------------------------------------------------------------------");
            ConsoleColorAPI.FontColor_Line($"|  O  |                   {userOuts}                   |                         {aiOuts}", ConsoleColor.Yellow);
            Console.WriteLine("-----------------------------------------------------------------------------------------------");

            if (!guessedCorrectly && !aiCorrectly)
            {
                if (userTurn == true)
                {
                    Console.WriteLine("User 턴입니다.");
                    Console.Write("숫자를 맞춰주세요.(3글자, 숫자) : ");
                }
                else
                {
                    Console.WriteLine("AI 턴입니다.");
                    Console.WriteLine($"AI는 {aiPick[0]} {aiPick[1]} {aiPick[2]}를 선택하였습니다.");
                }
            }
            else
            {
                if (guessedCorrectly)
                {
                    Console.WriteLine("-----------------------------------------------------------------------------------------------");
                    ConsoleColorAPI.FontColor_Line("                                유저가 컴퓨터의 숫자를 맞췄습니다!",ConsoleColor.Green);
                    Console.WriteLine("-----------------------------------------------------------------------------------------------");
                }
                else if (aiCorrectly)
                {
                    Console.WriteLine("-----------------------------------------------------------------------------------------------");
                    ConsoleColorAPI.FontColor_Line("                                 AI가 유저의 숫자를 맞췄습니다!",ConsoleColor.Yellow);
                    Console.WriteLine("-----------------------------------------------------------------------------------------------");
                }
            }
        }
        #endregion

        #region 체크
        // 사용자 숫자 야구 번호 정하는 함수 (체크)
        public static bool WordCheck(string inputValue)
        {
            // 모든 문자가 '1'부터 '9' 사이인지 검사
            if (!inputValue.All(c => c >= '1' && c <= '9'))
            {
                return false;
            }

            // char형 정수로 바꾸기
            userGuess = inputValue.Select(c => c - '0').ToArray();

            if (userGuess.Length == 3)
            {
                // 중복된 숫자 체크
                if (userGuess.GroupBy(x => x).Any(g => g.Count() > 1) == true)
                {
                    return false;
                }
                else
                {
                    // 컴퓨터 숫자도 여기서 넣어주기
                    targetNumber = GenerateRandomDigits();
                    return true;
                }
                
            }
            // 3이 아닌 경우 false
            else
                return false;
        }

        // 사용자가 컴퓨터가 정한 번호를 맞추는 함수 (체크)
        public static bool UserInputCheck(string inputValue)
        {
            // 모든 문자가 '1'부터 '9' 사이인지 검사
            if (!inputValue.All(c => c >= '1' && c <= '9'))
            {
                return false;
            }

            // char형 정수로 바꾸기
            userPick = inputValue.Select(c => c - '0').ToArray();

            if (userPick.Length == 3)
            {
                // 중복된 숫자 체크 (같은 값을 그룹으로 묶어 개수가 2개 이상인거면 중복)
                if (userPick.GroupBy(x => x).Any(g => g.Count() > 1) == true)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
                return false;
        }

        // strike,ball 체크
        public static void Compare(int[] guess, int[] answer, out int strike, out int ball, out int outCount, bool isAI = false)
        {
            strike = 0;
            ball = 0;

            bool[] answerChecked = new bool[3]; // 정답 숫자가 사용되었는지 체크
            bool[] guessChecked = new bool[3];  // 추측 숫자가 스트라이크인지 체크

            // 스트라이크 먼저 확인
            for (int i = 0; i < 3; i++)
            {
                if (guess[i] == answer[i])
                {
                    strike++;
                    answerChecked[i] = true;
                    guessChecked[i] = true;

                    // 스트라이크인 경우 ㅇㅇ..
                    if (isAI)
                        aiPickChecked[i] = true;
                }
            }

            // 볼 검사
            for (int i = 0; i < 3; i++)
            {
                // 스트라이크 자리면 스킵
                if (guessChecked[i]) continue;

                for (int j = 0; j < 3; j++)
                {
                    // 이미 스트라이크로 사용된 숫자면 스킵
                    if (answerChecked[j]) continue;

                    if (guess[i] == answer[j])
                    {
                        ball++;
                        answerChecked[j] = true;
                        break;
                    }
                }
            }

            outCount = 3 - strike - ball;
        }
        #endregion

        #region AI
        // 사용자가 선택한 숫자를 맞추도록 랜덤한 번호를 정하는 함수
        public static void SelectNumber()
        {
            aiPick = GenerateComputerGuess();
        }

        // 기본적인 중복없는 랜덤 함수
        public static int[] GenerateRandomDigits()
        {
            Random rand = new Random();
            List<int> numbers = Enumerable.Range(1, 9).ToList();

            // 섞기
            for (int i = 0; i < numbers.Count; i++)
            {
                int j = rand.Next(i, numbers.Count);
                (numbers[i], numbers[j]) = (numbers[j], numbers[i]);
            }

            // 앞의 3개 빼서 배열로 반환
            return numbers.Take(3).ToArray();
        }

        // 얻은 정보들을 토대로 추론해서 값을 내놓는 함수
        public static int[] GenerateComputerGuess()
        {
            Random rand = new Random();
            int[] guess;

            // 우선 한번은 숫자를 설정해줘야 되니 do-while문 사용
            do
            {
                guess = new int[3];
                HashSet<int> used = new HashSet<int>();

                for (int i = 0; i < 3; i++)
                {
                    // 내가 사용할 수 있는 숫자 중 아직 사용되지 않은 숫자들 찾기
                    var candidates = aiSuccessNumbers[i].Where(n => !used.Contains(n)).ToList();

                    // 이상한 상황 -> 0이라면 그냥 기존 중복없는 랜덤 함수 뱉기
                    if (candidates.Count == 0)
                    {
                        return GenerateRandomDigits();
                    }

                    int pick = candidates[rand.Next(candidates.Count)];
                    guess[i] = pick;
                    used.Add(pick);
                }
            }
            // 중복되지 않는 숫자가 나올때까지 반복
            while (triedGuessSet.Contains(string.Join("", guess)));

            // '3','5','6' 이라면 string으로 바꿔서 중복 체크를 위해 사용 -> "356"
            triedGuessSet.Add(string.Join("", guess));
            return guess;
        }

        public static void UpdateAISuccessNumbers(int[] aiGuess, int[] userAnswer, bool[] guessChecked, int strikes, int balls)
        {
            for (int i = 0; i < 3; i++)
            {
                bool isStrike = aiGuess[i] == userAnswer[i];
                bool isBall = userAnswer.Contains(aiGuess[i]) && !isStrike;

                // 스트라이크면 해당 자리 확정
                if (isStrike)
                {
                    aiSuccessNumbers[i] = new List<int>() { aiGuess[i] };
                }
                // 볼이면 이 자리는 제거 (다른 자리 후보는 유지)
                else if (isBall)
                {
                    if (aiSuccessNumbers[i].Count > 1)
                        aiSuccessNumbers[i].Remove(aiGuess[i]);
                }
                // 아웃이면 모든 자리 후보군에서 제거
                else
                {
                    for (int pos = 0; pos < 3; pos++)
                    {
                        if (aiSuccessNumbers[pos].Count > 1)
                            aiSuccessNumbers[pos].Remove(aiGuess[i]);
                    }
                }
            }
        }
        #endregion
    }
}
