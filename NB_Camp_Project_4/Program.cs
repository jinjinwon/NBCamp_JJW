namespace NB_Camp_Project_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int iFirstNum = int.MinValue;
            int iSecondNum = int.MinValue;
            bool bExit = false;
            string input = "";

            while (!bExit)
            {
                Console.WriteLine("-------------------------------------------------------------------------------------------------");
                Console.WriteLine("첫번째 수를 입력해주세요.");
                input = Console.ReadLine();

                if (int.TryParse(input, out iFirstNum))
                {
                    // 행동 없음
                }
                else
                    iFirstNum = int.MinValue;


                Console.WriteLine("두번째 수를 입력해주세요.");
                input = Console.ReadLine();

                if (int.TryParse(input, out iSecondNum))
                {
                    // 행동 없음
                }
                else
                    iSecondNum = int.MinValue;


                bExit = NumberCheck(iFirstNum, iSecondNum);
            }
        }

        public static bool NumberCheck(int a, int b)
        {
            if (a > int.MinValue && b > int.MinValue)
            {
                if (a == b) Console.WriteLine($"{a} 와 {b}은(는) 같습니다.");
                else
                {
                    string message = a > b ? $"{a}는 {b}보다 큽니다." : $"{a}는 {b}보다 작습니다.";
                    Console.WriteLine(message);
                }

                return true;
            }
            else
            {
                Console.WriteLine("두 개의 숫자를 입력해주세요.");
                return false;
            }
        }
    }
}
