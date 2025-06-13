namespace NB_Camp_Project_11
{
    internal class FindNumber
    {
        public static readonly int MinNumber = 1;       // 최소 숫자
        public static readonly int MaxNumber = 100;     // 최대 숫자

        public static int aiPick = 0;                   // 컴퓨터 픽

        public static bool bLose = false;               // 패배
        public static bool bSuccess = false;            // 승리

        public static int maxRound = 20;                // 최대 20라운드
        public static int curRound = 1;

        static void Main(string[] args)
        {
            initialize();

            // 승리나 패배가 결정나기 전까지 반복
            while(bLose == false && bSuccess == false)
            {
                Grid();

                string input = Console.ReadLine();
                int result = WordCheck(input);

                if (result != -1)
                {
                    Console.WriteLine($"선택한 숫자 : {result}");
                    AnswerCheck(result);

                    curRound++;

                    if(curRound > maxRound)
                    {
                        bLose = true;
                        break;
                    }
                }
                else
                    Console.WriteLine("정확한 숫자를 입력해주세요! (1 ~ 100)");
            }

            if (bSuccess)
                Console.WriteLine("정답입니다!!");
            else if (bLose)
                Console.WriteLine("패배하셨습니다.. ㅠ");
        }

        public static void Grid()
        {
            Console.WriteLine("-----------------------------------------------------------------------------");
            Console.WriteLine($"                             숫자 맞추기 게임           Round {curRound}    ");
            Console.WriteLine("-----------------------------------------------------------------------------");
            Console.WriteLine("숫자를 입력해주세요! (1 ~ 100)");

        }

        public static void initialize()
        {
            aiPick = new Random().Next(MinNumber, MaxNumber + 1);
        }

        public static int WordCheck(string inputValue)
        {
            if (int.TryParse(inputValue, out int result))
            {
                if (result > 0 && result <= 100)
                    return result;
                else
                    return -1;
            }
            else
                return -1;
        }

        public static void AnswerCheck(int result)
        {
            if (result > aiPick)
                Console.WriteLine($"{result}보다 더 작습니다! 다시 한번 도전해보세요.");
            else if(result < aiPick)
                Console.WriteLine($"{result}보다 더 큽니다! 다시 한번 도전해보세요.");
            else if(result  == aiPick)
            {
                bSuccess = true;
            }
        }
    }
}
